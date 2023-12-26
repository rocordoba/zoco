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
    public class BancoService : IBancoService
    {
        private readonly IGenericRepository<Banco> _repositorio;

        public BancoService(IGenericRepository<Banco> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Banco> Crear(Banco entidad)
        {
            Banco newTerminal = await _repositorio.Obtener(d => d.IdBanco == entidad.IdBanco);

            if (newTerminal != null)
                throw new TaskCanceledException("La coordenada ya existe");


            Banco asesor = await _repositorio.Crear(entidad);
            try
            {
                if (asesor.IdBanco == 0)
                    throw new TaskCanceledException("No se puede crear la coordenada");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Banco> Editar(Banco entidad)
        {
            Banco Terminal_existe = await _repositorio.Obtener(u => u.IdBanco == entidad.IdBanco);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La coordenada no existe");

            try
            {

                IQueryable<Banco> queryTerminal = await _repositorio.Consultar(u => u.IdBanco == entidad.IdBanco);
                Banco Terminal_editar = queryTerminal.First();


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

        public async Task<bool> Eliminar(int idBanco)
        {
            try
            {
                Banco Term_encontrado = await _repositorio.Obtener(u => u.IdBanco == idBanco);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La coordenada no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Banco>> Lista()
        {
            IQueryable<Banco> query = await _repositorio.Consultar();
            return query.ToList();

        }
    }
}
