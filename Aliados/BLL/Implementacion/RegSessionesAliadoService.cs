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
    public class RegSessionesAliadoService : IRegSessionesAliadoService
    {

        private readonly IGenericRepository<RegSessionesAliado> _repository;

        public RegSessionesAliadoService(IGenericRepository<RegSessionesAliado> repository)
        {
            _repository = repository;
        }

        public async Task<RegSessionesAliado> Crear(RegSessionesAliado entidad)
        {
            RegSessionesAliado usuario_creado = await _repository.Crear(entidad);
            try
            {
                //tenemos que traer idUsuario de hhtttp
                //PONER ACTIVO EN 1,
                //EN ACCESO MODIFICA SI REG ESTA EN UNO, NO SE PUEDE INICIAR, ESTA LOQUEADO EN OTRO DISPOSITIVO!
                //CREAR cuando se inciia sess
                //EDITAR cuando se CIERRA SESSS

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

        public async Task<RegSessionesAliado> Editar(RegSessionesAliado entidad)
        {

            RegSessionesAliado asesor_existe = await _repository.Obtener(u => u.IdRegistros == entidad.IdRegistros);

            if (asesor_existe != null)
                throw new TaskCanceledException("El registro no existe");

            try
            {

                IQueryable<RegSessionesAliado> queryUsuario = await _repository.Consultar(u => u.IdRegistros == entidad.IdRegistros);
                RegSessionesAliado asesor_editar = queryUsuario.First();

                asesor_editar.Estado = 0;
                asesor_editar.FechaFin = entidad.FechaFin;


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

        public async Task<List<RegSessionesAliado>> Lista()
        {
            IQueryable<RegSessionesAliado> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
