using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INoticiaAliService
    {

        Task<List<Noticias>> Lista();
        Task<Noticias> Crear(Noticias entidad);
        Task<Noticias> Editar(Noticias entidad);
        Task<bool> Eliminar(int IdNoticias);

    }
}
