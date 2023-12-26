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
    public class ImpuestosVariosService : IImpuestosVariosService
    {

        private readonly IGenericRepository<ImpuestosVarios> _repoImpuestosVarios;

        public ImpuestosVariosService(IGenericRepository<ImpuestosVarios> repoImpuestosVarios)
        {
            _repoImpuestosVarios = repoImpuestosVarios;
        }

        public async Task<ImpuestosVarios> Crear(ImpuestosVarios entidad)
        {
            ImpuestosVarios newTerminal = await _repoImpuestosVarios.Obtener(d => d.Id == entidad.Id);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            ImpuestosVarios asesor = await _repoImpuestosVarios.Crear(entidad);
            try
            {
                if (asesor.Id == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ImpuestosVarios> Editar(ImpuestosVarios entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int idImpuestosVarios)
        {
            throw new NotImplementedException();

        }

        public async Task<List<ImpuestosVarios>> Lista()
        {
            IQueryable<ImpuestosVarios> query = await _repoImpuestosVarios.Consultar();
            return query.ToList();
        }
    }
}
