using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IRazonSocialService
    {
        Task<List<RazonSocial>> Lista();
        Task<RazonSocial> Crear(RazonSocial entidad);
        Task<RazonSocial> Editar(RazonSocial entidad);
        Task<bool> Eliminar(int IdRazonSocial);
    }
}
