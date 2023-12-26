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
    public class HistCorreoAliadoService : IHistCorreoAliadoService
    {
        private readonly IGenericRepository<HistCorreoAliado> _repoHistCorrAl;

        public HistCorreoAliadoService(IGenericRepository<HistCorreoAliado> repoActividadAfip)
        {
            _repoHistCorrAl = repoActividadAfip;
        }

        public async Task<HistCorreoAliado> Crear(HistCorreoAliado entidad)
        {
            HistCorreoAliado newTerminal = await _repoHistCorrAl.Obtener(d => d.IdHistCorreo == entidad.IdHistCorreo);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            HistCorreoAliado asesor = await _repoHistCorrAl.Crear(entidad);
            try
            {
                if (asesor.IdHistCorreo  == 0)
                    throw new TaskCanceledException("No se puede crear el movimiento");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<HistCorreoAliado> Editar(HistCorreoAliado entidad)
        {
            HistCorreoAliado Terminal_existe = await _repoHistCorrAl.Obtener(u => u.IdHistCorreo == entidad.IdHistCorreo);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<HistCorreoAliado> queryTerminal = await _repoHistCorrAl.Consultar(u => u.IdHistCorreo == entidad.IdHistCorreo);
                HistCorreoAliado Terminal_editar = queryTerminal.First();

                Terminal_editar.TipoDescripcion = entidad.TipoDescripcion;
                Terminal_editar.Fecha = entidad.Fecha;
                Terminal_editar.UsuarioAliado = entidad.UsuarioAliado;


                bool respuesta = await _repoHistCorrAl.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el movimiento");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdHistCorreoAliado)
        {
            try
            {
                HistCorreoAliado Term_encontrado = await _repoHistCorrAl.Obtener(u => u.IdHistCorreo == IdHistCorreoAliado);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El movimiento no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<HistCorreoAliado>> Lista()
        {
            IQueryable<HistCorreoAliado> query = await _repoHistCorrAl.Consultar();
            return query.ToList();
        }
    }
}
