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
    public class FacturacioDotacionService : IFacturacioDotacionService
    {

        private readonly IGenericRepository<FacturacionDotacion> _repoFacturacioDotacion;

        public FacturacioDotacionService(IGenericRepository<FacturacionDotacion> repoFacturacioDotacion)
        {
            _repoFacturacioDotacion = repoFacturacioDotacion;
        }

        public async Task<FacturacionDotacion> Crear(FacturacionDotacion entidad)
        {
            FacturacionDotacion newTerminal = await _repoFacturacioDotacion.Obtener(d => d.IdFact == entidad.IdFact);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            FacturacionDotacion asesor = await _repoFacturacioDotacion.Crear(entidad);
            try
            {
                if (asesor.IdFact == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FacturacionDotacion> Editar(FacturacionDotacion entidad)
        {
            FacturacionDotacion Terminal_existe = await _repoFacturacioDotacion.Obtener(u => u.IdFact == entidad.IdFact);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<FacturacionDotacion> queryTerminal = await _repoFacturacioDotacion.Consultar(u => u.IdFact == entidad.IdFact);
                FacturacionDotacion Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoFacturacioDotacion.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdFacturacioDotacion)
        {
            try
            {
                FacturacionDotacion Term_encontrado = await _repoFacturacioDotacion.Obtener(u => u.IdFact == IdFacturacioDotacion);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<FacturacionDotacion>> Lista()
        {
            IQueryable<FacturacionDotacion> query = await _repoFacturacioDotacion.Consultar();
            return query.ToList();
        }
    }
}
