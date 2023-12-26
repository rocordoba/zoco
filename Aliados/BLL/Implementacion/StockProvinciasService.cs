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
    public class StockProvinciasService : IStockProvinciasService
    {
        private readonly IGenericRepository<StockProvincias> _repoStockProvincias;

        public StockProvinciasService(IGenericRepository<StockProvincias> repoStockProvincias)
        {
            _repoStockProvincias = repoStockProvincias;
        }

        public async Task<StockProvincias> Crear(StockProvincias entidad)
        {
            StockProvincias newTerminal = await _repoStockProvincias.Obtener(d => d.IdStockTerminales == entidad.IdStockTerminales);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            StockProvincias asesor = await _repoStockProvincias.Crear(entidad);
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

        public async Task<StockProvincias> Editar(StockProvincias entidad)
        {
            StockProvincias Terminal_existe = await _repoStockProvincias.Obtener(u => u.IdStockTerminales == entidad.IdStockTerminales);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<StockProvincias> queryTerminal = await _repoStockProvincias.Consultar(u => u.IdStockTerminales == entidad.IdStockTerminales);
                StockProvincias Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoStockProvincias.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idStockProvincias)
        {
            try
            {
                StockProvincias Term_encontrado = await _repoStockProvincias.Obtener(u => u.IdStockTerminales == idStockProvincias);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<StockProvincias>> Lista()
        {
            IQueryable<StockProvincias> query = await _repoStockProvincias.Consultar();
            return query.ToList();
        }
    }
}
