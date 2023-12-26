namespace ZocoAplicacion.Models.ViewModels
{
    public class VMTarea
    {
        public int IdTarea { get; set; }
        public int? IdEstado { get; set; }
        public string? FechaCreacion { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? TituloTarea { get; set; }
        public string? Descripcion { get; set; }
        public int? Recordar { get; set; }
        public string? CadaCuanto { get; set; }
        public int? IdAutor { get; set; }
        public string? descIdAutor { get; set; }
        public int? IdPrioridad { get; set; }
        public string? descIdPrioridad { get; set; }
        public int? IdTipoTarea { get; set; }
        public string? descIdTipoTarea { get; set; }
        public int? IdProspecto { get; set; }
        public int? Asesor { get; set; }
        public string? descAsesor { get; set; }
        public int? EstadoTarea { get; set; }
        public string? descEstadoTarea { get; set; }
        public int? IdObservaciones { get; set; }
        public string? descObservacion { get; set; }

    }
}
