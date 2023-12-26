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
    public class TipoNotaService : ITipoNotaService
    {
        private readonly IGenericRepository<TipoNota> _repoTipoNota;

        public TipoNotaService(IGenericRepository<TipoNota> repoTipoNota)
        {
            _repoTipoNota = repoTipoNota;
        }

        public async Task<List<TipoNota>> Lista()
        {
            IQueryable<TipoNota> query = await _repoTipoNota.Consultar();
            return query.ToList();
        }
    }
}
