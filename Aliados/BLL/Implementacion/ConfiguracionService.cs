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
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IGenericRepository<Configuracion> _repository;

        public ConfiguracionService(IGenericRepository<Configuracion> repository)
        {
            _repository = repository;
        }

        public async Task<List<Configuracion>> Lista()
        {
            IQueryable<Configuracion> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
