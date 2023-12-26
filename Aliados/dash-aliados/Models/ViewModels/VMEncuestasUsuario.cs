namespace ZocoAplicacion.Models.ViewModels
{
    public class VMEncuestasUsuario
    {
        public int IdRespuestaUsuario { get; set; }
        public int IdEncuesta { get; set; }
        public int? IntRespuesta { get; set; }
        public int? IntUsuario { get; set; }
        public int? PuntajeTotal { get; set; }

    }
}
