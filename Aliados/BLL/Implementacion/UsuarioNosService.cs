using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Implementacion
{
    public class UsuarioNosService : IUsuarioNosService
    {

        private readonly IGenericRepository<UsuarioNos> _repositorioUser;
        private readonly IUtilidadesService _utilidadesService;
        private readonly ICorreoService _correoService;

        public UsuarioNosService(IGenericRepository<UsuarioNos> repositorioUser, IUtilidadesService utilidadesService, ICorreoService correoService)
        {
            _repositorioUser = repositorioUser;
            _utilidadesService = utilidadesService;
            _correoService = correoService;
        }

        public async Task<List<UsuarioNos>> Lista()
        {
            IQueryable<UsuarioNos> query = await _repositorioUser.Consultar();
            return query.Include(r => r.IdRolNavigation).ToList();
        }

        public async Task<UsuarioNos> Crear(UsuarioNos entidad)
        {

            UsuarioNos usuario_existe = await _repositorioUser.Obtener(u => u.Correo == entidad.Correo);

            if (usuario_existe != null)
                throw new TaskCanceledException("El correo ya existe, con el nombre: " + usuario_existe.Nombre);

            UsuarioNos usuario_creado = await _repositorioUser.Crear(entidad);
            try
            {

                string clave_generada = _utilidadesService.GenerarClave();
                entidad.Clave = _utilidadesService.ConvertirSha256(clave_generada);

                if(usuario_creado.IdUsuario == 0)
                    throw new TaskCanceledException("No se pudo crear el usuario");


                IQueryable<UsuarioNos> query = await _repositorioUser.Consultar(u => u.IdUsuario == usuario_creado.IdUsuario);
                usuario_creado = query.Include(r => r.IdRolNavigation).First();

                return usuario_creado;
            }
            
            catch(Exception ex) {
                throw;
            }


        }

        public async Task<UsuarioNos> Editar(UsuarioNos entidad)
        {
            UsuarioNos usuario_existe = await _repositorioUser.Obtener(u => u.Correo == entidad.Correo && u.IdUsuario != entidad.IdUsuario);

            if (usuario_existe != null)
                throw new TaskCanceledException("El correo ya existe");

            try
            {

                IQueryable<UsuarioNos> queryUsuario = await _repositorioUser.Consultar(u => u.IdUsuario == entidad.IdUsuario);
                UsuarioNos usuario_editar = queryUsuario.First();

                usuario_editar.Nombre = entidad.Nombre;
                usuario_editar.Correo = entidad.Correo;
                usuario_editar.Telefono = entidad.Telefono;
                usuario_editar.IdRol = entidad.IdRol;
                usuario_editar.Clave = entidad.Clave;
                usuario_editar.CambioClave = entidad.CambioClave;
                usuario_editar.Puntaje = entidad.Puntaje;
                usuario_editar.Activo = entidad.Activo;

                bool respuesta = await _repositorioUser.Editar(usuario_editar);

                if(!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el usuario");

                UsuarioNos usuario_editado = queryUsuario.Include(r => r.IdRolNavigation).First();

                return usuario_editado;

            }
            catch {
                throw;
            }

        }

        public async Task<bool> Eliminar(int IdUsuario)
        {
            try
            {
                UsuarioNos usuario_encontrado = await _repositorioUser.Obtener(u => u.IdUsuario == IdUsuario);

                if (usuario_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");


                return true;

            }
            catch {
                throw;
            }
        }

        public async Task<UsuarioNos> ObtenerPorCredenciales(string correo, string clave)
        {
            string clave_encriptada = _utilidadesService.ConvertirSha256(clave);

            UsuarioNos usuario_encontrado = await _repositorioUser.Obtener(u => u.Correo.Equals(correo) 
            && u.Clave.Equals(clave_encriptada));

            return usuario_encontrado;
        }

        public async Task<UsuarioNos> ObtenerPorId(int IdUsuario)
        {
            IQueryable<UsuarioNos> query = await _repositorioUser.Consultar(u => u.IdUsuario == IdUsuario);
            UsuarioNos resultado = query.Include(r => r.IdRolNavigation).FirstOrDefault();

            return resultado;
        }


        public async Task<bool> GuardarPefil(UsuarioNos entidad)
        {

            try
            {
                UsuarioNos usuario_encontrado = await _repositorioUser.Obtener(u => u.IdUsuario == entidad.IdUsuario);

                if(usuario_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");


                usuario_encontrado.Correo = entidad.Correo;
                usuario_encontrado.Telefono = entidad.Telefono;

                bool respuesta = await _repositorioUser.Editar(usuario_encontrado);

                return respuesta;

            }
            catch {
                throw;
            }

        }


        public async Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            try
            {
                UsuarioNos usuario_encontrado = await _repositorioUser.Obtener(u => u.IdUsuario == IdUsuario);

                if(usuario_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                if(usuario_encontrado.Clave != _utilidadesService.ConvertirSha256(ClaveActual))
                    throw new TaskCanceledException("La contraseña ingresada como actual no es correcta");

                usuario_encontrado.Clave = _utilidadesService.ConvertirSha256(ClaveNueva);

                bool respuesta = await _repositorioUser.Editar(usuario_encontrado);

                return respuesta;


            }
            catch(Exception ex) {
                throw;
            }

        }
        public async Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            try
            {
                UsuarioNos usuario_encontrado = await _repositorioUser.Obtener(u => u.Correo == Correo);

                if (usuario_encontrado == null)
                    throw new TaskCanceledException("No encontramos ningún usuario asociado al correo");


                string clave_generada = _utilidadesService.GenerarClave();
                usuario_encontrado.Clave = _utilidadesService.ConvertirSha256(clave_generada);


                UrlPlantillaCorreo = UrlPlantillaCorreo.Replace("[clave]", clave_generada);

                string htmlCorreo = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlPlantillaCorreo);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    using (Stream dataStream = response.GetResponseStream())
                    {

                        StreamReader readerStream = null;

                        if (response.CharacterSet == null)
                            readerStream = new StreamReader(dataStream);
                        else
                            readerStream = new StreamReader(dataStream, Encoding.GetEncoding(response.CharacterSet));

                        htmlCorreo = readerStream.ReadToEnd();
                        response.Close();
                        readerStream.Close();


                    }
                }

                bool correo_enviado = false;


                if(!correo_enviado)
                    throw new TaskCanceledException("Tenemos problemas. Por favor inténtalo nuevamente más tarde");

                bool respuesta = await _repositorioUser.Editar(usuario_encontrado);

                return respuesta;

            }
            catch {
                throw;
            }

        }
    }
}
