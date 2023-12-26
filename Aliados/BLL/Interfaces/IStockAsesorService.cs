using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStockAsesorService
    {

        Task<List<StockAsesor>> Lista();
        //Task<List<Dotacion>> obtenerPorActivos();
        Task<bool> Eliminar(int idStockAsesor);
        Task<StockAsesor> Crear(StockAsesor entidad);
        Task<StockAsesor> Editar(StockAsesor entidad);


    }
}
