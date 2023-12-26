using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegSessionesNosService
    {
        Task<List<RegSessionesNos>> Lista();
        Task<RegSessionesNos> Editar(RegSessionesNos entidad);

        Task<RegSessionesNos> Crear(RegSessionesNos entidad);

    }
}
