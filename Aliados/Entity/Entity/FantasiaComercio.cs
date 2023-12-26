using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class FantasiaComercio
    {
        public FantasiaComercio()
        {
            Documentacions = new HashSet<Documentacion>();
            MovimientoTermFantasiaAntesNavigations = new HashSet<MovimientoTerm>();
            MovimientoTermFantasiaNavigations = new HashSet<MovimientoTerm>();
            Terminals = new HashSet<Terminal>();
            TicketTerminals = new HashSet<TicketTerminal>();
        }

        public int IdFantasiaCom { get; set; }
        public string? NombreFantasia { get; set; }
        public string? DomicilioFiscal { get; set; }
        public double? Telefono { get; set; }
        public string? LinkDePago { get; set; }
        public int? EstadoAfip { get; set; }
        public int? EstadoRentas { get; set; }
        public int? Provincia { get; set; }
        public int? RubroUno { get; set; }
        public int? RubroDos { get; set; }
        public int? ActividadAfip { get; set; }
        public int? ActividadAfipDos { get; set; }
        public int? RazSocial { get; set; }
        public string? ActividadRentas { get; set; }
        public string? ActividadRentasDos { get; set; }
        public string? AltaAhoraDoce { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? DiasParaAlta { get; set; }
        public double? NumDeComercio { get; set; }
        public int? NumLocal { get; set; }
        public string? ApellidoNombreTitular { get; set; }
        public double? DniCuil { get; set; }
        public string? Domicilio { get; set; }
        public string? NumCalle { get; set; }
        public string? ActividadLaboral { get; set; }
        public DateTime? FechaDeNac { get; set; }
        public string? Correo { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Pais { get; set; }
        public double? Celular { get; set; }

        public virtual ActividadAfip? ActividadAfipDosNavigation { get; set; }
        public virtual ActividadAfip? ActividadAfipNavigation { get; set; }
        public virtual EstadoAfip? EstadoAfipNavigation { get; set; }
        public virtual EstadoRentum? EstadoRentasNavigation { get; set; }
        public virtual Provincium? ProvinciaNavigation { get; set; }
        public virtual RazonSocial? RazSocialNavigation { get; set; }
        public virtual Rubro? RubroDosNavigation { get; set; }
        public virtual Rubro? RubroUnoNavigation { get; set; }
        public virtual ICollection<Documentacion> Documentacions { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermFantasiaAntesNavigations { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermFantasiaNavigations { get; set; }
        public virtual ICollection<Terminal> Terminals { get; set; }
        public virtual ICollection<TicketTerminal> TicketTerminals { get; set; }
    }
}
