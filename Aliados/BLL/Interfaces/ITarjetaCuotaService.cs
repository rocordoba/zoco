using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITarjetaCuotaService
    {

        Task<List<TarjetaCuotas>> Lista();
        Task<bool> Eliminar(int idTarjetaCuota);
        Task<TarjetaCuotas> Crear(TarjetaCuotas entidad);
        Task<TarjetaCuotas> Editar(TarjetaCuotas entidad);
    }
}
