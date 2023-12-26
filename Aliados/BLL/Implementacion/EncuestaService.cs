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
    public class EncuestaService : IEncuestaService
    {
        private readonly IGenericRepository<Encuesta> _repoEncuesta;

        public EncuestaService(IGenericRepository<Encuesta> repoEncuesta)
        {
            _repoEncuesta = repoEncuesta;
        }

        public async Task<Encuesta> Crear(Encuesta entidad)
        {
            Encuesta newTerminal = await _repoEncuesta.Obtener(d => d.IdEncuesta == entidad.IdEncuesta);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Encuesta asesor = await _repoEncuesta.Crear(entidad);
            try
            {
                if (asesor.IdEncuesta == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Encuesta> Editar(Encuesta entidad)
        {
            Encuesta Terminal_existe = await _repoEncuesta.Obtener(u => u.IdEncuesta == entidad.IdEncuesta);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Encuesta> queryTerminal = await _repoEncuesta.Consultar(u => u.IdEncuesta == entidad.IdEncuesta);
                Encuesta Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoEncuesta.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idEncuesta)
        {
            try
            {
                Encuesta Term_encontrado = await _repoEncuesta.Obtener(u => u.IdEncuesta == idEncuesta);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Encuesta>> Lista()
        {
            IQueryable<Encuesta> query = await _repoEncuesta.Consultar();
            return query.ToList();
        }
    }
}
