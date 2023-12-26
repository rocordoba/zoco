using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Banco
    {
        public Banco()
        {
            Dotacions = new HashSet<Dotacion>();
        }

        public int IdBanco { get; set; }
        public string? DescBanco { get; set; }

        public virtual ICollection<Dotacion> Dotacions { get; set; }
    }
}
