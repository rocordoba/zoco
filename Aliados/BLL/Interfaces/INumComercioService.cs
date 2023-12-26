using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INumComercioService
    {
        Task<List<NumComercio>> Lista();
        Task<NumComercio> Crear(NumComercio entidad);
        Task<NumComercio> Editar(NumComercio entidad);
        Task<bool> Eliminar(int IdNumComercio);
    }
}
