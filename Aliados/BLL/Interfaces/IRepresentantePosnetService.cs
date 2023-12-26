using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRepresentantePosnetService
    {

        Task<List<RepPosnet>> Lista();
        Task<RepPosnet> Crear(RepPosnet entidad);
        Task<RepPosnet> Editar(RepPosnet entidad);
        Task<bool> Eliminar(int IdRepresentantePosnet);

    }
}
