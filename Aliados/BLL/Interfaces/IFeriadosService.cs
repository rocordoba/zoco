using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFeriadosService
    {

        Task<List<Feriados>> Lista();
        Task<Feriados> Crear(Feriados entidad);
        Task<Feriados> Editar(Feriados entidad);
        Task<bool> Eliminar(int IdFeriados);


    }
}
