namespace ZocoAplicacion.Models.ViewModels
{
    public class VMMetricasDotacion
    {

        public int IdMetrica { get; set; }
        public int? Dotacion { get; set; }
        public string? descDotacion { get; set; }

        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public int? Cantidad { get; set; }
        public int? Efectividad { get; set; }
        public string? PromedioDeEfectividad { get; set; }
        public int? Tipo { get; set; }
        public string? descTipo { get; set; }


    }
}
