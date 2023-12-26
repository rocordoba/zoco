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
    public class PlantillaAltaFisicaService: IPlantillaAltaFisicaService
    {
        private readonly IGenericRepository<PlantillaAltaFisica> _repositorioFisica;

        public PlantillaAltaFisicaService(IGenericRepository<PlantillaAltaFisica> repositorioFisica)
        {
            _repositorioFisica = repositorioFisica;
        }

        public async Task<PlantillaAltaFisica> Crear(PlantillaAltaFisica entidad)
        {
            PlantillaAltaFisica newProspecto = await _repositorioFisica.Obtener(d => d.IdPlantAltaFis == entidad.IdPlantAltaFis);

            if (newProspecto != null)
                throw new TaskCanceledException("La plantilla ya existe!");


            PlantillaAltaFisica Prospecto = await _repositorioFisica.Crear(entidad);
            try
            {
                if (Prospecto.IdPlantAltaFis == 0)
                    throw new TaskCanceledException("No se puede crear la plantilla");

                return Prospecto;
            }

            catch (Exception ex)
            {
                throw;
            };
        }

        public async Task<PlantillaAltaFisica> Editar(PlantillaAltaFisica entidad)
        {
            PlantillaAltaFisica Prospecto_existe = await _repositorioFisica.Obtener(u => u.IdPlantAltaFis == entidad.IdPlantAltaFis);

            if (Prospecto_existe != null)
                throw new TaskCanceledException("La plantilla no existe");

            try
            {
                IQueryable<PlantillaAltaFisica> queryProsp = await _repositorioFisica.Consultar(u => u.IdPlantAltaFis == entidad.IdPlantAltaFis);
                PlantillaAltaFisica prosp_editar = queryProsp.First();

                prosp_editar.NumTerminal = entidad.NumTerminal;
                prosp_editar.FechaPlantilla = entidad.FechaPlantilla;
                prosp_editar.DomCalle = entidad.DomCalle;
                prosp_editar.NumCalle = entidad.NumCalle;
                prosp_editar.Localidad = entidad.Localidad;
                prosp_editar.CodigoPostal = entidad.CodigoPostal;
                prosp_editar.AliadoApeNombre = entidad.AliadoApeNombre;
                prosp_editar.CuitDniAliado = entidad.CuitDniAliado;
                prosp_editar.ActividadLabProf = entidad.ActividadLabProf;
                prosp_editar.Provincia = entidad.Provincia;
                prosp_editar.Pais = entidad.Pais;
                prosp_editar.Nacionalidad = entidad.Nacionalidad;
                prosp_editar.FechaDeNac = entidad.FechaDeNac;
                prosp_editar.Celular = entidad.Celular;
                prosp_editar.Telefono = entidad.Telefono;
                prosp_editar.Correo = entidad.Correo;
                prosp_editar.NomFantasia = entidad.NomFantasia;
                prosp_editar.DomicilioFantasia = entidad.DomicilioFantasia;
                prosp_editar.CondFiscal = entidad.CondFiscal;
                prosp_editar.CondRentas = entidad.CondRentas;
                prosp_editar.Banco = entidad.Banco;
                prosp_editar.LocalidadFantasia = entidad.LocalidadFantasia;
                prosp_editar.CodPostalFant = entidad.CodPostalFant;
                prosp_editar.Banco = entidad.Banco;
                prosp_editar.TipoDeCta = entidad.TipoDeCta;
                prosp_editar.CbuCvu = entidad.CbuCvu;
                prosp_editar.AliasCbu = entidad.AliasCbu;
                prosp_editar.CuitrazSoc = entidad.CuitrazSoc;
                prosp_editar.TitularRazSoc = entidad.TitularRazSoc;
                prosp_editar.NumDeComercioActual = entidad.NumDeComercioActual;
                prosp_editar.NumDeComercioSolic = entidad.NumDeComercioSolic;
                prosp_editar.AltasLinkDePago = entidad.AltasLinkDePago;
                prosp_editar.NuevoAliado = entidad.NuevoAliado;
                prosp_editar.AgregaTerminal = entidad.AgregaTerminal;
                prosp_editar.RequiereNewNombre = entidad.RequiereNewNombre;
                prosp_editar.UrlImgAltaFirmada = entidad.UrlImgAltaFirmada;
                prosp_editar.UrlImgCuponInic = entidad.UrlImgCuponInic;
                prosp_editar.UrlImgConstanciaFiscal = entidad.UrlImgConstanciaFiscal;
                prosp_editar.UrlImgConstanciaBancaria = entidad.UrlImgConstanciaBancaria;
                prosp_editar.UrlImgDniTitular = entidad.UrlImgDniTitular;
                prosp_editar.UrlImgFormDeAutorizacion = entidad.UrlImgFormDeAutorizacion;
                //prosp_editar.IdEstado = entidad.IdEstado;

                bool respuesta = await _repositorioFisica.Editar(prosp_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la plantilla");


                return prosp_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdPlantillaAltaFisica)
        {
            try
            {
                PlantillaAltaFisica Prosp_encontrado = await _repositorioFisica.Obtener(u => u.IdPlantAltaFis == IdPlantillaAltaFisica);
                if (Prosp_encontrado == null)
                    throw new TaskCanceledException("La plnatilla no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PlantillaAltaFisica>> Lista()
        {
            IQueryable<PlantillaAltaFisica> query = await _repositorioFisica.Consultar();
            return query.ToList();
        }
    }
}
