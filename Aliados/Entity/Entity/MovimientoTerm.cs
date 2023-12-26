using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class MovimientoTerm
    {
        public int IdMovimiento { get; set; }
        public int? Fantasia { get; set; }
        public int? Estado { get; set; }
        public int? EstadoMovimiento { get; set; }
        public double? Terminal { get; set; }
        public int? AsesorAntes { get; set; }
        public int? AsesorActual { get; set; }
        public DateTime? ProgramacionBaja { get; set; }
        public int? DiasParaAlta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? FantasiaAntes { get; set; }
        public int? Origen { get; set; }
        public int? Destino { get; set; }

        public virtual Dotacion? AsesorActualNavigation { get; set; }
        public virtual Dotacion? AsesorAntesNavigation { get; set; }
        public virtual Provincium? DestinoNavigation { get; set; }
        public virtual EstadoMovimiento? EstadoMovimientoNavigation { get; set; }
        public virtual DecTomadaTerminal? EstadoNavigation { get; set; }
        public virtual FantasiaComercio? FantasiaAntesNavigation { get; set; }
        public virtual FantasiaComercio? FantasiaNavigation { get; set; }
        public virtual Provincium? OrigenNavigation { get; set; }
        public virtual Terminal? TerminalNavigation { get; set; }
    }
}
