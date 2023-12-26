using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RazonSocial
    {
        public RazonSocial()
        {
            FantasiaComercios = new HashSet<FantasiaComercio>();
            TicketTerminals = new HashSet<TicketTerminal>();
        }

        public int IdRazonSocial { get; set; }
        public double? Cuit { get; set; }
        public string? NombreRazonSoc { get; set; }
        public string? DomicilioFiscal { get; set; }
        public string? Banco { get; set; }
        public string? TipoCuenta { get; set; }
        public string? CbuCvu { get; set; }
        public string? NumCta { get; set; }
        public int? LargoCbu { get; set; }
        public string? AliasCbu { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<FantasiaComercio> FantasiaComercios { get; set; }
        public virtual ICollection<TicketTerminal> TicketTerminals { get; set; }
    }
}
