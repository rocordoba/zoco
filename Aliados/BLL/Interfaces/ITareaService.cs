using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITareaService
    {
        Task<List<Tarea>> Lista();
        Task<bool> Eliminar(int idTarea);
        Task<Tarea> Crear(Tarea entidad);
        Task<Tarea> Editar(Tarea entidad);
    }
}
