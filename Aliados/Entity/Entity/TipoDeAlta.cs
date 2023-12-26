using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TipoDeAlta
    {
        public TipoDeAlta()
        {
            Documentacions = new HashSet<Documentacion>();
            PlantillaAltaFisicas = new HashSet<PlantillaAltaFisica>();
            PlantillaAltaJurs = new HashSet<PlantillaAltaJur>();
        }

        public int IdTipoAlta { get; set; }
        public string? DescripcionTipo { get; set; }

        public virtual ICollection<Documentacion> Documentacions { get; set; }
        public virtual ICollection<PlantillaAltaFisica> PlantillaAltaFisicas { get; set; }
        public virtual ICollection<PlantillaAltaJur> PlantillaAltaJurs { get; set; }
    }
}
