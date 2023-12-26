using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoVisitum
    {
        public EstadoVisitum()
        {
            Visita = new HashSet<Visitum>();
        }

        public int IdVisitas { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Visitum> Visita { get; set; }
    }
}
