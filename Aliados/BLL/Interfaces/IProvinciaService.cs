using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProvinciaService
    {
        Task<List<Provincia>> Lista();
        Task<Provincia> Crear(Provincia entidad);
        Task<Provincia> Editar(Provincia entidad);
        Task<bool> Eliminar(int IdProvincia);
        //Task<Provincia> obtenerPoractivas();
        //Task<Provincia> obtenerPorEstado(string idEstado);

    }
}
