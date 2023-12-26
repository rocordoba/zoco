using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Provincium
    {
        public Provincium()
        {
            DotacionProvinciaDosNavigations = new HashSet<Dotacion>();
            DotacionProvinciaNavigations = new HashSet<Dotacion>();
            FacturacionDotacions = new HashSet<FacturacionDotacion>();
            FantasiaComercios = new HashSet<FantasiaComercio>();
            Localidads = new HashSet<Localidad>();
            MovimientoTermDestinoNavigations = new HashSet<MovimientoTerm>();
            MovimientoTermOrigenNavigations = new HashSet<MovimientoTerm>();
            Prospectos = new HashSet<Prospecto>();
            StockProvincia = new HashSet<StockProvincia>();
            Terminals = new HashSet<Terminal>();
            Visita = new HashSet<Visitum>();
        }

        public int IdProvincia { get; set; }
        public string? NombreProvincia { get; set; }
        public string? Estado { get; set; }
        public int? NivelAbm { get; set; }
        public double? AlicuotaNew { get; set; }
        public double? IndiceNew { get; set; }
        public int? SiActivo { get; set; }
        public int? Asesores { get; set; }
        public int? Disponible { get; set; }
        public double? PromedioDeActivacion { get; set; }
        public int? Nivel { get; set; }

        public virtual ICollection<Dotacion> DotacionProvinciaDosNavigations { get; set; }
        public virtual ICollection<Dotacion> DotacionProvinciaNavigations { get; set; }
        public virtual ICollection<FacturacionDotacion> FacturacionDotacions { get; set; }
        public virtual ICollection<FantasiaComercio> FantasiaComercios { get; set; }
        public virtual ICollection<Localidad> Localidads { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermDestinoNavigations { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermOrigenNavigations { get; set; }
        public virtual ICollection<Prospecto> Prospectos { get; set; }
        public virtual ICollection<StockProvincia> StockProvincia { get; set; }
        public virtual ICollection<Terminal> Terminals { get; set; }
        public virtual ICollection<Visitum> Visita { get; set; }
    }
}
