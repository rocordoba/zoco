using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Documentacion
    {
        public int IdDocumentacion { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreArchivo { get; set; }
        public string? UrlArchivo { get; set; }
        public int? IdAsesor { get; set; }
        public int? IdFantasia { get; set; }
        public int? Tipo { get; set; }
        public int? TipoAlta { get; set; }
        public int? TipoBaja { get; set; }

        public virtual Dotacion? IdAsesorNavigation { get; set; }
        public virtual FantasiaComercio? IdFantasiaNavigation { get; set; }
        public virtual TipoDeAltum? TipoAltaNavigation { get; set; }
        public virtual TipoBaja? TipoBajaNavigation { get; set; }
    }
}
