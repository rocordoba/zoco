using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class CoincidenciasCoord
    {
        public int IdCoincidenciasCoord { get; set; }
        public int? IdUserUno { get; set; }
        public int? IdUserDoos { get; set; }
        public int? IdUserCoordenadaUna { get; set; }
        public int? IdUserCoordenadaDos { get; set; }
        public DateTime? FechaCoincidencia { get; set; }

        public virtual Coordenadum? IdUserCoordenadaDosNavigation { get; set; }
        public virtual Coordenadum? IdUserCoordenadaUnaNavigation { get; set; }
        public virtual Dotacion? IdUserDoosNavigation { get; set; }
        public virtual Dotacion? IdUserUnoNavigation { get; set; }
    }
}
