using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Visita
    {
        public Visita()
        {
            DocVisita = new HashSet<DocVisita>();
        }

        public int IdVisita { get; set; }
        public string? Observacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsDotacion { get; set; }
        public int? IdTerminal { get; set; }
        public int? EstadoVisitas { get; set; }
        public int? Coordenadas { get; set; }
        public string? ImgTerminalUrl { get; set; }

        public virtual Coordenada? CoordenadasNavigation { get; set; }
        public virtual EstadoVisita? EstadoVisitasNavigation { get; set; }
        public virtual Terminal? IdTerminalNavigation { get; set; }
        public virtual Dotacion? IdUsDotacionNavigation { get; set; }
        public virtual ICollection<DocVisita> DocVisita { get; set; }
    }
}
