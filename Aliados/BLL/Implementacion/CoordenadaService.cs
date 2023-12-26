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
    public class CoordenadaService : ICoordenadaService
    {

        private readonly IGenericRepository<Coordenada> _repositorio;

        public CoordenadaService(IGenericRepository<Coordenada> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Coordenada> Crear(Coordenada entidad)
        {
            Coordenada newTerminal = await _repositorio.Obtener(d => d.IdCoordenada == entidad.IdCoordenada);

            if (newTerminal != null)
                throw new TaskCanceledException("La coordenada ya existe");


            Coordenada asesor = await _repositorio.Crear(entidad);
            try
            {
                if (asesor.IdCoordenada == 0)
                    throw new TaskCanceledException("No se puede crear la coordenada");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Coordenada> Editar(Coordenada entidad)
        {
            Coordenada Terminal_existe = await _repositorio.Obtener(u => u.IdCoordenada == entidad.IdCoordenada);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La coordenada no existe");

            try
            {

                IQueryable<Coordenada> queryTerminal = await _repositorio.Consultar(u => u.IdCoordenada == entidad.IdCoordenada);
                Coordenada Terminal_editar = queryTerminal.First();


                bool respuesta = await _repositorio.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la coordenada");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdCoordenada)
        {
            try
            {
                Coordenada Term_encontrado = await _repositorio.Obtener(u => u.IdCoordenada == IdCoordenada);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La coordenada no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Coordenada>> Lista()
        {
            IQueryable<Coordenada> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
