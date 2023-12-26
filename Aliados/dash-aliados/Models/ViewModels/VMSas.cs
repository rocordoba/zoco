namespace ZocoAplicacion.Models.ViewModels
{
    public class VMSAS
    {
        public int IdSas { get; set; }
        public string? FechaOperacion { get; set; }
        public string? FechadePago { get; set; }
        public string? NumDeCupon { get; set; }
        public int? NumeroTerminal { get; set; }
        public int? NumTerminal { get; set; }
        public int? NumTarjeta { get; set; }
        public string? TotalBruto { get; set; }
        public string? TotalDescuento { get; set; }
        public string? TotalNeto { get; set; }
        public string? EntidadPagadora { get; set; }
        public string? CtaBancaria { get; set; }
        public string? NumLiquidacion { get; set; }
        public string? NumDeLote { get; set; }
        public string? TipoDeLiq { get; set; }
        public string? Estado { get; set; }
        public int? Cuotas { get; set; }
        public int? NumDeAutorizacion { get; set; }
        public string? Tarjeta { get; set; }
        public string? TipoOperacion { get; set; }
        public string? ComParticipante { get; set; }
        public string? PromocionPlan { get; set; }

        public string? TarjetaTipo { get; set; }
        public string? CostoFinanciero { get; set; }
        public string? CostoFinEnPesos { get; set; }
        public string? TipoDeFinanciacion { get; set; }
        public int? DiasHabiles { get; set; }
        public string? CostoPorAnticipo { get; set; }
        public string? ComisionConIva { get; set; }
        public string? Arancel { get; set; }
        public string? IvaVeintiuno { get; set; }
        public string? ImpuestoDebCred { get; set; }
        public string? RetencionProvincial { get; set; }
        public string? RetencionGanancia { get; set; }
        public string? RetencionIva { get; set; }
        public string? RetencionMunicipal { get; set; }
        public string? TotalConDescuento { get; set; }
        public string? RetencionSiNo { get; set; }
        public string? RetencionImpositiva { get; set; }
        public string? ArancelFiserv { get; set; }
        public string? FormAnticipo { get; set; }
        public string PagoReal { get; set; } = null!;
        public string? AnticipoNew { get; set; }
    }
}
