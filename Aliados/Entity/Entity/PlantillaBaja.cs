using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class PlantillaBaja
    {
        public int IdPlantBaja { get; set; }
        public int? NumTerminal { get; set; }
        public DateTime? FechaPlantBaja { get; set; }
        public string? AliadoApeNombreAsesor { get; set; }
        public string? Observación { get; set; }
        public string? AliadoApeNombreFantasia { get; set; }
        public string? RegistraOpeNaranja { get; set; }
        public string? RegistraCierreDeLote { get; set; }
        public string? RegistraOperaciones { get; set; }
        public string? UrlImgCierreTerm { get; set; }
        public string? UrlImgBajaFirmada { get; set; }
        public int? EstadoPlantilla { get; set; }
        public int? TipoDeBaja { get; set; }

        public virtual EstadoPlantilla? EstadoPlantillaNavigation { get; set; }
        public virtual TipoBaja? TipoDeBajaNavigation { get; set; }
    }
}
