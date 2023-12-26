using BLL.Interfaces;
using DAL.Interfaces;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementacion
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IGenericRepository<Usuarios> _repositorioUser;
        private readonly IUtilidadesService _utilidadesService;
        private readonly ICorreoService _correoService;

        public UsuariosService(IGenericRepository<Usuarios> repositorioUser, IUtilidadesService utilidadesService, ICorreoService correoService)
        {
            _repositorioUser = repositorioUser;
            _utilidadesService = utilidadesService;
            _correoService = correoService;
        }

        public async Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuarios> Crear(Usuarios entidad)
        {
            Usuarios usuario_existe = await _repositorioUser.Obtener(u => u.Correo == entidad.Correo);

            if (usuario_existe != null)
                throw new TaskCanceledException("El correo ya existe, con el nombre: " + usuario_existe.Nombre);

            Usuarios usuario_creado = await _repositorioUser.Crear(entidad);
            try
            {

                string clave_generada = _utilidadesService.GenerarClave();
                entidad.Clave = _utilidadesService.ConvertirSha256(clave_generada);

                if (usuario_creado.IdUsuario == 0)
                    throw new TaskCanceledException("No se pudo crear el usuario");


                IQueryable<Usuarios> query = await _repositorioUser.Consultar(u => u.IdUsuario == usuario_creado.IdUsuario);
                usuario_creado = query.First();

                return usuario_creado;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Usuarios> Editar(Usuarios entidad)
        {
            Usuarios usuario_existe = await _repositorioUser.Obtener(u => u.Correo == entidad.Correo && u.IdUsuario != entidad.IdUsuario);

            if (usuario_existe != null)
                throw new TaskCanceledException("El correo ya existe");

            try
            {

                IQueryable<Usuarios> queryUsuario = await _repositorioUser.Consultar(u => u.IdUsuario == entidad.IdUsuario);
                Usuarios usuario_editar = queryUsuario.First();

                usuario_editar.Nombre = entidad.Nombre;
                usuario_editar.Correo = entidad.Correo;
                usuario_editar.Telefono = entidad.Telefono;
                usuario_editar.TipoUsuario = entidad.TipoUsuario;
                usuario_editar.Clave = entidad.Clave;
                usuario_editar.CambioClave = entidad.CambioClave;
                usuario_editar.Puntaje = entidad.Puntaje;
                usuario_editar.Constante = entidad.Constante;
                usuario_editar.Califico = entidad.Califico;
                usuario_editar.Activo = entidad.Activo;


                bool respuesta = await _repositorioUser.Editar(usuario_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el usuario");

                Usuarios usuario_editado = queryUsuario.First();

                return usuario_editado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdUsuario)
        {
            try
            {
                Usuarios usuario_encontrado = await _repositorioUser.Obtener(u => u.IdUsuario == IdUsuario);

                if (usuario_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");


                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Guardarcalificacion(int IdUsuario, int? calificacion, string observacion)
        {
            Usuarios usuario = await _repositorioUser.Obtener(u => u.IdUsuario == IdUsuario);

            if (usuario == null)
            {
                throw new TaskCanceledException("El usuario no existe");
            }

            usuario.Califico = 1;
            //   usuario.OBSERVACION = observacion;
            usuario.Puntaje = calificacion;

            await _repositorioUser.Editar(usuario);

            return true;
        }

        public Task<bool> Guardarcalificacion(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GuardarPefil(Usuarios entidad)
        {
            try
            {
                Usuarios usuario_encontrado = await _repositorioUser.Obtener(u => u.IdUsuario == entidad.IdUsuario);

                if (usuario_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");


                usuario_encontrado.Correo = entidad.Correo;
                usuario_encontrado.Telefono = entidad.Telefono;

                bool respuesta = await _repositorioUser.Editar(usuario_encontrado);

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Usuarios>> Lista()
        {
            IQueryable<Usuarios> query = await _repositorioUser.Consultar();
            return query.ToList();
        }

        public async Task<Usuarios> ObtenerPorCredenciales(string correo, string clave)
        {
            string clave_encriptada = _utilidadesService.ConvertirSha256(clave);

            var usuariocuit = Convert.ToDouble(correo);

            Usuarios usuario_encontrado = await _repositorioUser.Obtener(u => u.UsuarioCuit == usuariocuit && u.Clave == clave_encriptada);


            // si usuario es diferente de null
            //creo un numero aleatorio, le mando , lo guardo, UPDATE!!
            //lo puedo mandar x CORREO o por whatsapp!

            //le pido que lo ingrese en un modal, 
            //si es el mismo, lo dejo ingresar!
            //y le retorno el usuario, sino lo trunco, 

            //contabilizar si es la segunda vez q ingresa mal el codigo

            return usuario_encontrado;
        }

        public async Task<Usuarios> ObtenerPorId(int IdUsuario)
        {
            IQueryable<Usuarios> query = await _repositorioUser.Consultar(u => u.IdUsuario == IdUsuario);

            Usuarios resultado = query.FirstOrDefault();

            return resultado;
        }

        public async Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            try
            {
                Usuarios usuario_encontrado = await _repositorioUser.Obtener(u => u.Correo == Correo);

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


                if (!correo_enviado)
                    throw new TaskCanceledException("Tenemos problemas. Por favor inténtalo nuevamente más tarde");

                bool respuesta = await _repositorioUser.Editar(usuario_encontrado);

                return respuesta;

            }
            catch
            {
                throw;
            }
        }



    }
}
