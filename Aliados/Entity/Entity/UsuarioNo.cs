using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class UsuarioNo
    {
        public UsuarioNo()
        {
            Coordenada = new HashSet<Coordenadum>();
            HistCorreoNosots = new HashSet<HistCorreoNosot>();
            LoggNosotros = new HashSet<LoggNosotro>();
            NoticiasDots = new HashSet<NoticiasDot>();
            ObsTareas = new HashSet<ObsTarea>();
            RegSessionesNos = new HashSet<RegSessionesNo>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public string? Clave { get; set; }
        public int? CambioClave { get; set; }
        public int? Puntaje { get; set; }
        public int? Activo { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Coordenadum> Coordenada { get; set; }
        public virtual ICollection<HistCorreoNosot> HistCorreoNosots { get; set; }
        public virtual ICollection<LoggNosotro> LoggNosotros { get; set; }
        public virtual ICollection<NoticiasDot> NoticiasDots { get; set; }
        public virtual ICollection<ObsTarea> ObsTareas { get; set; }
        public virtual ICollection<RegSessionesNo> RegSessionesNos { get; set; }
    }
}
