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
    public class RespuestasService : IRespuestasService
    {
        private readonly IGenericRepository<Respuestas> _repoRespuestas;

        public RespuestasService(IGenericRepository<Respuestas> repoRespuestas)
        {
            _repoRespuestas = repoRespuestas;
        }

        public async Task<Respuestas> Crear(Respuestas entidad)
        {
            Respuestas newTerminal = await _repoRespuestas.Obtener(d => d.IdRespuesta == entidad.IdRespuesta);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Respuestas asesor = await _repoRespuestas.Crear(entidad);
            try
            {
                if (asesor.IdRespuesta == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Respuestas> Editar(Respuestas entidad)
        {
            Respuestas Terminal_existe = await _repoRespuestas.Obtener(u => u.IdRespuesta == entidad.IdRespuesta);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Respuestas> queryTerminal = await _repoRespuestas.Consultar(u => u.IdRespuesta == entidad.IdRespuesta);
                Respuestas Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoRespuestas.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdRespuestas)
        {
            try
            {
                Respuestas Term_encontrado = await _repoRespuestas.Obtener(u => u.IdRespuesta == IdRespuestas);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Respuestas>> Lista()
        {
            IQueryable<Respuestas> query = await _repoRespuestas.Consultar();
            return query.ToList();
        }
    }
}
