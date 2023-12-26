using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlantillaAltaJurService
    {
        Task<List<PlantillaAltaJur>> Lista();
        Task<PlantillaAltaJur> Crear(PlantillaAltaJur entidad);
        Task<PlantillaAltaJur> Editar(PlantillaAltaJur entidad);
        Task<bool> Eliminar(int IdPlantillaAltaJur);

    }
}
