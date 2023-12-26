using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Usuario
    {
        public Usuario()
        {
            HistCorreoAliados = new HashSet<HistCorreoAliado>();
            LoggAliados = new HashSet<LoggAliado>();
            RazonSocials = new HashSet<RazonSocial>();
            RegSessionesAliados = new HashSet<RegSessionesAliado>();
        }

        public int IdUsuario { get; set; }
        public double? UsuarioCuit { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public double? Telefono { get; set; }
        public int? TipoUsuario { get; set; }
        public string? Clave { get; set; }
        public int? CambioClave { get; set; }
        public int? Puntaje { get; set; }
        public int? Constante { get; set; }
        public int? Califico { get; set; }
        public int? Activo { get; set; }

        public virtual Rol? TipoUsuarioNavigation { get; set; }
        public virtual ICollection<HistCorreoAliado> HistCorreoAliados { get; set; }
        public virtual ICollection<LoggAliado> LoggAliados { get; set; }
        public virtual ICollection<RazonSocial> RazonSocials { get; set; }
        public virtual ICollection<RegSessionesAliado> RegSessionesAliados { get; set; }
    }
}
