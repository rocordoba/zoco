using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoRenta
    {
        public EstadoRenta()
        {
            FantasiaComercios = new HashSet<FantasiaComercio>();
        }

        public int IdEstadoRentas { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<FantasiaComercio> FantasiaComercios { get; set; }
    }
}
