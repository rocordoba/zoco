using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStockTerminalesService
    {
        Task<List<StockTerminales>> Lista();
        Task<bool> Eliminar(int idStockTerminales);
        Task<StockTerminales> Crear(StockTerminales entidad);
        Task<StockTerminales> Editar(StockTerminales entidad);


    }
}
