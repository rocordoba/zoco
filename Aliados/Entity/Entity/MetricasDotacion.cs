using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class MetricasDotacion
    {
        public int IdMetrica { get; set; }
        public int? Dotacion { get; set; }
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public int? Cantidad { get; set; }
        public int? Efectividad { get; set; }
        public double? PromedioDeEfectividad { get; set; }
        public int? Tipo { get; set; }

        public virtual Dotacion? DotacionNavigation { get; set; }
        public virtual TipoMetrica? TipoNavigation { get; set; }
    }
}
