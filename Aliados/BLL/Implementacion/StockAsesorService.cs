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
    public class StockAsesorService : IStockAsesorService
    {
        private readonly IGenericRepository<StockAsesor> _repoStockAsesor;

        public StockAsesorService(IGenericRepository<StockAsesor> repoStockAsesor)
        {
            _repoStockAsesor = repoStockAsesor;
        }

        public async Task<StockAsesor> Crear(StockAsesor entidad)
        {
            StockAsesor newAsesor = await _repoStockAsesor.Obtener(d => d.IdStockTerminales == entidad.IdStockTerminales);

            if (newAsesor != null)
                throw new TaskCanceledException("El asesor ya existe!");


            StockAsesor asesor = await _repoStockAsesor.Crear(entidad);
            try
            {
                if (asesor.IdStockTerminales == 0)
                    throw new TaskCanceledException("No se puede crear el asesor");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StockAsesor> Editar(StockAsesor entidad)
        {
            StockAsesor asesor_existe = await _repoStockAsesor.Obtener(u => u.IdStockTerminales == entidad.IdStockTerminales);

            if (asesor_existe != null)
                throw new TaskCanceledException("El asesor no existe");

            try
            {

                IQueryable<StockAsesor> queryUsuario = await _repoStockAsesor.Consultar(u => u.IdStockTerminales == entidad.IdStockTerminales);
                StockAsesor asesor_editar = queryUsuario.First();


                bool respuesta = await _repoStockAsesor.Editar(asesor_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el asesor");

                return asesor_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idStockAsesor)
        {
            try
            {
                StockAsesor Dot_encontrado = await _repoStockAsesor.Obtener(u => u.IdStockTerminales == idStockAsesor);

                if (Dot_encontrado == null)
                    throw new TaskCanceledException("El asesor no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<StockAsesor>> Lista()
        {
            IQueryable<StockAsesor> query = await _repoStockAsesor.Consultar();
            return query.ToList();
        }
    }
}
