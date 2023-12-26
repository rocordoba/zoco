using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class DocVisitum
    {
        public int IdDocumentacion { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreArchivo { get; set; }
        public string? UrlArchivo { get; set; }
        public int? Idvisita { get; set; }

        public virtual Visitum? IdvisitaNavigation { get; set; }
    }
}
