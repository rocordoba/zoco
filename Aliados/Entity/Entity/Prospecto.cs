using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Prospecto
    {
        public Prospecto()
        {
            EstadoProspectos = new HashSet<EstadoProspecto>();
        }

        public int IdProspecto { get; set; }
        public string? NombreResponsable { get; set; }
        public string? TelefonoRespon { get; set; }
        public double? FactAprox { get; set; }
        public int? TermCerrada { get; set; }
        public int? TermProyectadas { get; set; }
        public string? Observaciones { get; set; }
        public int? Provincia { get; set; }
        public int? OrigenProsp { get; set; }
        public int? Limite { get; set; }
        public int? CerradoPorAbm { get; set; }
        public int? Rubro { get; set; }
        public int? Localidad { get; set; }
        public string? CodigoPostal { get; set; }
        public int? CtaConTer { get; set; }
        public int? IdDotacion { get; set; }
        public string? Domicilio { get; set; }

        public virtual Dotacion? IdDotacionNavigation { get; set; }
        public virtual Localidad? LocalidadNavigation { get; set; }
        public virtual OrigenProsp? OrigenProspNavigation { get; set; }
        public virtual Provincium? ProvinciaNavigation { get; set; }
        public virtual Rubro? RubroNavigation { get; set; }
        public virtual ICollection<EstadoProspecto> EstadoProspectos { get; set; }
    }
}
