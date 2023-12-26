using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFactoresService
    {

        Task<List<Factores>> Lista();
        Task<Factores> Crear(Factores entidad);
        Task<Factores> Editar(Factores entidad);
        Task<bool> Eliminar(int IdFactores);

    }
}
