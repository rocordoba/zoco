using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RespNoticiasDot
    {
        public int IdRespNoticias { get; set; }
        public int? IdNoticias { get; set; }
        public string? Descripcion { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaNot { get; set; }

        public virtual NoticiasDot? IdNoticiasNavigation { get; set; }
    }
}
