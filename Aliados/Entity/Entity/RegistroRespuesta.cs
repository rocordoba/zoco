using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class RegistroRespuesta
    {
        public RegistroRespuesta()
        {
            RegistroPregunta = new HashSet<RegistroPregunta>();
        }

        public int IdResp { get; set; }
        public int? CorrectaOno { get; set; }

        public virtual ICollection<RegistroPregunta> RegistroPregunta { get; set; }
    }
}
