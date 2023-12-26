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
    public class hService : IhService
    {

        private readonly IGenericRepository<hS> _repositorio;

        public hService(IGenericRepository<hS> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<hS> Lista(hS entidad)
        {

            hS hS_existe = await _repositorio.Obtener(u => u.Asesor == entidad.Asesor);

            if (hS_existe != null)
                throw new TaskCanceledException("El registro no existe");

            else
                return hS_existe;

        }
    }
}
