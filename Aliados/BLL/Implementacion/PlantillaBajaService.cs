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
    public class PlantillaBajaService: IPlantillaBajaService
    {
        private readonly IGenericRepository<PlantillaBaja> _repository;

        public PlantillaBajaService(IGenericRepository<PlantillaBaja> repopo)
        {
            _repository = repopo;
        }


        public async Task<PlantillaBaja> Crear(PlantillaBaja entidad)
        {
            PlantillaBaja newDesc = await _repository.Obtener(d => d.IdPlantBaja == entidad.IdPlantBaja);

            if (newDesc != null)
                throw new TaskCanceledException("La Plantilla ya existe!");


            PlantillaBaja asesor = await _repository.Crear(entidad);
            try
            {
                if (asesor.IdPlantBaja == 0)
                    throw new TaskCanceledException("No se puede crear la plantilla");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PlantillaBaja> Editar(PlantillaBaja entidad)
        {
            PlantillaBaja newDesc_existe = await _repository.Obtener(u => u.IdPlantBaja == entidad.IdPlantBaja);

            if (newDesc_existe != null)
                throw new TaskCanceledException("La plantilla no existe");

            try
            {

                IQueryable<PlantillaBaja> queryDesc = await _repository.Consultar(u => u.IdPlantBaja == entidad.IdPlantBaja);
                PlantillaBaja Desc_editar = queryDesc.First();

                Desc_editar.NumTerminal = entidad.NumTerminal;
                Desc_editar.FechaPlantBaja = entidad.FechaPlantBaja;
                Desc_editar.AliadoApeNombreAsesor = entidad.AliadoApeNombreAsesor;
                Desc_editar.Observación = entidad.Observación;
                Desc_editar.AliadoApeNombreFantasia = entidad.AliadoApeNombreFantasia;
                Desc_editar.RegistraOpeNaranja = entidad.RegistraOpeNaranja;
                Desc_editar.RegistraCierreDeLote = entidad.RegistraCierreDeLote;
                Desc_editar.RegistraOperaciones = entidad.RegistraOperaciones;
                Desc_editar.UrlImgCierreTerm = entidad.UrlImgCierreTerm;
                Desc_editar.UrlImgBajaFirmada = entidad.UrlImgBajaFirmada;
                //Desc_editar.IdEstado = entidad.IdEstado;

                bool respuesta = await _repository.Editar(Desc_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la plantilla");


                return Desc_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdUsuario)
        {
            try
            {
                PlantillaBaja Desc_encontrado = await _repository.Obtener(u => u.IdPlantBaja == IdUsuario);

                if (Desc_encontrado == null)
                    throw new TaskCanceledException("La plantilla no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PlantillaBaja>> Lista()
        {
            IQueryable<PlantillaBaja> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
