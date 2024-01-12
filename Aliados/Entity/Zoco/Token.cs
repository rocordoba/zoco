
using System;
using System.Collections.Generic;

namespace Entity.Zoco
{
    public partial class Token
    {
        public int TokenId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Token1 { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
