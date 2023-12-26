﻿using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Respuestas
    {
        public int IdRespuesta { get; set; }
        public int CorrectaIncorrecta { get; set; }
        public int Puntaje { get; set; }
        public int? Pregunta { get; set; }
        public string? Descripcion { get; set; }

        public virtual Preguntas? PreguntaNavigation { get; set; }
    }
}