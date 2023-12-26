namespace ZocoAplicacion.Models.ViewModels
{
    public class VMProspecto
    {
        public int IdProspecto { get; set; }
        public int? IdUsuario { get; set; }
        public string? DescUser { get; set; }

        public string? NombreResponsable { get; set; }
        public string? TelefonoRespon { get; set; }
        public string? FactAprox { get; set; }
        public int? TermCerrada { get; set; }
        public int? TermProyectadas { get; set; }
        public string? Observaciones { get; set; }
        public int? Provincia { get; set; }
        public string? descProvincia { get; set; }
        public int? IdTipoPros { get; set; }
        public string? descTipo { get; set; }


    }
}
