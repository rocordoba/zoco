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
    public class EstadoAfipService: IEstadoAfipService
    {
        private readonly IGenericRepository<EstadoAfip> _repositoryEstadoAfip;

        public EstadoAfipService(IGenericRepository<EstadoAfip> repositoryEstadoAfip)
        {
            _repositoryEstadoAfip = repositoryEstadoAfip;
        }

        public async Task<List<EstadoAfip>> Lista()
        {
            IQueryable<EstadoAfip> query = await _repositoryEstadoAfip.Consultar();
            return query.ToList();
        }
    }
}
