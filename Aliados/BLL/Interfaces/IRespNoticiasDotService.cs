using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRespNoticiasDotService
    {

        Task<List<RespNoticiasDot>> Lista();
        Task<RespNoticiasDot> Crear(RespNoticiasDot entidad);
        Task<RespNoticiasDot> Editar(RespNoticiasDot entidad);
        Task<bool> Eliminar(int IdRespNoticiasDot);

    }
}
