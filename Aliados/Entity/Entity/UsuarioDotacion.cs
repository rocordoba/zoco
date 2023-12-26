using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class UsuarioDotacion
    {
        public UsuarioDotacion()
        {
            HistCorreoDotacions = new HashSet<HistCorreoDotacion>();
            LoggDotacions = new HashSet<LoggDotacion>();
            Nota = new HashSet<Nota>();
            ObsTareas = new HashSet<ObsTarea>();
            Prospectos = new HashSet<Prospectos>();
            RegSessionesDotacions = new HashSet<RegSessionesDotacion>();
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
        public virtual ICollection<HistCorreoDotacion> HistCorreoDotacions { get; set; }
        public virtual ICollection<LoggDotacion> LoggDotacions { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<ObsTarea> ObsTareas { get; set; }
        public virtual ICollection<Prospectos> Prospectos { get; set; }
        public virtual ICollection<RegSessionesDotacion> RegSessionesDotacions { get; set; }
    }
}
