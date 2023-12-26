using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class OrigenProsp
    {
        public OrigenProsp()
        {
            Prospectos = new HashSet<Prospecto>();
        }

        public int IdOrigenProsp { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Prospecto> Prospectos { get; set; }
    }
}
