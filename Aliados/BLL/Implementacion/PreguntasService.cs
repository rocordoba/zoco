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
    public class PreguntasService : IPreguntasService
    {
        private readonly IGenericRepository<Preguntas> _repoPreguntas;

        public PreguntasService(IGenericRepository<Preguntas> repoPreguntas)
        {
            _repoPreguntas = repoPreguntas;
        }

        public async Task<Preguntas> Crear(Preguntas entidad)
        {
            Preguntas newTerminal = await _repoPreguntas.Obtener(d => d.IdPreguntas == entidad.IdPreguntas);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Preguntas asesor = await _repoPreguntas.Crear(entidad);
            try
            {
                if (asesor.IdPreguntas == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Preguntas> Editar(Preguntas entidad)
        {
            Preguntas Terminal_existe = await _repoPreguntas.Obtener(u => u.IdPreguntas == entidad.IdPreguntas);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Preguntas> queryTerminal = await _repoPreguntas.Consultar(u => u.IdPreguntas == entidad.IdPreguntas);
                Preguntas Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoPreguntas.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdPreguntas)
        {
            
           try
            {
                Preguntas Term_encontrado = await _repoPreguntas.Obtener(u => u.IdPreguntas == IdPreguntas);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<Preguntas>> Lista()
        {
            IQueryable<Preguntas> query = await _repoPreguntas.Consultar();
            return query.ToList();
        }
    }
}
