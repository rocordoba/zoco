using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TipoBaja
    {
        public TipoBaja()
        {
            Documentacions = new HashSet<Documentacion>();
            PlantillaBajas = new HashSet<PlantillaBaja>();
        }

        public int IdTipoBaja { get; set; }
        public string? DescBaja { get; set; }

        public virtual ICollection<Documentacion> Documentacions { get; set; }
        public virtual ICollection<PlantillaBaja> PlantillaBajas { get; set; }
    }
}
