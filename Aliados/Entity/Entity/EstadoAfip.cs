using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoAfip
    {
        public EstadoAfip()
        {
            FantasiaComercios = new HashSet<FantasiaComercio>();
        }

        public int IdEstadoAfip { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<FantasiaComercio> FantasiaComercios { get; set; }
    }
}
