using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlantillaAltaFisicaService
    {
        Task<List<PlantillaAltaFisica>> Lista();
        Task<PlantillaAltaFisica> Crear(PlantillaAltaFisica entidad);
        Task<PlantillaAltaFisica> Editar(PlantillaAltaFisica entidad);
        Task<bool> Eliminar(int IdPlantillaAltaFisica);
    }
}
