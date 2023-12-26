using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHistCorreoNosService
    {
        Task<List<HistCorreoNosot>> Lista();
        Task<HistCorreoNosot> Crear(HistCorreoNosot entidad);
        Task<HistCorreoNosot> Editar(HistCorreoNosot entidad);
        Task<bool> Eliminar(int IdHistCorreoNos);
    }
}
