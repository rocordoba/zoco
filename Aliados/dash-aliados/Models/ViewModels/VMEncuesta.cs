namespace ZocoAplicacion.Models.ViewModels
{
    public class VMEncuesta
    {

        public int IdEncuesta { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int PuntajeTotal { get; set; }

    }
}
