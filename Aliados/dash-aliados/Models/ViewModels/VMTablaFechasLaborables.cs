namespace ZocoAplicacion.Models.ViewModels
{
    public class VMTablaFechasLaborables
    {
        public int Id { get; set; }
        public string? Fecha { get; set; }
        public string? Dia { get; set; }
        public string? Laborable { get; set; }
        public string? MaximaFechaDeOperacion { get; set; }
        public string? MaxFecOpParaMes { get; set; }
        public string? MaxFecDePagoParaMes { get; set; }
        public string? PrimDiaDelMes { get; set; }
        public string? UltimoDiaDelMes { get; set; }
        public string? PrimFechaDePago { get; set; }
        public string? PrimFechaDePagoMesSgte { get; set; }
        public int? DiferenciaDias { get; set; }
        public string? CantParaReubicar80 { get; set; }
        public string? CantParaBajoAnalis { get; set; }
        public string? CantParaTicketProm700 { get; set; }
        public string? CantTermBajo10Mil { get; set; }
        public string? CostoTerminal { get; set; }
    }
}
