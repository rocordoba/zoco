using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Coordenadum
    {
        public Coordenadum()
        {
            CoincidenciasCoordIdUserCoordenadaDosNavigations = new HashSet<CoincidenciasCoord>();
            CoincidenciasCoordIdUserCoordenadaUnaNavigations = new HashSet<CoincidenciasCoord>();
            EstadoProspectos = new HashSet<EstadoProspecto>();
            Visita = new HashSet<Visitum>();
        }

        public int IdCoordenada { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public string? Dispositivo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? BateriaPorc { get; set; }
        public int? IdUser { get; set; }
        public int? IdUsuarioDot { get; set; }

        public virtual UsuarioNo? IdUserNavigation { get; set; }
        public virtual Dotacion? IdUsuarioDotNavigation { get; set; }
        public virtual ICollection<CoincidenciasCoord> CoincidenciasCoordIdUserCoordenadaDosNavigations { get; set; }
        public virtual ICollection<CoincidenciasCoord> CoincidenciasCoordIdUserCoordenadaUnaNavigations { get; set; }
        public virtual ICollection<EstadoProspecto> EstadoProspectos { get; set; }
        public virtual ICollection<Visitum> Visita { get; set; }
    }
}
