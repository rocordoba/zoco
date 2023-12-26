using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IUsuarioNosService
    {
        //necesito que traiga por roles, para maestro/pagos,etc
        Task<List<UsuarioNos>> Lista();
        Task<UsuarioNos> Crear(UsuarioNos entidad);
        Task<UsuarioNos> Editar(UsuarioNos entidad);
        Task<bool> Eliminar(int IdUsuario);
        Task<UsuarioNos> ObtenerPorCredenciales(string correo, string clave);
        Task<UsuarioNos> ObtenerPorId(int IdUsuario);
        Task<bool> GuardarPefil(UsuarioNos entidad);
        Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva);
        Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo);
    }
}
