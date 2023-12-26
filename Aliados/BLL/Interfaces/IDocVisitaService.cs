using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDocVisitaService
    {
        Task<List<DocVisita>> Lista();
        Task<DocVisita> Crear(DocVisita entidad);
        Task<DocVisita> Editar(DocVisita entidad);
        Task<bool> Eliminar(int IdDocVisita);
    }
}
