using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGestionesCompletadasService
    {

        Task<List<GestionesCompletadas>> Lista();
        Task<GestionesCompletadas> Crear(GestionesCompletadas entidad);
        Task<GestionesCompletadas> Editar(GestionesCompletadas entidad);
        Task<bool> Eliminar(int IdGestionesCompletadas);

    }
}
