using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TipoNota
    {
        public TipoNota()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdTipoNota { get; set; }
        public string? Descripcion { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }
}
