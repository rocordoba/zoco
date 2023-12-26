using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegSessionesAliado
    {
        public int IdRegistros { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? UsuarioAliado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario? UsuarioAliadoNavigation { get; set; }
    }
}
