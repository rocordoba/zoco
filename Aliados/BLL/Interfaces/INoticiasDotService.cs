using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INoticiasDotService
    {
        Task<List<NoticiasDot>> Lista();
        Task<NoticiasDot> Crear(NoticiasDot entidad);
        Task<NoticiasDot> Editar(NoticiasDot entidad);
        Task<bool> Eliminar(int IdNoticiasDot);
    }
}
