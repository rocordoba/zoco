using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IDotacionService
    {
        //Task<List<Dotacion>> obtenerPorActivos();
        Task<List<Dotacion>> Lista();
        Task<bool> Eliminar(int idDotacion);
        Task<Dotacion> Crear(Dotacion entidad);
        Task<Dotacion> Editar(Dotacion entidad);
    }
}
