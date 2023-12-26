﻿using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegSessionesDotacion
    {
        public int IdRegistros { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Estado { get; set; }
        public int? IdAsesor { get; set; }

        public virtual Dotacion? IdAsesorNavigation { get; set; }
    }
}
