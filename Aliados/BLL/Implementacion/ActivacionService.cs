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
    public class ActivacionService: IActivacionService
    {
        private readonly IGenericRepository<Activacion> _repositoryActivacion;

        public ActivacionService(IGenericRepository<Activacion> repositoryActivacion)
        {
            _repositoryActivacion = repositoryActivacion;
        }

        public async Task<List<Activacion>> Lista()
        {
            IQueryable<Activacion> query = await _repositoryActivacion.Consultar();
            return query.ToList();
        }
    }
}
