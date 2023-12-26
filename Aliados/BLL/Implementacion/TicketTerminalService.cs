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
    public class TicketTerminalService : ITicketTerminalService
    {
        private readonly IGenericRepository<TicketTerminal> _repoTicketTerminal;

        public TicketTerminalService(IGenericRepository<TicketTerminal> repoTicketTerminal)
        {
            _repoTicketTerminal = repoTicketTerminal;
        }

        public async Task<List<TicketTerminal>> Lista()
        {
            IQueryable<TicketTerminal> query = await _repoTicketTerminal.Consultar();
            return query.ToList();
        }







    }
}
