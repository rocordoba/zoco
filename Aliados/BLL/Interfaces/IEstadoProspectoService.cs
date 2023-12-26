using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEstadoProspectoService
    {
        Task<List<EstadoProspecto>> Lista();
        Task<bool> Eliminar(int IdEstadoProspecto);
        Task<EstadoProspecto> Crear(EstadoProspecto entidad);
        Task<EstadoProspecto> Editar(EstadoProspecto entidad);
    }
}
