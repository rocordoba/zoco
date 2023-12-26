using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Visitum
    {
        public Visitum()
        {
            DocVisita = new HashSet<DocVisitum>();
        }

        public int IdVisita { get; set; }
        public string? Observacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsDotacion { get; set; }
        public int? EstadoVisitas { get; set; }
        public int? Coordenadas { get; set; }
        public byte[]? ImgTerminalUrl { get; set; }
        public string? ApellidoTitAutorizado { get; set; }
        public string? TipoDeTitular { get; set; }
        public string? OtroTitular { get; set; }
        public string? ObservacionTitular { get; set; }
        public int? ModCondFiscalAfip { get; set; }
        public int? ModCondFiscalRentas { get; set; }
        public int? VerCierreLote { get; set; }
        public int? FuncDeEquipo { get; set; }
        public int? InicTerminal { get; set; }
        public int? CargEnCond { get; set; }
        public string? NombreFantasia { get; set; }
        public double? Terminal { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Coordenadum? CoordenadasNavigation { get; set; }
        public virtual EstadoVisitum? EstadoVisitasNavigation { get; set; }
        public virtual Provincium? IdProvinciaNavigation { get; set; }
        public virtual Dotacion? IdUsDotacionNavigation { get; set; }
        public virtual ICollection<DocVisitum> DocVisita { get; set; }
    }
}
