using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPrioridadesService
    {
        Task<List<Prioridades>> Lista();
        Task<Prioridades> Crear(Prioridades entidad);
        Task<Prioridades> Editar(Prioridades entidad);
        Task<bool> Eliminar(int IdPrioridades);
    }
}
