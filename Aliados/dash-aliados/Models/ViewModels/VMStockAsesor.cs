﻿namespace ZocoAplicacion.Models.ViewModels
{
    public class VMStockAsesor
    {
        public int IdStockTerminales { get; set; }
        public int? MesStockeado { get; set; }
        public string? FechaStockeado { get; set; }
        public int? StockTotal { get; set; }
        public int? Activa { get; set; }
        public int? EnProcesoDeAct { get; set; }
        public int? Disponible { get; set; }
        public int? ServTecnico { get; set; }
        public int? BajoAnalisis { get; set; }
        public int? Reubicar { get; set; }
        public int? AcreditacionPendiente { get; set; }
        public int? Bajas { get; set; }
        public int? IdAsesorStockeada { get; set; }
        public string? descAsesor { get; set; }
        public int? Altas { get; set; }
        public int? Extraviada { get; set; }

    }
}
