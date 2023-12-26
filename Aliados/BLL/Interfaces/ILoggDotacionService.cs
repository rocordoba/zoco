using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILoggDotacionService
    {

        Task<List<LoggDotacion>> Lista();
        Task<LoggDotacion> Crear(LoggDotacion entidad);

    }
}
