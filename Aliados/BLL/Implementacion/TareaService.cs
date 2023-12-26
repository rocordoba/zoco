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
    public class TareaService : ITareaService
    {
        private readonly IGenericRepository<Tarea> _repoTarea;

        public TareaService(IGenericRepository<Tarea> repoTarea)
        {
            _repoTarea = repoTarea;
        }

        public async Task<Tarea> Crear(Tarea entidad)
        {
            Tarea newAsesor = await _repoTarea.Obtener(d => d.IdTarea == entidad.IdTarea);

            if (newAsesor != null)
                throw new TaskCanceledException("El asesor ya existe!");


            Tarea asesor = await _repoTarea.Crear(entidad);
            try
            {
                if (asesor.IdTarea == 0)
                    throw new TaskCanceledException("No se puede crear el asesor");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tarea> Editar(Tarea entidad)
        {
            Tarea asesor_existe = await _repoTarea.Obtener(u => u.IdTarea == entidad.IdTarea);

            if (asesor_existe != null)
                throw new TaskCanceledException("La Tarea no existe");

            try
            {

                IQueryable<Tarea> queryUsuario = await _repoTarea.Consultar(u => u.IdTarea == entidad.IdTarea);
                Tarea asesor_editar = queryUsuario.First();


                bool respuesta = await _repoTarea.Editar(asesor_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la tarea");

                return asesor_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idTarea)
        {
            try
            {
                Tarea Dot_encontrado = await _repoTarea.Obtener(u => u.IdTarea == idTarea);

                if (Dot_encontrado == null)
                    throw new TaskCanceledException("El asesor no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Tarea>> Lista()
        {
            IQueryable<Tarea> query = await _repoTarea.Consultar();
            return query.ToList();
        }
    }
}
