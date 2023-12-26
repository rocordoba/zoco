using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoTerminal
    {
        public EstadoTerminal()
        {
            Terminals = new HashSet<Terminal>();
        }

        public int IdEstadoTerminal { get; set; }
        public string? DescripcionEstado { get; set; }

        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
