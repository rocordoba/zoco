using Entity.Entity;
using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesZoco
{
    public interface IBaseDashboardService
    {
      
        Task<List<BaseDashboard>> DatosInicioAliados(string CuitAliado);

       
        Task<List<BaseDashboard>> Lista();
    }
}
