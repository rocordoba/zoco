using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;

namespace BLL.Implementacion
{
    public class RubroService: IRubroService
    {
        private readonly IGenericRepository<Rubro> _repoRubro;

        public RubroService(IGenericRepository<Rubro> repository)
        {
            _repoRubro = repository;
        }

        public async Task<List<Rubro>> Lista()
        {
            IQueryable<Rubro> query = await _repoRubro.Consultar();
            return query.ToList();
        }
    }
}
