namespace ZocoAplicacion.Models.ViewModels
{
    public class VMNota
    {
        public int IdNota { get; set; }
        public string? Titulo { get; set; }
        public string? Observaciones { get; set; }
        public string? FechaAlta { get; set; }
        public int? IdAsesor { get; set; }
        public string? descAsesor { get; set; }
        public int? IdTipoNota { get; set; }
        public string? descTipoNota { get; set; }
        public int? TipoPrioridad { get; set; }
        public string? descTipoPrioridad { get; set; }
        public int? IdProspecto { get; set; }

    }
}
