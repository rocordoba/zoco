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
    public class HistCorreoDotacionService : IHistCorreoDotacionService
    {
        private readonly IGenericRepository<HistCorreoDotacion> _repoHistCorreoDotacion;

        public HistCorreoDotacionService(IGenericRepository<HistCorreoDotacion> repoHistCorreoDotacion)
        {
            _repoHistCorreoDotacion = repoHistCorreoDotacion;
        }

        public async Task<HistCorreoDotacion> Crear(HistCorreoDotacion entidad)
        {
            HistCorreoDotacion newTerminal = await _repoHistCorreoDotacion.Obtener(d => d.IdHistCorreo == entidad.IdHistCorreo);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            HistCorreoDotacion asesor = await _repoHistCorreoDotacion.Crear(entidad);
            try
            {
                if (asesor.IdHistCorreo == 0)
                    throw new TaskCanceledException("No se puede crear el movimiento");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<HistCorreoDotacion> Editar(HistCorreoDotacion entidad)
        {
            HistCorreoDotacion Terminal_existe = await _repoHistCorreoDotacion.Obtener(u => u.IdHistCorreo == entidad.IdHistCorreo);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<HistCorreoDotacion> queryTerminal = await _repoHistCorreoDotacion.Consultar(u => u.IdHistCorreo == entidad.IdHistCorreo);
                HistCorreoDotacion Terminal_editar = queryTerminal.First();


                Terminal_editar.TipoDescripcion = entidad.TipoDescripcion;
                Terminal_editar.Fecha = entidad.Fecha;
                Terminal_editar.UsuarioDotacion = entidad.UsuarioDotacion;

                bool respuesta = await _repoHistCorreoDotacion.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el movimiento");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdHistCorreoDotacion)
        {
            try
            {
                HistCorreoDotacion Term_encontrado = await _repoHistCorreoDotacion.Obtener(u => u.IdHistCorreo == IdHistCorreoDotacion);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El movimiento no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<HistCorreoDotacion>> Lista()
        {
            IQueryable<HistCorreoDotacion> query = await _repoHistCorreoDotacion.Consultar();
            return query.ToList();
        }
    }
}
