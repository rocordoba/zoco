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
    public class EstadoMovimientoService : IEstadoMovimientoService
    {
        private readonly IGenericRepository<EstadoMovimiento> _repositoryEstadoMovimiento;

        public EstadoMovimientoService(IGenericRepository<EstadoMovimiento> repositoryEstadoMovimiento)
        {
            _repositoryEstadoMovimiento = repositoryEstadoMovimiento;
        }

        public async Task<List<EstadoMovimiento>> Lista()
        {
            IQueryable<EstadoMovimiento> query = await _repositoryEstadoMovimiento.Consultar();
            return query.ToList();
        }
    }
}
