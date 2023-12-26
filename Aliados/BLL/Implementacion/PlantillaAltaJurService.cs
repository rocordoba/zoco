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
    public class PlantillaAltaJurService: IPlantillaAltaJurService
    {
        private readonly IGenericRepository<PlantillaAltaJur> _reposytori;

        public PlantillaAltaJurService(IGenericRepository<PlantillaAltaJur> reposytori)
        {
            _reposytori = reposytori;
        }

        public async Task<PlantillaAltaJur> Crear(PlantillaAltaJur entidad)
        {
            PlantillaAltaJur newProspecto = await _reposytori.Obtener(d => d.IdPlantAlta == entidad.IdPlantAlta);

            if (newProspecto != null)
                throw new TaskCanceledException("El prospecto ya existe!");


            PlantillaAltaJur Prospecto = await _reposytori.Crear(entidad);
            try
            {
                if (Prospecto.IdPlantAlta == 0)
                    throw new TaskCanceledException("No se puede crear el prospecto");

                return Prospecto;
            }

            catch (Exception ex)
            {
                throw;
            };
        }

        public async Task<PlantillaAltaJur> Editar(PlantillaAltaJur entidad)
        {
            PlantillaAltaJur Prospecto_existe = await _reposytori.Obtener(u => u.IdPlantAlta == entidad.IdPlantAlta);

            if (Prospecto_existe != null)
                throw new TaskCanceledException("El prospecto no existe");

            try
            {

                IQueryable<PlantillaAltaJur> queryProsp = await _reposytori.Consultar(u => u.IdPlantAlta == entidad.IdPlantAlta);
                PlantillaAltaJur prosp_editar = queryProsp.First();

                prosp_editar.NumTerminal = entidad.NumTerminal;
                prosp_editar.FechaPlantilla = entidad.FechaPlantilla;
                prosp_editar.RazSoc = entidad.RazSoc;
                prosp_editar.CuitCdiAliado = entidad.CuitCdiAliado;
                prosp_editar.ActividadAli = entidad.ActividadAli;
                prosp_editar.DomCalle = entidad.DomCalle;
                prosp_editar.NumCalle = entidad.NumCalle;
                prosp_editar.Localidad = entidad.Localidad;
                prosp_editar.CodigoPostal = entidad.CodigoPostal;
                prosp_editar.NumFantasiaTelSede = entidad.NumFantasiaTelSede;
                prosp_editar.CorreoAli = entidad.CorreoAli;
                prosp_editar.NomFantasia = entidad.NomFantasia;
                prosp_editar.DomFantasia = entidad.DomFantasia;
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
                prosp_editar.IdEstado = entidad.IdEstado;

                bool respuesta = await _reposytori.Editar(prosp_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el prospecto");


                return prosp_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdPlantillaAltaJur)
        {
            try
            {
                PlantillaAltaJur Prosp_encontrado = await _reposytori.Obtener(u => u.IdPlantAlta == IdPlantillaAltaJur);
                if (Prosp_encontrado == null)
                    throw new TaskCanceledException("El Prospecto no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PlantillaAltaJur>> Lista()
        {
            IQueryable<PlantillaAltaJur> query = await _reposytori.Consultar();
            return query.ToList();
        }
    }
}
