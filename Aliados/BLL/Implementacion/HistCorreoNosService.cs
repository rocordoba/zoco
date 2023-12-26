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
    public class HistCorreoNosService : IHistCorreoNosService
    {
        private readonly IGenericRepository<HistCorreoNosot> _repoHistCorrNos;

        public HistCorreoNosService(IGenericRepository<HistCorreoNosot> repoHistCorrAl)
        {
            _repoHistCorrNos = repoHistCorrAl;
        }

        public async Task<HistCorreoNosot> Crear(HistCorreoNosot entidad)
        {
            HistCorreoNosot newTerminal = await _repoHistCorrNos.Obtener(d => d.IdHistCorreo == entidad.IdHistCorreo);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            HistCorreoNosot asesor = await _repoHistCorrNos.Crear(entidad);
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

        public async Task<HistCorreoNosot> Editar(HistCorreoNosot entidad)
        {
            HistCorreoNosot Terminal_existe = await _repoHistCorrNos.Obtener(u => u.IdHistCorreo == entidad.IdHistCorreo);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<HistCorreoNosot> queryTerminal = await _repoHistCorrNos.Consultar(u => u.IdHistCorreo == entidad.IdHistCorreo);
                HistCorreoNosot Terminal_editar = queryTerminal.First();


                Terminal_editar.TipoDescripcion = entidad.TipoDescripcion;
                Terminal_editar.Fecha = entidad.Fecha;
                Terminal_editar.UsuarioNos = entidad.UsuarioNos;

                bool respuesta = await _repoHistCorrNos.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el movimiento");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdHistCorreoNos)
        {
            try
            {
                HistCorreoNosot Term_encontrado = await _repoHistCorrNos.Obtener(u => u.IdHistCorreo == IdHistCorreoNos);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El movimiento no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<HistCorreoNosot>> Lista()
        {
            IQueryable<HistCorreoNosot> query = await _repoHistCorrNos.Consultar();
            return query.ToList();
        }
    }
}
