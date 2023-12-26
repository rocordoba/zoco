namespace ZocoAplicacion.Models.ViewModels
{
    public class VMVisita
    {
        public int IdVisita { get; set; }
        public string? Observacion { get; set; }
        public string? Fecha { get; set; }
        public int? IdUsDotacion { get; set; }
        public string? DescUsuario { get; set; }
        public int? IdTerminal { get; set; }
        public string? DescNumTerminal { get; set; }
        public int? EstadoVisitas { get; set; }
        public string? DescEstadoVisitas { get; set; }
        public int? Coordenadas { get; set; }
        public string? CoordLongitud { get; set; }
        public string? CoordLatitud { get; set; }
        public string? ImgTerminalUrl { get; set; }
    }

}
