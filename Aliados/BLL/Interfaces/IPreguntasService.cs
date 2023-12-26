using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPreguntasService
    {
        Task<List<Preguntas>> Lista();
        Task<Preguntas> Crear(Preguntas entidad);
        Task<Preguntas> Editar(Preguntas entidad);
        Task<bool> Eliminar(int IdPreguntas);
    }
}
