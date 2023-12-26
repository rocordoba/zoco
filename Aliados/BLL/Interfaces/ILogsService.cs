using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Entity.Entity;

namespace BLL.Interfaces
{
    public interface ILogsService
    {
        Task<List<LoggNosotro>> Lista();
        Task<LoggNosotro> Crear(LoggNosotro entidad);

    }
}
