using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioDotacionService
    {
        Task<List<UsuarioDotacion>> Lista();
        Task<UsuarioDotacion> Crear(UsuarioDotacion entidad);
        Task<UsuarioDotacion> Editar(UsuarioDotacion entidad);
        Task<bool> Eliminar(int IdUsuario);
        Task<UsuarioDotacion> ObtenerPorCredenciales(string correo, string clave);
        Task<UsuarioDotacion> ObtenerPorId(int IdUsuario);
        Task<bool> GuardarPefil(UsuarioDotacion entidad);
        Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva);
        Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo);
    }
}
