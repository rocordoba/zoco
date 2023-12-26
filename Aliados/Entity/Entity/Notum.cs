using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Notum
    {
        public int IdNota { get; set; }
        public string? Titulo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? UsuarioDotacion { get; set; }
        public DateTime? FechaArecordar { get; set; }

        public virtual Dotacion? UsuarioDotacionNavigation { get; set; }
    }
}
