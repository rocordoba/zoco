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
      
        Task<List<BaseDashboard>> DatosInicioAliados(string CuitAliado/*,int year,int month,int week,string comercio*/);

       
        Task<List<BaseDashboard>> Lista();
    }
}
