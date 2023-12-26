using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Prospectos
    {
        public Prospectos()
        {
            EstadoProspectos = new HashSet<EstadoProspecto>();
            Nota = new HashSet<Nota>();
        }

        public int IdProspecto { get; set; }
        public int? IdUsuario { get; set; }
        public string? NombreResponsable { get; set; }
        public string? TelefonoRespon { get; set; }
        public double? FactAprox { get; set; }
        public int? TermCerrada { get; set; }
        public int? TermProyectadas { get; set; }
        public string? Observaciones { get; set; }
        public int? Provincia { get; set; }
        public int? OrigenProsp { get; set; }
        public int? Limite { get; set; }

        public virtual UsuarioDotacion? IdUsuarioNavigation { get; set; }
        public virtual OrigenProsp? OrigenProspNavigation { get; set; }
        public virtual Provincia? ProvinciaNavigation { get; set; }
        public virtual ICollection<EstadoProspecto> EstadoProspectos { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
