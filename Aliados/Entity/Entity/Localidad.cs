using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Localidad
    {
        public Localidad()
        {
            Prospectos = new HashSet<Prospecto>();
        }

        public int IdLocalidad { get; set; }
        public string? NombreLocalidad { get; set; }
        public string? CodigoPostal { get; set; }
        public int? Provincia { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Provincium? ProvinciaNavigation { get; set; }
        public virtual ICollection<Prospecto> Prospectos { get; set; }
    }
}
