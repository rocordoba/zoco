using BLL.Interfaces;
using BLL.InterfacesZoco;
using DAL.Interfaces;
using Entity.Zoco;
//using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ImplemtacionZoco
{
    public class UsuarioZocoService : IUsuarioZocoService
    {
        private readonly IGenericRepository<Usuarios> _repositorioUser;
        private readonly IUtilidadesService _utilidadesService;
        private readonly ICorreoService _correoService;

        public UsuarioZocoService(IGenericRepository<Usuarios> repositorioUser, IUtilidadesService utilidadesService, ICorreoService correoService)
        {
            _repositorioUser = repositorioUser;
            _utilidadesService = utilidadesService;
            _correoService = correoService;
        }

        public Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuarios> Crear(Usuarios entidad)
        {
            Usuarios usuario_existe =await _repositorioUser.Obtener(u=>u.Usuario == entidad.Usuario);
           
            if (usuario_existe != null)
                throw new TaskCanceledException("El correo ya existe, con el nombre: " + usuario_existe.Nombre);

            Usuarios usuario_creado = await _repositorioUser.Crear(entidad);
            try
            {

                string clave_generada = _utilidadesService.GenerarClave();
                entidad.Password = _utilidadesService.GenerateHash256(clave_generada);

                if (usuario_creado.Id == 0)
                    throw new TaskCanceledException("No se pudo crear el usuario");


                IQueryable<Usuarios> query = await _repositorioUser.Consultar(u => u.Id == usuario_creado.Id);
                usuario_creado = query.First();

                return usuario_creado;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Usuarios> Editar(Usuarios entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardarcalificacion(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarPefil(Usuarios entidad)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuarios>> Lista()
        {
            throw new NotImplementedException();
        }

        public string GenerateBCryptHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public async Task<Usuarios> ObtenerPorCredenciales(string correo, string clave)
        {
            // Conversión del correo a double, si es necesario
            var usuariocuit = Convert.ToDouble(correo);

            // Busca el usuario por el correo
            Usuarios usuario_encontrado = await _repositorioUser.Obtener(u => u.Usuario == correo);

            // Verifica si se encontró el usuario
            if (usuario_encontrado == null)
            {
                // Manejo de usuario no encontrado
                return null;
            }

            // Verifica la clave usando EnhancedVerify. Aquí, 'clave' es la contraseña en texto plano ingresada por el usuario,
            // y 'usuario_encontrado.Password' es la versión encriptada almacenada en la base de datos.
            bool verified = BCrypt.Net.BCrypt.Verify(clave, usuario_encontrado.Password);

            // Si la verificación es exitosa, devuelve el usuario
            if (verified)
            {
                // Lógica adicional si es necesaria
                // Por ejemplo, generar y enviar un código de verificación

                return usuario_encontrado;
            }
            else
            {
                // Manejo de la contraseña incorrecta
                return null;
            }
        }




        public async Task<Usuarios> ObtenerPorId(int IdUsuario)
        {
            IQueryable<Usuarios> query = await _repositorioUser.Consultar(u => u.Id == IdUsuario);

            Usuarios resultado = query.FirstOrDefault();

            return resultado;
        }

        public Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            throw new NotImplementedException();
        }





      
    }
}
