using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class DocVisita
    {
        public int IdDocumentacion { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreArchivo { get; set; }
        public string? UrlArchivo { get; set; }
        public int? Idvisita { get; set; }

        public virtual Visita? IdvisitaNavigation { get; set; }
    }
}
