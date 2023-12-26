using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMovimientoTermService
    {
        Task<List<MovimientoTerm>> Lista();
        Task<MovimientoTerm> Crear(MovimientoTerm entidad);
        Task<MovimientoTerm> Editar(MovimientoTerm entidad);
        Task<bool> Eliminar(int IdMovimientoTerm);
    }
}
