using System;
using System.Collections.Generic;

namespace Entity.Zoco
{
    public partial class Usuarios
    {
        public string? Usuario { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public int? TipoUsuario { get; set; }
        public int? CambioClave { get; set; }
        public int Id { get; set; }
        public string? Correo { get; set; }
    }
}
