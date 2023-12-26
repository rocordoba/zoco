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
    public class RegSessionesDotacionService : IRegSessionesDotacionService
    {
        private readonly IGenericRepository<RegSessionesDotacion> _repository;

        public RegSessionesDotacionService(IGenericRepository<RegSessionesDotacion> repository)
        {
            _repository = repository;
        }

        public async Task<RegSessionesDotacion> Crear(RegSessionesDotacion entidad)
        {
            RegSessionesDotacion usuario_creado = await _repository.Crear(entidad);
            try
            {
                if (usuario_creado.IdRegistros == 0)
                    throw new TaskCanceledException("No se pudo crear el registro");

                IQueryable<RegSessionesDotacion> query = await _repository.Consultar(u => u.IdRegistros == usuario_creado.IdRegistros);
                usuario_creado = query.First();

                DateTime horaActual = DateTime.Now;
                usuario_creado.Estado = 1;
                usuario_creado.FechaInicio = horaActual;

                return usuario_creado;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RegSessionesDotacion> Editar(RegSessionesDotacion entidad)
        {
            RegSessionesDotacion asesor_existe = await _repository.Obtener(u => u.IdRegistros == entidad.IdRegistros);

            if (asesor_existe != null)
                throw new TaskCanceledException("El registro no existe");

            try
            {

                IQueryable<RegSessionesDotacion> queryUsuario = await _repository.Consultar(u => u.IdRegistros == entidad.IdRegistros);
                RegSessionesDotacion asesor_editar = queryUsuario.First();

                DateTime horaActual = DateTime.Now; 

                asesor_editar.Estado = entidad.Estado;
                asesor_editar.FechaFin = horaActual;



                bool respuesta = await _repository.Editar(asesor_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el registro");


                return asesor_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RegSessionesDotacion>> Lista()
        {
            IQueryable<RegSessionesDotacion> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
