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
    public class FactoresService : IFactoresService
    {
        private readonly IGenericRepository<Factores> _repoFactores;

        public FactoresService(IGenericRepository<Factores> repoFactores)
        {
            _repoFactores = repoFactores;
        }

        public async Task<Factores> Crear(Factores entidad)
        {
            Factores newTerminal = await _repoFactores.Obtener(d => d.IdNiveles == entidad.IdNiveles);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Factores asesor = await _repoFactores.Crear(entidad);
            try
            {
                if (asesor.IdNiveles == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Factores> Editar(Factores entidad)
        {
            Factores Terminal_existe = await _repoFactores.Obtener(u => u.IdNiveles == entidad.IdNiveles);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Factores> queryTerminal = await _repoFactores.Consultar(u => u.IdNiveles == entidad.IdNiveles);
                Factores Terminal_editar = queryTerminal.First();

                //Terminal_editar.NumTerminal = Terminal_editar.NumTerminal;
                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoFactores.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdFactores)
        {
            try
            {
                Factores Term_encontrado = await _repoFactores.Obtener(u => u.IdNiveles == IdFactores);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }        }

        public async Task<List<Factores>> Lista()
        {
            IQueryable<Factores> query = await _repoFactores.Consultar();
            return query.ToList();
        }
    }
}
