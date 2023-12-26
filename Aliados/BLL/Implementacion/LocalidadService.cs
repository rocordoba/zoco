using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;

namespace BLL.Implementacion
{
    public class LocalidadService: ILocalidadService
    {
        private readonly IGenericRepository<Localidad> _repository;

        public LocalidadService(IGenericRepository<Localidad> repository)
        {
            _repository = repository;
        }

        public async Task<Localidad> Crear(Localidad entidad)
        {

            Localidad newLocalidad = await _repository.Obtener(d => d.IdLocalidad == entidad.IdLocalidad);

            if (newLocalidad != null)
                throw new TaskCanceledException("La localidad ya existe!");


            Localidad local = await _repository.Crear(entidad);
            try
            {
                if (local.IdLocalidad == 0)
                    throw new TaskCanceledException("No se puede crear la localidad");


                return local;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Localidad> Editar(Localidad entidad)
        {
            Localidad local_existe = await _repository.Obtener(u => u.IdLocalidad == entidad.IdLocalidad);

            if (local_existe != null)
                throw new TaskCanceledException("La localidad no existe");

            try
            {

                IQueryable<Localidad> queryLocal = await _repository.Consultar(u => u.IdLocalidad == entidad.IdLocalidad);
                Localidad local_editar = queryLocal.First();

                local_editar.NombreLocalidad = entidad.NombreLocalidad;
                local_editar.CodigoPostal = entidad.CodigoPostal;
                local_editar.Provincia = entidad.Provincia;


                bool respuesta = await _repository.Editar(local_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la localidad");


                return local_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdLocalidad)
        {
            try
            {
                Localidad Loc_encontrado = await _repository.Obtener(u => u.IdLocalidad == IdLocalidad);

                if (Loc_encontrado == null)
                    throw new TaskCanceledException("La localidad no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Localidad>> Lista()
        {
            IQueryable<Localidad> query = await _repository.Consultar();
            return query.ToList();
        }

        public async Task<Localidad> obtenerPorProvincia(int idProv)
        {
            Localidad loc_existe = await _repository.Obtener(u => u.Provincia == idProv);
            return loc_existe;
        }
    }
}
