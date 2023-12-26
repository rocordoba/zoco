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
    public class TipoBajaService : ITipoBajaService
    {
        private readonly IGenericRepository<TipoBaja> _repoTipoBaja;

        public TipoBajaService(IGenericRepository<TipoBaja> repoTipoBaja)
        {
            _repoTipoBaja = repoTipoBaja;
        }

        public async Task<List<TipoBaja>> Lista()
        {
            IQueryable<TipoBaja> query = await _repoTipoBaja.Consultar();
            return query.ToList();
        }
    }
}
