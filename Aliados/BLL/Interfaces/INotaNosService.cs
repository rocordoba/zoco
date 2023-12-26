using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INotaNosService
    {

        Task<List<NotaNos>> Lista();
        Task<NotaNos> Crear(NotaNos entidad);
        Task<NotaNos> Editar(NotaNos entidad);
        Task<bool> Eliminar(int IdNotaNos);

    }
}
