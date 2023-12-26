using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int IdPreguntas { get; set; }
        public string? DescPreguntas { get; set; }
        public int? IdEncPadre { get; set; }

        public virtual Encuestum? IdEncPadreNavigation { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
