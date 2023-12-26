using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICoordenadaService
    {
        Task<List<Coordenada>> Lista();
        Task<Coordenada> Crear(Coordenada entidad);
        Task<Coordenada> Editar(Coordenada entidad);
        Task<bool> Eliminar(int IdCoordenada);
    }
}
