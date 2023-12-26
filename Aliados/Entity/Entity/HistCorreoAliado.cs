using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class HistCorreoAliado
    {
        public int IdHistCorreo { get; set; }
        public string? TipoDescripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? UsuarioAliado { get; set; }

        public virtual Usuario? UsuarioAliadoNavigation { get; set; }
    }
}
