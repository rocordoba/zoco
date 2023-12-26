using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Tarea
    {
        public int IdTarea { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string? TituloTarea { get; set; }
        public string? Descripcion { get; set; }
        public int? Recordar { get; set; }
        public TimeSpan? CadaCuanto { get; set; }
        public int? IdAutor { get; set; }
        public int? IdPrioridad { get; set; }
        public int? IdTipoTarea { get; set; }
        public int? IdProspecto { get; set; }
        public int? Asesor { get; set; }
        public int? EstadoTarea { get; set; }
        public int? IdObservaciones { get; set; }
        public DateTime? FechaArecordar { get; set; }

        public virtual Dotacion? AsesorNavigation { get; set; }
        public virtual EstadoTarea? EstadoTareaNavigation { get; set; }
        public virtual UsuarioNo? IdAutorNavigation { get; set; }
        public virtual ObsTarea? IdObservacionesNavigation { get; set; }
        public virtual Prioridade? IdPrioridadNavigation { get; set; }
        public virtual Prospecto? IdProspectoNavigation { get; set; }
        public virtual TipoTarea? IdTipoTareaNavigation { get; set; }
    }
}
