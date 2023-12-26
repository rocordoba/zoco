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
    public class DecTomadaService : IDecTomadaService
    {

        private readonly IGenericRepository<DecTomadaTerminal> _repositoryEstadoAfip;

        public DecTomadaService(IGenericRepository<DecTomadaTerminal> repositoryEstadoAfip)
        {
            _repositoryEstadoAfip = repositoryEstadoAfip;
        }

        public async Task<List<DecTomadaTerminal>> Lista()
        {
            IQueryable<DecTomadaTerminal> query = await _repositoryEstadoAfip.Consultar();
            return query.ToList();
        }
    }
}
