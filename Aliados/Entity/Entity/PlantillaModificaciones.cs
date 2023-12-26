using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class PlantillaModificaciones
    {
        public int IdPlantMod { get; set; }
        public string? NombreFantComercio { get; set; }
        public string? NombreAsesor { get; set; }
        public string? AliadoApeNombreFantasia { get; set; }
        public string? DomNombreFantasia { get; set; }
        public int? NumTerminal { get; set; }
        public string? MotivoFalla { get; set; }
        public string? RegistraOpeNaranja { get; set; }
        public string? RegistraCierreDeLote { get; set; }
        public string? RegistraOperaciones { get; set; }
        public string? NumTerminalAlta { get; set; }
        public string? TipoModifTipoModif { get; set; }
        public string? NomFantasia { get; set; }
        public int? NumComercio { get; set; }
        public string? DomFantasia { get; set; }
        public string? LocalidadFantasia { get; set; }
        public string? CodPostalFant { get; set; }
        public string? Banco { get; set; }
        public string? TipoDeCta { get; set; }
        public string? CbuCvu { get; set; }
        public string? AliasCbu { get; set; }
        public string? CuitrazSoc { get; set; }
        public string? Correo { get; set; }
        public string? CondAfip { get; set; }
        public string? CondRentas { get; set; }
        public string? UrlImgFichaFirmada { get; set; }
        public string? UrlImgCuponInic { get; set; }
        public string? UrlImgConstanciaFiscal { get; set; }
        public string? UrlImgConstanciaBancaria { get; set; }
        public string? UrlImgDniTitular { get; set; }
        public int? EstadoPlantilla { get; set; }

        public virtual EstadoPlantilla? EstadoPlantillaNavigation { get; set; }
    }
}
