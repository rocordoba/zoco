namespace ZocoAplicacion.Models.ViewModels
{
    public class VMCoincidenciasCoord
    {
        public int IdCoincidenciasCoord { get; set; }
        public int? IdUserUno { get; set; }
        public string? DescIdUserUno { get; set; }
        public int? IdUserDoos { get; set; }
        public string? DescIdUserDoos { get; set; }
        public int? IdUserCoordenadaUna { get; set; }
        public string? LongCoorUna { get; set; }
        public string? LatCoorUna { get; set; }
        public int? IdUserCoordenadaDos { get; set; }
        public string? LongCoorDos { get; set; }
        public string? LatCoorDos { get; set; }
        public string? FechaCoincidencia { get; set; }

    }
}
