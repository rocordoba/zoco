using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TarjetaCuotas
    {
        public int IdTarjetas { get; set; }
        public string? Tarjeta { get; set; }
        public string? TarjetaResumida { get; set; }
        public double? PorcentajeTarj { get; set; }
        public int? Cuota { get; set; }
        public string? Tipo { get; set; }
        public string? CodigoPosnetVisaCredito { get; set; }
        public string? CodigoPosnetAmericanExpressCredito { get; set; }
        public string? CodigoPosnetMastercardCredito { get; set; }
        public string? CodigoPosnetArgencardCredito { get; set; }
        public string? CodigoPosnetCabalCredito { get; set; }
        public string? CodigoPosnetNaranjaCredito { get; set; }
        public string? CodigoPosnetVisaDebito { get; set; }
        public string? CodigoPosnetMaestroDebito { get; set; }
        public string? CodigoPosnetMastercardDebito { get; set; }
        public double? CostoVisaDebito { get; set; }
        public double? CostoMaestroDebito { get; set; }
        public double? CostoMastercardDebito { get; set; }
        public double? CostoVisaCredito { get; set; }
        public double? CostoAmericanExpressCredito { get; set; }
        public double? CostoMastercardCredito { get; set; }
        public double? CostoArgencardCredito { get; set; }
        public double? CostoCabalCredito { get; set; }
        public double? CostoNaranjaCredito { get; set; }
        public double? Iva { get; set; }
        public double? RetenciaonesIibb { get; set; }
        public double? Comision { get; set; }
        public double? ComisionMasIva { get; set; }
    }
}
