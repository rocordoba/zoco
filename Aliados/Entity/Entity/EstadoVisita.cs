using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoVisita
    {
        public EstadoVisita()
        {
            Visita = new HashSet<Visita>();
        }

        public int IdVisitas { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Visita> Visita { get; set; }
    }
}
