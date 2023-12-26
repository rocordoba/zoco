using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IVisitaService
    {
        Task<List<Visita>> Lista();
        Task<Visita> Crear(Visita entidad);
        Task<Visita> Editar(Visita entidad);
        Task<bool> Eliminar(int IdVisitas);
    }
}
