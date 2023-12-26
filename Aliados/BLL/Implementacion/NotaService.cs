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
    public class NotaService : INotaService
    {
        private readonly IGenericRepository<Nota> _repoNota;

        public NotaService(IGenericRepository<Nota> repoNota)
        {
            _repoNota = repoNota;
        }

        public async Task<Nota> Crear(Nota entidad)
        {
            Nota newTerminal = await _repoNota.Obtener(d => d.IdNota == entidad.IdNota);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Nota asesor = await _repoNota.Crear(entidad);
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

        public async Task<Nota> Editar(Nota entidad)
        {
            Nota Terminal_existe = await _repoNota.Obtener(u => u.IdNota == entidad.IdNota);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Nota> queryTerminal = await _repoNota.Consultar(u => u.IdNota == entidad.IdNota);
                Nota Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoNota.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdNota)
        {
            try
            {
                Nota Term_encontrado = await _repoNota.Obtener(u => u.IdNota == IdNota);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Nota>> Lista()
        {
            IQueryable<Nota> query = await _repoNota.Consultar();
            return query.ToList();
        }
    }
}
