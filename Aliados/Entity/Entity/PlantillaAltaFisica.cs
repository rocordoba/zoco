using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class PlantillaAltaFisica
    {
        public int IdPlantAltaFis { get; set; }
        public int? NumTerminal { get; set; }
        public DateTime? FechaPlantilla { get; set; }
        public string? AliadoApeNombre { get; set; }
        public string? CuitDniAliado { get; set; }
        public string? ActividadLabProf { get; set; }
        public string? DomCalle { get; set; }
        public string? NumCalle { get; set; }
        public string? Localidad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? FechaDeNac { get; set; }
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? NomFantasia { get; set; }
        public string? DomicilioFantasia { get; set; }
        public string? LocalidadFantasia { get; set; }
        public string? CodPostalFant { get; set; }
        public string? CondFiscal { get; set; }
        public string? CondRentas { get; set; }
        public string? Banco { get; set; }
        public string? TipoDeCta { get; set; }
        public string? CbuCvu { get; set; }
        public string? AliasCbu { get; set; }
        public string? CuitrazSoc { get; set; }
        public string? TitularRazSoc { get; set; }
        public string? NumDeComercioActual { get; set; }
        public string? NumDeComercioSolic { get; set; }
        public string? AltasLinkDePago { get; set; }
        public string? NuevoAliado { get; set; }
        public string? AgregaTerminal { get; set; }
        public string? RequiereNewNombre { get; set; }
        public string? UrlImgAltaFirmada { get; set; }
        public string? UrlImgCuponInic { get; set; }
        public string? UrlImgConstanciaFiscal { get; set; }
        public string? UrlImgConstanciaBancaria { get; set; }
        public string? UrlImgDniTitular { get; set; }
        public string? UrlImgFormDeAutorizacion { get; set; }
        public int? EstadoPlantilla { get; set; }
        public int? TipoDeAlta { get; set; }

        public virtual EstadoPlantilla? EstadoPlantillaNavigation { get; set; }
        public virtual TipoDeAltum? TipoDeAltaNavigation { get; set; }
    }
}
