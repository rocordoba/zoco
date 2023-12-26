using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class VistaFechasLaborables
    {
        public DateTime? Fecha { get; set; }
        public string? Dia { get; set; }
        public string Laborable { get; set; } = null!;
    }
}
