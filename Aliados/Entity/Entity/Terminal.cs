using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Terminal
    {
        public Terminal()
        {
            MovimientoTerms = new HashSet<MovimientoTerm>();
            TicketTerminals = new HashSet<TicketTerminal>();
        }

        public double IdTerminal { get; set; }
        public int? NumTerminal { get; set; }
        public int? IdEstadoTerminal { get; set; }
        public int? IdFantasiaCom { get; set; }
        public int? ProvinciaActual { get; set; }
        public int? AsesorAhora { get; set; }
        public int? DecTomada { get; set; }
        public int? DecTomadaAbm { get; set; }

        public virtual Dotacion? AsesorAhoraNavigation { get; set; }
        public virtual DecTomadaTerminal? DecTomadaAbmNavigation { get; set; }
        public virtual DecTomadaTerminal? DecTomadaNavigation { get; set; }
        public virtual EstadoTerminal? IdEstadoTerminalNavigation { get; set; }
        public virtual FantasiaComercio? IdFantasiaComNavigation { get; set; }
        public virtual Provincium? ProvinciaActualNavigation { get; set; }
        public virtual ICollection<MovimientoTerm> MovimientoTerms { get; set; }
        public virtual ICollection<TicketTerminal> TicketTerminals { get; set; }
    }
}
