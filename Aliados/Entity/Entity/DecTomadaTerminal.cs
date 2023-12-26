using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class DecTomadaTerminal
    {
        public DecTomadaTerminal()
        {
            MovimientoTerms = new HashSet<MovimientoTerm>();
            TerminalDecTomadaAbmNavigations = new HashSet<Terminal>();
            TerminalDecTomadaNavigations = new HashSet<Terminal>();
        }

        public int IdEstado { get; set; }
        public string? DescripcionEstado { get; set; }

        public virtual ICollection<MovimientoTerm> MovimientoTerms { get; set; }
        public virtual ICollection<Terminal> TerminalDecTomadaAbmNavigations { get; set; }
        public virtual ICollection<Terminal> TerminalDecTomadaNavigations { get; set; }
    }
}
