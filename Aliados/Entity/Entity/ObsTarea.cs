using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class ObsTarea
    {
        public ObsTarea()
        {
            InverseIdRespuestaNavigation = new HashSet<ObsTarea>();
        }

        public int IdObsTarea { get; set; }
        public string? Observacion { get; set; }
        public int? IdRespuesta { get; set; }
        public int? IdAutorNos { get; set; }
        public int? IdAutorAsesor { get; set; }

        public virtual Dotacion? IdAutorAsesorNavigation { get; set; }
        public virtual UsuarioNo? IdAutorNosNavigation { get; set; }
        public virtual ObsTarea? IdRespuestaNavigation { get; set; }
        public virtual ICollection<ObsTarea> InverseIdRespuestaNavigation { get; set; }
    }
}
