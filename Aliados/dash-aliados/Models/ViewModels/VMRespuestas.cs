namespace ZocoAplicacion.Models.ViewModels
{
    public class VMRespuestas
    {
        public int IdRespuesta { get; set; }
        public int? CorrectaIncorrecta { get; set; }
        public int Puntaje { get; set; }
        public int? Pregunta { get; set; }
        public string? Descripcion { get; set; }

    }
}
