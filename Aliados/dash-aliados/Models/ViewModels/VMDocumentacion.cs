namespace ZocoAplicacion.Models.ViewModels
{
    public class VMDocumentacion
    {
        public int IdDocumentacion { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreArchivo { get; set; }
        public string? UrlArchivo { get; set; }
        public int? IdAsesor { get; set; }
        public string? descAsesor { get; set; }
        public int? IdFantasia { get; set; }
        public string? descFantasia { get; set; }
        public int? Tipo { get; set; }
        public int? TipoAlta { get; set; }
        public string? descTipoAlta { get; set; }
        public int? TipoBaja { get; set; }
        public string? descTipoBaja { get; set; }
    }
}
