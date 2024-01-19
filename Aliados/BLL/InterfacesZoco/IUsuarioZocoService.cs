//using Entity.Entity;
using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesZoco
{
    public interface IUsuarioZocoService
    {
       
            Task<List<Usuarios>> Lista();
            Task<Usuarios> Crear(Usuarios entidad);
            Task<Usuarios> Editar(Usuarios entidad);
            Task<bool> Eliminar(int IdUsuario);
            Task<bool> Guardarcalificacion(int IdUsuario);
            Task<Usuarios> ObtenerPorCredenciales(string correo, string clave);
            Task<Usuarios> ObtenerPorId(int IdUsuario);
            Task<bool> GuardarPefil(Usuarios entidad);
            Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva);
           Task<bool> RestablecerClaveliquidaciones(int IdUsuario);
           Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo);
            
        
    }
}
