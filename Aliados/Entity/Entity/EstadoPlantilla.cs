using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class EstadoPlantilla
    {
        public EstadoPlantilla()
        {
            PlantillaAltaFisicas = new HashSet<PlantillaAltaFisica>();
            PlantillaAltaJurEstadoPlantillaNavigations = new HashSet<PlantillaAltaJur>();
            PlantillaAltaJurIdEstadoNavigations = new HashSet<PlantillaAltaJur>();
            PlantillaBajas = new HashSet<PlantillaBaja>();
            PlantillaModificaciones = new HashSet<PlantillaModificacione>();
        }

        public int IdEstadoPlantilla { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<PlantillaAltaFisica> PlantillaAltaFisicas { get; set; }
        public virtual ICollection<PlantillaAltaJur> PlantillaAltaJurEstadoPlantillaNavigations { get; set; }
        public virtual ICollection<PlantillaAltaJur> PlantillaAltaJurIdEstadoNavigations { get; set; }
        public virtual ICollection<PlantillaBaja> PlantillaBajas { get; set; }
        public virtual ICollection<PlantillaModificacione> PlantillaModificaciones { get; set; }
    }
}
