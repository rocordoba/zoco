using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Preguntas
    {
        public Preguntas()
        {
            Respuesta = new HashSet<Respuestas>();
        }

        public int IdPreguntas { get; set; }
        public string? DescPreguntas { get; set; }
        public int? IdEncPadre { get; set; }

        public virtual Encuesta? IdEncPadreNavigation { get; set; }
        public virtual ICollection<Respuestas> Respuesta { get; set; }
    }
}
