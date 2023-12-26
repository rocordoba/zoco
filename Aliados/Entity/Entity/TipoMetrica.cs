using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TipoMetrica
    {
        public TipoMetrica()
        {
            MetricasDotacions = new HashSet<MetricasDotacion>();
        }

        public int IdTipoMetricas { get; set; }
        public string? DescripTipoMetrica { get; set; }

        public virtual ICollection<MetricasDotacion> MetricasDotacions { get; set; }
    }
}
