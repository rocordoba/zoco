namespace ZocoAplicacion.Models.ViewModels
{
    public class VMTicketTerminal
    {

        public int IdTicketTerminal { get; set; }
        public int? Fantasia { get; set; }
        public string? descFantasia { get; set; }
        public int? Asesor { get; set; }
        public string? descAsesor { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta { get; set; }
        public double? MontoFavorBruto { get; set; }
        public double? MontoNegativoBruto { get; set; }
        public int? Mes { get; set; }
        public int? IdTerminalTickey { get; set; }
        public string? descIdTerminalTickey { get; set; }


        public string? Debito { get; set; }
        public string? Credito { get; set; }
        public string? UnPago { get; set; }
        public int? IdRazsocial { get; set; }
        public string? DescTerminal { get; set; }
        public string? FaltaVisita { get; set; }
    }
}
