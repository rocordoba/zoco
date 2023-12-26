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
    public class AnService : IAnService
    {
        private readonly IGenericRepository<An> _repository;

        public AnService(IGenericRepository<An> repository)
        {
            _repository = repository;
        }

        public async Task<An> Lista(An entidad)
        {
            An hS_existe = await _repository.Obtener(u => u.AsesorAbm == entidad.AsesorAbm);

            if (hS_existe != null)
                throw new TaskCanceledException("El registro no existe");

            else
                return hS_existe;
        }
    }
}
