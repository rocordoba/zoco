using BLL.Interfaces;
using DAL.Interfaces;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementacion
{
    public class EstadoPlantillaService : IEstadoPlantillaService
    {

        private readonly IGenericRepository<EstadoPlantilla> _repositoryEstadoPlantilla;

        public EstadoPlantillaService(IGenericRepository<EstadoPlantilla> repositoryEstadoPlantilla)
        {
            _repositoryEstadoPlantilla = repositoryEstadoPlantilla;
        }

        public async Task<List<EstadoPlantilla>> Lista()
        {
            IQueryable<EstadoPlantilla> query = await _repositoryEstadoPlantilla.Consultar();
            return query.ToList();
        }
    }
}
