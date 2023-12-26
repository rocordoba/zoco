namespace ZocoAplicacion.Models.ViewModels
{
    public class VMMovimientoTerm
    {
        public int IdMovimiento { get; set; }
        public int? Fantasia { get; set; }
        public string? DescFantasia { get; set; }

        public int? Estado { get; set; }
        public string? DescEstado { get; set; }

        public int? EstadoMovimiento { get; set; }
        public string? DescEstadoMovimiento { get; set; }

        public int? Terminal { get; set; }
        public int? AsesorAntes { get; set; }
        public string? DescAsesorAntes { get; set; }

        public int? AsesorActual { get; set; }
        public string? DescAsesorActual { get; set; }

        public string? ProgramacionBaja { get; set; }
        public int? DiasParaAlta { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public int? FantasiaAntes { get; set; }
        public string? DescFantasiaAntes { get; set; }

        public int? Origen { get; set; }
        public string? descOrigen { get; set; }
        public int? Destino { get; set; }
        public string? descDestino { get; set; }


    }
}
