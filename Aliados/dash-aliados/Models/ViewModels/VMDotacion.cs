namespace ZocoAplicacion.Models.ViewModels
{
    public class VMDotacion
    {

        public int IdDotacion { get; set; }
        public string? ApellidoNombre { get; set; }
        public string? CuitCuil { get; set; }
        public int? IdUsuario { get; set; }
        public string? descIdUsuario { get; set; }

        public string? Correo { get; set; }
        public string? EsActivo { get; set; }
        public string? FechaBaja { get; set; }
        public string? FechaAlta { get; set; }
        public string? Cargo { get; set; }
        public string? TipoCuenta { get; set; }
        public string? CbuCvu { get; set; }
        public string? NumCta { get; set; }
        public string? AliasCbu { get; set; }
        public string? Legajos { get; set; }
        public string? Observaciones { get; set; }
        public string? Telefono { get; set; }
        public string? Domicilio { get; set; }
        public string? Contrato { get; set; }
        public string? ExentoComision { get; set; }
        public string? ExentoDescuento { get; set; }
        public string? Sexo { get; set; }
        public string? Jefe { get; set; }
        public string? Posicion { get; set; }
        public string? GestionCompletada { get; set; }
        public int? NivelFacturacionAbm { get; set; }
        public int? NivelActivacionAbm { get; set; }
        public int? NivelAutoCalActivacion { get; set; }
        public string? FrenarPago { get; set; }
        public int? CantDeTerminales { get; set; }
        public int? DiasParVisitas { get; set; }
        public int? Provincia { get; set; }
        public string? descProvincia { get; set; }

        public int? ProvinciaDos { get; set; }
        public string? descProvinciaDos { get; set; }

        public int? Banco { get; set; }
        public string? descBanco { get; set; }

        public int? EscalaAlcanzada { get; set; }

    }
}