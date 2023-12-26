using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementacion
{
    public class ActividadAfipService : IActividadAfipService
    {
        private readonly IGenericRepository<ActividadAfip> _repoActividadAfip;

        public ActividadAfipService(IGenericRepository<ActividadAfip> repoActividadAfip)
        {
            _repoActividadAfip = repoActividadAfip;
        }

        public async Task<List<ActividadAfip>> Lista()
        {
            IQueryable<ActividadAfip> query = await _repoActividadAfip.Consultar();
            return query.ToList();
        }
    }
}
