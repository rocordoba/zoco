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
    public class EstadoVisitaService : IEstadoVisitaService
    {
        private readonly IGenericRepository<EstadoVisita> _repository;

        public EstadoVisitaService(IGenericRepository<EstadoVisita> repository)
        {
            _repository = repository;
        }

        public async Task<List<EstadoVisita>> Lista()
        {
            IQueryable<EstadoVisita> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
