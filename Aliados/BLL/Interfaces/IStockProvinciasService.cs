using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStockProvinciasService
    {
        Task<List<StockProvincias>> Lista();
        Task<bool> Eliminar(int idStockProvincias);
        Task<StockProvincias> Crear(StockProvincias entidad);
        Task<StockProvincias> Editar(StockProvincias entidad);
    }
}
