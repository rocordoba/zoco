using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Prioridade
    {
        public Prioridade()
        {
            NoticiasDots = new HashSet<NoticiasDot>();
        }

        public int IdPrioridades { get; set; }
        public string? DescPrioridad { get; set; }

        public virtual ICollection<NoticiasDot> NoticiasDots { get; set; }
    }
}
