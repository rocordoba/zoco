using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Rubro
    {
        public Rubro()
        {
            FantasiaComercioRubroDosNavigations = new HashSet<FantasiaComercio>();
            FantasiaComercioRubroUnoNavigations = new HashSet<FantasiaComercio>();
            Prospectos = new HashSet<Prospecto>();
        }

        public int IdRubro { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<FantasiaComercio> FantasiaComercioRubroDosNavigations { get; set; }
        public virtual ICollection<FantasiaComercio> FantasiaComercioRubroUnoNavigations { get; set; }
        public virtual ICollection<Prospecto> Prospectos { get; set; }
    }
}
