using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEncuestaService
    {

        Task<List<Encuesta>> Lista();
        Task<Encuesta> Crear(Encuesta entidad);
        Task<Encuesta> Editar(Encuesta entidad);
        Task<bool> Eliminar(int idEncuesta);


    }
}
