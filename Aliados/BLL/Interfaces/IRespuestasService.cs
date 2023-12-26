using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRespuestasService
    {

        Task<List<Respuestas>> Lista();
        Task<Respuestas> Crear(Respuestas entidad);
        Task<Respuestas> Editar(Respuestas entidad);
        Task<bool> Eliminar(int IdRespuestas);


    }
}
