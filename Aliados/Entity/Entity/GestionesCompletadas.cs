using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class GestionesCompletadas
    {
        public int IdGestionCompleta { get; set; }
        public int? Reubicar { get; set; }
        public int? BajoAnalisis { get; set; }
        public int? SerTecnico { get; set; }
        public int? Envios { get; set; }
        public int? Varios { get; set; }
        public int? Observaciones { get; set; }
        public int? ControlGest { get; set; }
        public int? Mes { get; set; }
        public int? IdDotacion { get; set; }
        public int? CalificadoXaliado { get; set; }

        public virtual Dotacion? IdDotacionNavigation { get; set; }
    }
}
