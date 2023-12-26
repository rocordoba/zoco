using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IFantasiaComercioService
    {
          Task<List<FantasiaComercio>> DatosInicioAliadosFiltros(int IdUsuario);
        Task<List<FantasiaComercio>> Lista();
        Task<FantasiaComercio> Crear(FantasiaComercio entidad);
        Task<FantasiaComercio> Editar(FantasiaComercio entidad);
        Task<bool> Eliminar(int IdFantasiaComercio);
    }
}
