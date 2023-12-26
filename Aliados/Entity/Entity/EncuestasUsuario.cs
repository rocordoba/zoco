using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EncuestasUsuario
    {
        public int IdRespuestaUsuario { get; set; }
        public int IdEncuesta { get; set; }
        public int? IntRespuesta { get; set; }
        public int? IntUsuario { get; set; }
        public int? PuntajeTotal { get; set; }

        public virtual RegistroPregunta? IntRespuestaNavigation { get; set; }
        public virtual Dotacion? IntUsuarioNavigation { get; set; }
    }
}
