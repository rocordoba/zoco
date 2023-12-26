using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;

namespace BLL.Implementacion
{
    public class EstadoRentasService : IEstadoRentasService
    {
        private readonly IGenericRepository<EstadoRenta> _repository;

        public EstadoRentasService(IGenericRepository<EstadoRenta> repository)
        {
            _repository = repository;
        }

        public async Task<List<EstadoRenta>> Lista()
        {
            IQueryable<EstadoRenta> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
