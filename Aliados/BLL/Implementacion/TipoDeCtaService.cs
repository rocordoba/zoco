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
    public class TipoDeCtaService : ITipoDeCtaService
    {
        private readonly IGenericRepository<TipoDeCta> _repoTipoDeCta;

        public TipoDeCtaService(IGenericRepository<TipoDeCta> repoTipoDeCta)
        {
            _repoTipoDeCta = repoTipoDeCta;
        }

        public async Task<List<TipoDeCta>> Lista()
        {
            IQueryable<TipoDeCta> query = await _repoTipoDeCta.Consultar();
            return query.ToList();
        }
    }
}
