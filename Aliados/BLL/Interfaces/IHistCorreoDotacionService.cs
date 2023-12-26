using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHistCorreoDotacionService
    {

        Task<List<HistCorreoDotacion>> Lista();
        Task<HistCorreoDotacion> Crear(HistCorreoDotacion entidad);
        Task<HistCorreoDotacion> Editar(HistCorreoDotacion entidad);
        Task<bool> Eliminar(int IdHistCorreoDotacion);
    }
}
