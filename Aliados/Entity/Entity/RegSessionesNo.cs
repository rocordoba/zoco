using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegSessionesNo
    {
        public int IdRegistros { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? UsuarioNos { get; set; }
        public int? Estado { get; set; }

        public virtual UsuarioNo? UsuarioNosNavigation { get; set; }
    }
}
