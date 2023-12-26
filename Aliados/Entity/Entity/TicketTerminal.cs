using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TicketTerminal
    {
        public int IdTicketTerminal { get; set; }
        public int? Fantasia { get; set; }
        public int? Asesor { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public double? MontoFavorBruto { get; set; }
        public double? MontoNegativoBruto { get; set; }
        public int? Mes { get; set; }
        public double? IdTerminalTickey { get; set; }
        public double? Debito { get; set; }
        public double? Credito { get; set; }
        public double? UnPago { get; set; }
        public int? IdRazsocial { get; set; }
        public double? DescTerminal { get; set; }
        public double? FaltaVisita { get; set; }

        public virtual Dotacion? AsesorNavigation { get; set; }
        public virtual FantasiaComercio? FantasiaNavigation { get; set; }
        public virtual RazonSocial? IdRazsocialNavigation { get; set; }
        public virtual Terminal? IdTerminalTickeyNavigation { get; set; }
    }
}
