using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImpuestosVariosService
    {

        Task<List<ImpuestosVarios>> Lista();
        Task<bool> Eliminar(int idImpuestosVarios);
        Task<ImpuestosVarios> Crear(ImpuestosVarios entidad);
        Task<ImpuestosVarios> Editar(ImpuestosVarios entidad);


    }
}
