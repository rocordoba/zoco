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
    public class TipoDeAltaService : ITipoDeAltaService
    {
        private readonly IGenericRepository<TipoDeAlta> _repositoryTipoDeAlta;

        public TipoDeAltaService(IGenericRepository<TipoDeAlta> repositoryEstadoAfip)
        {
            _repositoryTipoDeAlta = repositoryEstadoAfip;
        }

        public async Task<List<TipoDeAlta>> Lista()
        {
            IQueryable<TipoDeAlta> query = await _repositoryTipoDeAlta.Consultar();
            return query.ToList();
        }
    }
}
