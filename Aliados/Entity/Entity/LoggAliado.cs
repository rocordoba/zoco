using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class LoggAliado
    {
        public int IdLog { get; set; }
        public string? Descripcion { get; set; }
        public int? IdAccion { get; set; }
        public int? IdUsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }

        public virtual Usuario? IdUsuarioCreaNavigation { get; set; }
    }
}
