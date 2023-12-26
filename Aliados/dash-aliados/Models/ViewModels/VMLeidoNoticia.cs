namespace ZocoAplicacion.Models.ViewModels
{
    public class VMLeidoNoticia
    {
        public int IdLeido { get; set; }
        public int? IdUser { get; set; }
        public string? descUserLeyo { get; set; }
        public string? FechaHora { get; set; }
        public int? IdNoticiaPadre { get; set; }
    }
}
