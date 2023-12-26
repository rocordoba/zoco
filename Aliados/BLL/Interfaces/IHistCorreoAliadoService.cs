using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHistCorreoAliadoService
    {
        Task<List<HistCorreoAliado>> Lista();
        Task<HistCorreoAliado> Crear(HistCorreoAliado entidad);
        Task<HistCorreoAliado> Editar(HistCorreoAliado entidad);
        Task<bool> Eliminar(int IdHistCorreoAliado);

    }
}
