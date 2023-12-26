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
    public class NumComercioService : INumComercioService
    {
        private readonly IGenericRepository<NumComercio> _repoNumComercio;

        public NumComercioService(IGenericRepository<NumComercio> repoNumComercio)
        {
            _repoNumComercio = repoNumComercio;
        }

        public async Task<NumComercio> Crear(NumComercio entidad)
        {
            NumComercio newAsesor = await _repoNumComercio.Obtener(d => d.IdNumComercio == entidad.IdNumComercio);

            if (newAsesor != null)
                throw new TaskCanceledException("El asesor ya existe!");


            NumComercio asesor = await _repoNumComercio.Crear(entidad);
            try
            {
                if (asesor.IdNumComercio == 0)
                    throw new TaskCanceledException("No se puede crear el asesor");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<NumComercio> Editar(NumComercio entidad)
        {
            NumComercio Terminal_existe = await _repoNumComercio.Obtener(u => u.IdNumComercio == entidad.IdNumComercio);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<NumComercio> queryTerminal = await _repoNumComercio.Consultar(u => u.IdNumComercio == entidad.IdNumComercio);
                NumComercio Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoNumComercio.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdNumComercio)
        {
            try
            {
                NumComercio Term_encontrado = await _repoNumComercio.Obtener(u => u.IdNumComercio == IdNumComercio);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<NumComercio>> Lista()
        {
            IQueryable<NumComercio> query = await _repoNumComercio.Consultar();
            return query.ToList();
        }
    }
}
