using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class LeidoNoticium
    {
        public int IdLeido { get; set; }
        public int? IdUser { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? IdNoticiaPadre { get; set; }

        public virtual NoticiasDot? IdNoticiaPadreNavigation { get; set; }
        public virtual Dotacion? IdUserNavigation { get; set; }
    }
}
