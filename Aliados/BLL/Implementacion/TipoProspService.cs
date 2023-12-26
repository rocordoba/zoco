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
    public class TipoProspService : ITipoProspService
    {

        private readonly IGenericRepository<TipoProsp> _repoTerminales;

        public TipoProspService(IGenericRepository<TipoProsp> repoTerminales)
        {
            _repoTerminales = repoTerminales;
        }

        public async Task<List<TipoProsp>> Lista()
        {
            IQueryable<TipoProsp> query = await _repoTerminales.Consultar();
            return query.ToList();
        }
    }
}
