using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDocumentacionService
    {
        Task<List<Documentacion>> Lista();
        Task<Documentacion> Crear(Documentacion entidad);
        Task<Documentacion> Editar(Documentacion entidad);
        Task<bool> Eliminar(int IdDocumentacion);

    }
}
