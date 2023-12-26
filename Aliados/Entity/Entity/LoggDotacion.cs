using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class LoggDotacion
    {
        public int IdLog { get; set; }
        public string? Descripcion { get; set; }
        public int? IdAccion { get; set; }
        public DateTime? FechaCrea { get; set; }
        public int? UsuarioDotacion { get; set; }

        public virtual Dotacion? UsuarioDotacionNavigation { get; set; }
    }
}
