using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoMovimiento
    {
        public EstadoMovimiento()
        {
            MovimientoTerms = new HashSet<MovimientoTerm>();
        }

        public int IdEstadoMov { get; set; }
        public string? DescripcionEstado { get; set; }

        public virtual ICollection<MovimientoTerm> MovimientoTerms { get; set; }
    }
}
