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
    public class PlantillaModService: IPlantillaModService
    {
        private readonly IGenericRepository<PlantillaModificaciones> _repository;

        public PlantillaModService(IGenericRepository<PlantillaModificaciones> repositorio)
        {
            _repository = repositorio;
        }

        public async Task<PlantillaModificaciones> Crear(PlantillaModificaciones entidad)
        {
            PlantillaModificaciones newDesc = await _repository.Obtener(d => d.IdPlantMod == entidad.IdPlantMod);

            if (newDesc != null)
                throw new TaskCanceledException("La plantilla ya existe!");


            PlantillaModificaciones asesor = await _repository.Crear(entidad);
            try
            {
                if (asesor.IdPlantMod == 0)
                    throw new TaskCanceledException("No se puede crear la plantilla");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PlantillaModificaciones> Editar(PlantillaModificaciones entidad)
        {
            PlantillaModificaciones newDesc_existe = await _repository.Obtener(u => u.IdPlantMod == entidad.IdPlantMod);

            if (newDesc_existe != null)
                throw new TaskCanceledException("La plantilla no existe");

            try
            {

                IQueryable<PlantillaModificaciones> queryDesc = await _repository.Consultar(u => u.IdPlantMod == entidad.IdPlantMod);
                PlantillaModificaciones Desc_editar = queryDesc.First();


                Desc_editar.NombreFantComercio = entidad.NombreFantComercio;
                Desc_editar.NombreAsesor = entidad.NombreAsesor;
                Desc_editar.AliadoApeNombreFantasia = entidad.AliadoApeNombreFantasia;
                Desc_editar.DomNombreFantasia = entidad.DomNombreFantasia;
                Desc_editar.NumTerminal = entidad.NumTerminal;
                Desc_editar.MotivoFalla = entidad.MotivoFalla;
                Desc_editar.RegistraOpeNaranja = entidad.RegistraOpeNaranja;
                Desc_editar.RegistraCierreDeLote = entidad.RegistraCierreDeLote;
                Desc_editar.RegistraOperaciones = entidad.RegistraOperaciones;
                Desc_editar.NumTerminalAlta = entidad.NumTerminalAlta;
                Desc_editar.TipoModifTipoModif = entidad.TipoModifTipoModif;
                Desc_editar.NomFantasia = entidad.NomFantasia;
                Desc_editar.NumComercio = entidad.NumComercio;
                Desc_editar.DomFantasia = entidad.DomFantasia;
                Desc_editar.LocalidadFantasia = entidad.LocalidadFantasia;
                Desc_editar.CodPostalFant = entidad.CodPostalFant;
                Desc_editar.Banco = entidad.Banco;
                Desc_editar.TipoDeCta = entidad.TipoDeCta;
                Desc_editar.CbuCvu = entidad.CbuCvu;
                Desc_editar.AliasCbu = entidad.AliasCbu;
                Desc_editar.CuitrazSoc = entidad.CuitrazSoc;
                Desc_editar.Correo = entidad.Correo;
                Desc_editar.CondAfip = entidad.CondAfip;
                Desc_editar.CondRentas = entidad.CondRentas;
                Desc_editar.UrlImgFichaFirmada = entidad.UrlImgFichaFirmada;
                Desc_editar.UrlImgCuponInic = entidad.UrlImgCuponInic;
                Desc_editar.UrlImgConstanciaFiscal = entidad.UrlImgConstanciaFiscal;
                Desc_editar.UrlImgConstanciaBancaria = entidad.UrlImgConstanciaBancaria;
                Desc_editar.UrlImgDniTitular = entidad.UrlImgDniTitular;
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
                PlantillaModificaciones Desc_encontrado = await _repository.Obtener(u => u.IdPlantMod == IdUsuario);

                if (Desc_encontrado == null)
                    throw new TaskCanceledException("El descuento no existe");

                return true;
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<PlantillaModificaciones>> Lista()
        {
            IQueryable<PlantillaModificaciones> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
