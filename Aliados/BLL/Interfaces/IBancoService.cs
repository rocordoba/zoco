using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBancoService
    {
        Task<List<Banco>> Lista();
        Task<Banco> Crear(Banco entidad);
        Task<Banco> Editar(Banco entidad);
        Task<bool> Eliminar(int idBanco);

    }
}
