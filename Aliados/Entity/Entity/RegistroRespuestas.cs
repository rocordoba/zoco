using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegistroRespuestas
    {
        public RegistroRespuestas()
        {
            RegistroPregunta = new HashSet<RegistroPreguntas>();
        }

        public int IdResp { get; set; }
        public int? CorrectaOno { get; set; }

        public virtual ICollection<RegistroPreguntas> RegistroPregunta { get; set; }
    }
}
