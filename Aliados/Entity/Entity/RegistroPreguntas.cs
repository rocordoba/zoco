using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegistroPreguntas
    {
        public int IdPreg { get; set; }
        public int? Puntaje { get; set; }
        public int? IntRespuesta { get; set; }

        public virtual RegistroRespuestas? IntRespuestaNavigation { get; set; }
    }
}
