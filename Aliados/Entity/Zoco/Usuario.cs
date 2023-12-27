using System;
using System.Collections.Generic;

namespace Entity.Zoco
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            CalificoComs = new HashSet<CalificoCom>();
            Calificos = new HashSet<Califico>();
        }

        public string? Usuario { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public int? TipoUsuario { get; set; }
        public int? CambioClave { get; set; }
        public int Id { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<CalificoCom> CalificoComs { get; set; }
        public virtual ICollection<Califico> Calificos { get; set; }
    }
}
