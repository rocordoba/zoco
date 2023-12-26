namespace ZocoAplicacion.Models.ViewModels
{
    public class VMUsuarioNos
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public string? DescRol { get; set; }
        public string? Clave { get; set; }
        public int? CambioClave { get; set; }
        public int? Puntaje { get; set; }
        public int? Activo { get; set; }

    }
}
