using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class NoticiasDot
    {
        public NoticiasDot()
        {
            LeidoNoticia = new HashSet<LeidoNoticium>();
            RespNoticiasDots = new HashSet<RespNoticiasDot>();
        }

        public int IdNoticias { get; set; }
        public int? IdUsDotacion { get; set; }
        public int? IdAutor { get; set; }
        public string? Descripcion { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaNot { get; set; }
        public int? Tipo { get; set; }

        public virtual UsuarioNo? IdAutorNavigation { get; set; }
        public virtual Dotacion? IdUsDotacionNavigation { get; set; }
        public virtual Prioridade? TipoNavigation { get; set; }
        public virtual ICollection<LeidoNoticium> LeidoNoticia { get; set; }
        public virtual ICollection<RespNoticiasDot> RespNoticiasDots { get; set; }
    }
}
