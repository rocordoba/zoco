using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegSessionesAliadoService
    {
        Task<List<RegSessionesAliado>> Lista();
        Task<RegSessionesAliado> Crear(RegSessionesAliado entidad);
        Task<RegSessionesAliado> Editar(RegSessionesAliado entidad);

    }
}
