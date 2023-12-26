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
    public class TablaFechasLaborablesService : ITablaFechasLaborablesService
    {
        private readonly IGenericRepository<TablaFechasLaborables> _genericRepository;

        public TablaFechasLaborablesService(IGenericRepository<TablaFechasLaborables> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<TablaFechasLaborables> Crear(TablaFechasLaborables entidad)
        {
            TablaFechasLaborables newTerminal = await _genericRepository.Obtener(d => d.Id == entidad.Id);

            if (newTerminal != null)
                throw new TaskCanceledException("La fecha ya existe");


            TablaFechasLaborables asesor = await _genericRepository.Crear(entidad);
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

        public async Task<TablaFechasLaborables> Editar(TablaFechasLaborables entidad)
        {
            TablaFechasLaborables Terminal_existe = await _genericRepository.Obtener(u => u.Id == entidad.Id);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<TablaFechasLaborables> queryTerminal = await _genericRepository.Consultar(u => u.Id == entidad.Id);
                TablaFechasLaborables Terminal_editar = queryTerminal.First();


                bool respuesta = await _genericRepository.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idTablaFechasLaborables)
        {
            try
            {
                TablaFechasLaborables Term_encontrado = await _genericRepository.Obtener(u => u.Id == idTablaFechasLaborables);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TablaFechasLaborables>> Lista()
        {
            IQueryable<TablaFechasLaborables> query = await _genericRepository.Consultar();
            return query.ToList();
        }
    }
}
