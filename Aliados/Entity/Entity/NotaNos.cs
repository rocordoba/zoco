using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class NotaNos
    {
        public int IdNota { get; set; }
        public string? Titulo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? IdNos { get; set; }
        public int? IdTipoNota { get; set; }
        public int? TipoPrioridad { get; set; }
    }
}
