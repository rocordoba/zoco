using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITablaFechasLaborablesService
    {

        Task<List<TablaFechasLaborables>> Lista();
        Task<bool> Eliminar(int idTablaFechasLaborables);
        Task<TablaFechasLaborables> Crear(TablaFechasLaborables entidad);
        Task<TablaFechasLaborables> Editar(TablaFechasLaborables entidad);

    }
}
