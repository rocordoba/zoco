using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class HistCorreoDotacion
    {
        public int IdHistCorreo { get; set; }
        public string? TipoDescripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? UsuarioDotacion { get; set; }

        public virtual Dotacion? UsuarioDotacionNavigation { get; set; }
    }
}
