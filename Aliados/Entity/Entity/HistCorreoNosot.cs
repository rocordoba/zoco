using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class HistCorreoNosot
    {
        public int IdHistCorreo { get; set; }
        public string? TipoDescripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? UsuarioNos { get; set; }

        public virtual UsuarioNo? UsuarioNosNavigation { get; set; }
    }
}
