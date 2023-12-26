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
    public class TipoMetricaService : ITipoMetricaService
    {
        private readonly IGenericRepository<TipoMetricas> _serviceTipoMetrica;

        public TipoMetricaService(IGenericRepository<TipoMetricas> serviceTipoMetrica)
        {
            _serviceTipoMetrica = serviceTipoMetrica;
        }

        public async Task<List<TipoMetricas>> Lista()
        {
            IQueryable<TipoMetricas> query = await _serviceTipoMetrica.Consultar();
            return query.ToList();
        }
    }
}
