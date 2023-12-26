using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlantillaModService
    {
        Task<List<PlantillaModificaciones>> Lista();
        Task<PlantillaModificaciones> Crear(PlantillaModificaciones entidad);
        Task<PlantillaModificaciones> Editar(PlantillaModificaciones entidad);
        Task<bool> Eliminar(int IdUsuario);
    }
}
