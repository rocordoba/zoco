using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Nota
    {
        public int IdNota { get; set; }
        public string? Titulo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? IdAsesor { get; set; }
        public int? IdTipoNota { get; set; }
        public int? TipoPrioridad { get; set; }
        public int? IdProspecto { get; set; }

        public virtual UsuarioDotacion? IdAsesorNavigation { get; set; }
        public virtual Prospectos? IdProspectoNavigation { get; set; }
        public virtual TipoNota? IdTipoNotaNavigation { get; set; }
        public virtual Prioridades? TipoPrioridadNavigation { get; set; }
    }
}
