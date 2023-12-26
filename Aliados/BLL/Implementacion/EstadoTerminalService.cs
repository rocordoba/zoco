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
    public class EstadoTerminalService : IEstadoTerminalService
    {

        private readonly IGenericRepository<EstadoTerminal> _repoEstadoTerminal;

        public EstadoTerminalService(IGenericRepository<EstadoTerminal> repoEstadoTerminal)
        {
            _repoEstadoTerminal = repoEstadoTerminal;
        }

        public async Task<List<EstadoTerminal>> Lista()
        {
            IQueryable<EstadoTerminal> query = await _repoEstadoTerminal.Consultar();
            return query.ToList();
        }
    }
}
