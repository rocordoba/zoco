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
    public class StockTerminalesService : IStockTerminalesService
    {
        private readonly IGenericRepository<StockTerminales> _repoStockTerminales;

        public StockTerminalesService(IGenericRepository<StockTerminales> repoStockTerminales)
        {
            _repoStockTerminales = repoStockTerminales;
        }

        public async Task<StockTerminales> Crear(StockTerminales entidad)
        {
            StockTerminales newTerminal = await _repoStockTerminales.Obtener(d => d.IdStockTerminales == entidad.IdStockTerminales);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            StockTerminales asesor = await _repoStockTerminales.Crear(entidad);
            try
            {
                if (asesor.IdStockTerminales == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StockTerminales> Editar(StockTerminales entidad)
        {
            StockTerminales Terminal_existe = await _repoStockTerminales.Obtener(u => u.IdStockTerminales == entidad.IdStockTerminales);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<StockTerminales> queryTerminal = await _repoStockTerminales.Consultar(u => u.IdStockTerminales == entidad.IdStockTerminales);
                StockTerminales Terminal_editar = queryTerminal.First();

                //Terminal_editar.NumTerminal = Terminal_editar.NumTerminal;
                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoStockTerminales.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idStockTerminales)
        {
            try
            {
                StockTerminales Term_encontrado = await _repoStockTerminales.Obtener(u => u.IdStockTerminales == idStockTerminales);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<StockTerminales>> Lista()
        {
            IQueryable<StockTerminales> query = await _repoStockTerminales.Consultar();
            return query.ToList();
        }
    }
}
