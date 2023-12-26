using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegistroEstadoVisitas
    {
        public int IdRegistroEstadoVisitas { get; set; }
        public DateTime? FechaVisita { get; set; }
        public int? IdRegistroPadre { get; set; }

        public virtual EstadoProspecto? IdRegistroPadreNavigation { get; set; }
    }
}
