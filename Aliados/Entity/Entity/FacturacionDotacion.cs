using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class FacturacionDotacion
    {
        public int? IdUsuarioDot { get; set; }
        public int? IdProvincia { get; set; }
        public double? ActBruto { get; set; }
        public double? ActComisionDebito { get; set; }
        public double? ActComision1Pago { get; set; }
        public double? ActComisionCredito { get; set; }
        public double? ActComisionPorActivacion { get; set; }
        public double? ActTotal { get; set; }
        public double? ActComisionCoorindacion { get; set; }
        public double? ActComisionGerencia { get; set; }
        public double? ActSubtotalSinDescuentos { get; set; }
        public double? ActDescuentoFiserv { get; set; }
        public double? ActDescuentoPorVisitas { get; set; }
        public double? ActDescuentoGerencial { get; set; }
        public double? ActDescuentoPorVisitaGerencialYCoordinador { get; set; }
        public double? ActSubTotalFinal { get; set; }
        public string? DescuentoPendiente { get; set; }
        public string? AjustesPositivos { get; set; }
        public double? ActTotalFinalOk { get; set; }
        public string? FrenarPago { get; set; }
        public double? ActDescuentoPorGestiones { get; set; }
        public double? FactTicketPromeido { get; set; }
        public double? FactBruto2 { get; set; }
        public double? FactCantTermin { get; set; }
        public double? FactComisionDebito2 { get; set; }
        public double? FactComision1Pago3 { get; set; }
        public double? FactComisionCredito4 { get; set; }
        public double? FactTotal2 { get; set; }
        public double? FactSubtotalSinDescuentos4 { get; set; }
        public double? FactSubTotalFinal2 { get; set; }
        public double? FactTotalFinalOk2 { get; set; }
        public double? FactDescuentoPorGestiones8 { get; set; }
        public double? TeoActBruto { get; set; }
        public double? TeoActComisionDebito { get; set; }
        public double? TeoActComision1Pago { get; set; }
        public double? TeoActComisionCredito { get; set; }
        public double? TeoActComisionPorActivacion { get; set; }
        public double? TeoActTotal { get; set; }
        public double? TeoActComisionCoorindacion { get; set; }
        public double? TeoActComisionGerencia { get; set; }
        public double? TeoActSubtotalSinDescuentos { get; set; }
        public double? TeoActDescuentoFiserv { get; set; }
        public double? TeoActDescuentoPorVisitas { get; set; }
        public double? TeoActDescuentoGerencial { get; set; }
        public double? TeoActDescuentoPorVisitaGerencialYCoordinador { get; set; }
        public double? TeoActSubTotalFinal { get; set; }
        public double? TeoActTotalFinalOk { get; set; }
        public double? TeoFactTicketPromeido { get; set; }
        public double? TeoFactBruto2 { get; set; }
        public double? TeoFactCantTermin { get; set; }
        public double? TeoFactComisionDebito2 { get; set; }
        public double? TeoFactComision1Pago3 { get; set; }
        public double? TeoFactComisionCredito4 { get; set; }
        public double? TeoFactTotal2 { get; set; }
        public double? TeoFactSubtotalSinDescuentos4 { get; set; }
        public double? TeoFactSubTotalFinal2 { get; set; }
        public double? TeoFactTotalFinalOk2 { get; set; }
        public double? TeoFactDescuentoPorGestiones8 { get; set; }
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public int? NoventaDias { get; set; }
        public int IdFact { get; set; }

        public virtual Provincium? IdProvinciaNavigation { get; set; }
        public virtual Dotacion? IdUsuarioDotNavigation { get; set; }
    }
}
