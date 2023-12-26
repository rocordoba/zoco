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
    public class EstadoTareaService : IEstadoTareaService
    {
        private readonly IGenericRepository<EstadoTareas> _repoEstadoTarea;

        public EstadoTareaService(IGenericRepository<EstadoTareas> repoEstadoTarea)
        {
            _repoEstadoTarea = repoEstadoTarea;
        }

        public async Task<List<EstadoTareas>> Lista()
        {
            IQueryable<EstadoTareas> query = await _repoEstadoTarea.Consultar();
            return query.ToList();
        }




    }
}
