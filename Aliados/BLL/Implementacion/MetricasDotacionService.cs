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
    public class MetricasDotacionService : IMetricasDotacionService
    {

        private readonly IGenericRepository<MetricasDotacion> _repoMetricasDotacion;

        public MetricasDotacionService(IGenericRepository<MetricasDotacion> repoMetricasDotacion)
        {
            _repoMetricasDotacion = repoMetricasDotacion;
        }

        public async Task<MetricasDotacion> Crear(MetricasDotacion entidad)
        {
            MetricasDotacion newTerminal = await _repoMetricasDotacion.Obtener(d => d.IdMetrica == entidad.IdMetrica);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            MetricasDotacion asesor = await _repoMetricasDotacion.Crear(entidad);
            try
            {
                if (asesor.IdMetrica == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MetricasDotacion> Editar(MetricasDotacion entidad)
        {
            MetricasDotacion Terminal_existe = await _repoMetricasDotacion.Obtener(u => u.IdMetrica == entidad.IdMetrica);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<MetricasDotacion> queryTerminal = await _repoMetricasDotacion.Consultar(u => u.IdMetrica == entidad.IdMetrica);
                MetricasDotacion Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoMetricasDotacion.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idMetricasDotacion)
        {
            try
            {
                MetricasDotacion Term_encontrado = await _repoMetricasDotacion.Obtener(u => u.IdMetrica == idMetricasDotacion);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<MetricasDotacion>> Lista()
        {
            IQueryable<MetricasDotacion> query = await _repoMetricasDotacion.Consultar();
            return query.ToList();
        }
    }
}
