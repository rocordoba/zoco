using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlantillaBajaService
    {
        Task<List<PlantillaBaja>> Lista();
        Task<PlantillaBaja> Crear(PlantillaBaja entidad);
        Task<PlantillaBaja> Editar(PlantillaBaja entidad);
        Task<bool> Eliminar(int IdUsuario);
    }
}
