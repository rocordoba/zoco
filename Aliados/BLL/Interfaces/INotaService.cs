using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INotaService
    {

        Task<List<Nota>> Lista();
        Task<Nota> Crear(Nota entidad);
        Task<Nota> Editar(Nota entidad);
        Task<bool> Eliminar(int IdNota);
    }
}
