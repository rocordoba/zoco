using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Dotacion
    {
        public Dotacion()
        {
            CoincidenciasCoordIdUserDoosNavigations = new HashSet<CoincidenciasCoord>();
            CoincidenciasCoordIdUserUnoNavigations = new HashSet<CoincidenciasCoord>();
            Coordenada = new HashSet<Coordenadum>();
            Documentacions = new HashSet<Documentacion>();
            FacturacionDotacions = new HashSet<FacturacionDotacion>();
            GestionesCompletada = new HashSet<GestionesCompletada>();
            HistCorreoDotacions = new HashSet<HistCorreoDotacion>();
            LeidoNoticia = new HashSet<LeidoNoticium>();
            LoggDotacions = new HashSet<LoggDotacion>();
            MetricasDotacions = new HashSet<MetricasDotacion>();
            MovimientoTermAsesorActualNavigations = new HashSet<MovimientoTerm>();
            MovimientoTermAsesorAntesNavigations = new HashSet<MovimientoTerm>();
            Nota = new HashSet<Notum>();
            NoticiasDots = new HashSet<NoticiasDot>();
            ObsTareas = new HashSet<ObsTarea>();
            Prospectos = new HashSet<Prospecto>();
            RegSessionesDotacions = new HashSet<RegSessionesDotacion>();
            StockAsesors = new HashSet<StockAsesor>();
            Terminals = new HashSet<Terminal>();
            TicketTerminals = new HashSet<TicketTerminal>();
            Visita = new HashSet<Visitum>();
        }

        public int IdDotacion { get; set; }
        public string? ApellidoNombre { get; set; }
        public double? CuitCuil { get; set; }
        public int? IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? EsActivo { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string? Cargo { get; set; }
        public string? TipoCuenta { get; set; }
        public string? CbuCvu { get; set; }
        public string? NumCta { get; set; }
        public string? AliasCbu { get; set; }
        public string? Legajos { get; set; }
        public string? Observaciones { get; set; }
        public string? Telefono { get; set; }
        public string? Domicilio { get; set; }
        public string? Contrato { get; set; }
        public string? ExentoComision { get; set; }
        public string? ExentoDescuento { get; set; }
        public string? Sexo { get; set; }
        public string? Jefe { get; set; }
        public string? Posicion { get; set; }
        public string? GestionCompletada { get; set; }
        public int? NivelFacturacionAbm { get; set; }
        public int? NivelActivacionAbm { get; set; }
        public int? NivelAutoCalActivacion { get; set; }
        public string? FrenarPago { get; set; }
        public int? CantDeTerminales { get; set; }
        public int? DiasParVisitas { get; set; }
        public int? Provincia { get; set; }
        public int? ProvinciaDos { get; set; }
        public int? Banco { get; set; }
        public int? EscalaAlcanzada { get; set; }

        public virtual Banco? BancoNavigation { get; set; }
        public virtual Provincium? ProvinciaDosNavigation { get; set; }
        public virtual Provincium? ProvinciaNavigation { get; set; }
        public virtual ICollection<CoincidenciasCoord> CoincidenciasCoordIdUserDoosNavigations { get; set; }
        public virtual ICollection<CoincidenciasCoord> CoincidenciasCoordIdUserUnoNavigations { get; set; }
        public virtual ICollection<Coordenadum> Coordenada { get; set; }
        public virtual ICollection<Documentacion> Documentacions { get; set; }
        public virtual ICollection<FacturacionDotacion> FacturacionDotacions { get; set; }
        public virtual ICollection<GestionesCompletada> GestionesCompletada { get; set; }
        public virtual ICollection<HistCorreoDotacion> HistCorreoDotacions { get; set; }
        public virtual ICollection<LeidoNoticium> LeidoNoticia { get; set; }
        public virtual ICollection<LoggDotacion> LoggDotacions { get; set; }
        public virtual ICollection<MetricasDotacion> MetricasDotacions { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermAsesorActualNavigations { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTermAsesorAntesNavigations { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
        public virtual ICollection<NoticiasDot> NoticiasDots { get; set; }
        public virtual ICollection<ObsTarea> ObsTareas { get; set; }
        public virtual ICollection<Prospecto> Prospectos { get; set; }
        public virtual ICollection<RegSessionesDotacion> RegSessionesDotacions { get; set; }
        public virtual ICollection<StockAsesor> StockAsesors { get; set; }
        public virtual ICollection<Terminal> Terminals { get; set; }
        public virtual ICollection<TicketTerminal> TicketTerminals { get; set; }
        public virtual ICollection<Visitum> Visita { get; set; }
    }
}
