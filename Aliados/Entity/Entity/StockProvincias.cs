using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class StockProvincias
    {
        public int IdStockTerminales { get; set; }
        public int? MesStockeado { get; set; }
        public DateTime? FechaStockeado { get; set; }
        public int? StockTotal { get; set; }
        public int? Activa { get; set; }
        public int? EnProcesoDeAct { get; set; }
        public int? Disponible { get; set; }
        public int? ServTecnico { get; set; }
        public int? BajoAnalisis { get; set; }
        public int? Reubicar { get; set; }
        public int? AcreditacionPendiente { get; set; }
        public int? Bajas { get; set; }
        public int? IdProvinciaStockeada { get; set; }
        public int? Altas { get; set; }
        public int? Extraviada { get; set; }

        public virtual Provincia? IdProvinciaStockeadaNavigation { get; set; }
    }
}
