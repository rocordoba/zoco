using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Rol
    {
        public Rol()
        {
            RolMenus = new HashSet<RolMenu>();
            UsuarioNos = new HashSet<UsuarioNo>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }

        public virtual ICollection<RolMenu> RolMenus { get; set; }
        public virtual ICollection<UsuarioNo> UsuarioNos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
