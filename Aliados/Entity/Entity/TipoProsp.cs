using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TipoProsp
    {
        public TipoProsp()
        {
            EstadoProspectos = new HashSet<EstadoProspecto>();
        }

        public int IdTipoProsp { get; set; }
        public string? DescripTipoProsp { get; set; }

        public virtual ICollection<EstadoProspecto> EstadoProspectos { get; set; }
    }
}
