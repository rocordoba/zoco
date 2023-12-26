using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Prioridades
    {
        public Prioridades()
        {
            Nota = new HashSet<Nota>();
            NoticiasDots = new HashSet<NoticiasDot>();
        }

        public int IdPrioridades { get; set; }
        public string? DescPrioridad { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<NoticiasDot> NoticiasDots { get; set; }
    }
}
