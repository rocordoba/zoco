using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class ActividadAfip
    {
        public ActividadAfip()
        {
            FantasiaComercioActividadAfipDosNavigations = new HashSet<FantasiaComercio>();
            FantasiaComercioActividadAfipNavigations = new HashSet<FantasiaComercio>();
        }

        public int IdActividadAfip { get; set; }
        public string? ActAfip { get; set; }
        public string? CodigoAfip { get; set; }

        public virtual ICollection<FantasiaComercio> FantasiaComercioActividadAfipDosNavigations { get; set; }
        public virtual ICollection<FantasiaComercio> FantasiaComercioActividadAfipNavigations { get; set; }
    }
}
