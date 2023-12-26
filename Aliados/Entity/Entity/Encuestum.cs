using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Encuestum
    {
        public Encuestum()
        {
            EstadoProspectos = new HashSet<EstadoProspecto>();
            Pregunta = new HashSet<Pregunta>();
        }

        public int IdEncuesta { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int PuntajeTotal { get; set; }
        public int? Publicar { get; set; }

        public virtual ICollection<EstadoProspecto> EstadoProspectos { get; set; }
        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
