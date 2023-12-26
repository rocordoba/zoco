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
    public class RegSessionesNosService : IRegSessionesNosService
    {
        private readonly IGenericRepository<RegSessionesNos> _repository;

        public RegSessionesNosService(IGenericRepository<RegSessionesNos> repository)
        {
            _repository = repository;
        }

        public async Task<RegSessionesNos> Crear(RegSessionesNos entidad)
        {

            RegSessionesNos usuario_creado = await _repository.Crear(entidad);
            try
            {
                if (usuario_creado.IdRegistros == 0)
                    throw new TaskCanceledException("No se pudo crear el registro");

                IQueryable<RegSessionesNos> query = await _repository.Consultar(u => u.IdRegistros == usuario_creado.IdRegistros);
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

        public async Task<RegSessionesNos> Editar(RegSessionesNos entidad)
        {

            RegSessionesNos asesor_existe = await _repository.Obtener(u => u.IdRegistros == entidad.IdRegistros);

            if (asesor_existe != null)
                throw new TaskCanceledException("El registro no existe");

            try
            {

                IQueryable<RegSessionesNos> queryUsuario = await _repository.Consultar(u => u.IdRegistros == entidad.IdRegistros);
                RegSessionesNos asesor_editar = queryUsuario.First();

                DateTime horaActual = DateTime.Now;

                asesor_editar.Estado = 0;
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

        public async Task<List<RegSessionesNos>> Lista()
        {
            IQueryable<RegSessionesNos> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
