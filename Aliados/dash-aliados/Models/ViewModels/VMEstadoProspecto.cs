namespace ZocoAplicacion.Models.ViewModels
{
    public class VMEstadoProspecto
    {

        public int IdEstadoProspecto { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechFin { get; set; }
        public int? Logrado { get; set; }
        public int? IdProspectoPadre { get; set; }
        public int? Tipo { get; set; }
        public string? descTipo { get; set; }
        public int? IdEncuesta { get; set; }
        public int? Coord { get; set; }
        public string? longitud { get; set; }
        public string? latitud { get; set; }


    }
}
