using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoProspecto
    {
        public EstadoProspecto()
        {
            ComentariosProspectos = new HashSet<ComentariosProspecto>();
        }

        public int IdEstadoProspecto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechFin { get; set; }
        public int? Logrado { get; set; }
        public int? IdProspectoPadre { get; set; }
        public int? Tipo { get; set; }
        public int? IdEncuesta { get; set; }
        public int? Coord { get; set; }
        public TimeSpan? Hora { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaArecordar { get; set; }

        public virtual Coordenadum? CoordNavigation { get; set; }
        public virtual Encuestum? IdEncuestaNavigation { get; set; }
        public virtual Prospecto? IdProspectoPadreNavigation { get; set; }
        public virtual TipoProsp? TipoNavigation { get; set; }
        public virtual ICollection<ComentariosProspecto> ComentariosProspectos { get; set; }
    }
}
