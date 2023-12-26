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
    public class FeriadosService : IFeriadosService
    {
        private readonly IGenericRepository<Feriados> _repoFeriados;

        public FeriadosService(IGenericRepository<Feriados> repoFeriados)
        {
            _repoFeriados = repoFeriados;
        }

        public async Task<Feriados> Crear(Feriados entidad)
        {
            Feriados newTerminal = await _repoFeriados.Obtener(d => d.Id == entidad.Id);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Feriados asesor = await _repoFeriados.Crear(entidad);
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

        public async Task<Feriados> Editar(Feriados entidad)
        {
            Feriados Terminal_existe = await _repoFeriados.Obtener(u => u.Id == entidad.Id);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Feriados> queryTerminal = await _repoFeriados.Consultar(u => u.Id == entidad.Id);
                Feriados Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoFeriados.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdFeriados)
        {
            try
            {
                Feriados Term_encontrado = await _repoFeriados.Obtener(u => u.Id == IdFeriados);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Feriados>> Lista()
        {
            IQueryable<Feriados> query = await _repoFeriados.Consultar();
            return query.ToList();
        }
    }
}
