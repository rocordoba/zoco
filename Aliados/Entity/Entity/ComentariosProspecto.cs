using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class ComentariosProspecto
    {
        public ComentariosProspecto()
        {
            InverseIdComHijoNavigation = new HashSet<ComentariosProspecto>();
        }

        public int IdComentario { get; set; }
        public string? Comentario { get; set; }
        public int? IdPadreEstadoProspecto { get; set; }
        public int? IdComHijo { get; set; }

        public virtual ComentariosProspecto? IdComHijoNavigation { get; set; }
        public virtual EstadoProspecto? IdPadreEstadoProspectoNavigation { get; set; }
        public virtual ICollection<ComentariosProspecto> InverseIdComHijoNavigation { get; set; }
    }
}
