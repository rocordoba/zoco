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
    public class NotaNosService : INotaNosService
    {
        private readonly IGenericRepository<NotaNos> _repoNotaNos;

        public NotaNosService(IGenericRepository<NotaNos> repoNotaNos)
        {
            _repoNotaNos = repoNotaNos;
        }

        public async Task<NotaNos> Crear(NotaNos entidad)
        {
            NotaNos newTerminal = await _repoNotaNos.Obtener(d => d.IdNota == entidad.IdNota);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            NotaNos asesor = await _repoNotaNos.Crear(entidad);
            try
            {
                if (asesor.IdNota == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<NotaNos> Editar(NotaNos entidad)
        {
            NotaNos Terminal_existe = await _repoNotaNos.Obtener(u => u.IdNota == entidad.IdNota);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<NotaNos> queryTerminal = await _repoNotaNos.Consultar(u => u.IdNota == entidad.IdNota);
                NotaNos Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoNotaNos.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdNotaNos)
        {
            try
            {
                NotaNos Term_encontrado = await _repoNotaNos.Obtener(u => u.IdNota == IdNotaNos);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<NotaNos>> Lista()
        {
            IQueryable<NotaNos> query = await _repoNotaNos.Consultar();
            return query.ToList();
        }
    }
}
