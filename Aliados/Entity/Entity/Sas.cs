using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Sas
    {
        public int IdSas { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public DateTime? FechadePago { get; set; }
        public string? NumDeCupon { get; set; }
        public int? NumeroTerminal { get; set; }
        public int? NumTerminal { get; set; }
        public int? NumTarjeta { get; set; }
        public double? TotalBruto { get; set; }
        public double? TotalDescuento { get; set; }
        public double? TotalNeto { get; set; }
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
        public double? CostoFinanciero { get; set; }
        public double? CostoFinEnPesos { get; set; }
        public string? TipoDeFinanciacion { get; set; }
        public int? DiasHabiles { get; set; }
        public double? CostoPorAnticipo { get; set; }
        public double? ComisionConIva { get; set; }
        public double? Arancel { get; set; }
        public double? IvaVeintiuno { get; set; }
        public double? ImpuestoDebCred { get; set; }
        public double? RetencionProvincial { get; set; }
        public double? RetencionGanancia { get; set; }
        public double? RetencionIva { get; set; }
        public double? RetencionMunicipal { get; set; }
        public decimal? TotalConDescuento { get; set; }
        public string? RetencionSiNo { get; set; }
        public double? RetencionImpositiva { get; set; }
        public double? ArancelFiserv { get; set; }
        public double? FormAnticipo { get; set; }
        public string PagoReal { get; set; } = null!;
        public double? AnticipoNew { get; set; }

        public virtual Terminal? NumTerminalNavigation { get; set; }
    }
}
