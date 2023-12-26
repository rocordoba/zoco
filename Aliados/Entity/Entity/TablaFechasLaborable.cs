using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class TablaFechasLaborable
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Dia { get; set; }
        public string? Laborable { get; set; }
        public DateTime? MaximaFechaDeOperacion { get; set; }
        public DateTime? MaxFecOpParaMes { get; set; }
        public DateTime? MaxFecDePagoParaMes { get; set; }
        public DateTime? PrimDiaDelMes { get; set; }
        public DateTime? UltimoDiaDelMes { get; set; }
        public DateTime? PrimFechaDePago { get; set; }
        public DateTime? PrimFechaDePagoMesSgte { get; set; }
        public int? DiferenciaDias { get; set; }
        public double? CantParaReubicar80 { get; set; }
        public double? CantParaBajoAnalis { get; set; }
        public double? CantParaTicketProm700 { get; set; }
        public double? CantTermBajo10Mil { get; set; }
        public double? CostoTerminal { get; set; }
    }
}
