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
    public class MovimientoTermService : IMovimientoTermService
    {

        private readonly IGenericRepository<MovimientoTerm> _repository;

        public MovimientoTermService(IGenericRepository<MovimientoTerm> repository)
        {
            _repository = repository;
        }

        public async Task<MovimientoTerm> Crear(MovimientoTerm entidad)
        {
            MovimientoTerm newDesc = await _repository.Obtener(d => d.IdMovimiento == entidad.IdMovimiento);

            if (newDesc != null)
                throw new TaskCanceledException("El descuento ya existe!");


            MovimientoTerm asesor = await _repository.Crear(entidad);
            try
            {
                if (asesor.IdMovimiento == 0)
                    throw new TaskCanceledException("No se puede crear el descuento");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MovimientoTerm> Editar(MovimientoTerm entidad)
        {
            MovimientoTerm newDesc_existe = await _repository.Obtener(u => u.IdMovimiento == entidad.IdMovimiento);

            if (newDesc_existe != null)
                throw new TaskCanceledException("El descuento no existe");

            try
            {

                IQueryable<MovimientoTerm> queryDesc = await _repository.Consultar(u => u.IdMovimiento == entidad.IdMovimiento);
                MovimientoTerm Desc_editar = queryDesc.First();


                Desc_editar.Fantasia = entidad.Fantasia;
                Desc_editar.Estado = entidad.Estado;
                //Desc_editar.TipoDeAlta = entidad.TipoDeAlta;
                //Desc_editar.Activacion = entidad.Activacion;
                Desc_editar.EstadoMovimiento = entidad.EstadoMovimiento;
                Desc_editar.Terminal = entidad.Terminal;
                Desc_editar.AsesorAntes = entidad.AsesorAntes;
                Desc_editar.AsesorActual = entidad.AsesorActual;
                Desc_editar.ProgramacionBaja = entidad.ProgramacionBaja;
                Desc_editar.DiasParaAlta = entidad.DiasParaAlta;
                Desc_editar.FechaInicio = entidad.FechaInicio;
                Desc_editar.FechaFin = entidad.FechaFin;


                bool respuesta = await _repository.Editar(Desc_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Desc_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdMovimientos)
        {
            try
            {
                MovimientoTerm Dot_encontrado = await _repository.Obtener(u => u.IdMovimiento == IdMovimientos);

                if (Dot_encontrado == null)
                    throw new TaskCanceledException("El movimiento no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<MovimientoTerm>> Lista()
        {
            IQueryable<MovimientoTerm> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
