using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegSessionesDotacionService
    {
        Task<List<RegSessionesDotacion>> Lista();
        Task<RegSessionesDotacion> Editar(RegSessionesDotacion entidad);

        Task<RegSessionesDotacion> Crear(RegSessionesDotacion entidad);

    }
}
