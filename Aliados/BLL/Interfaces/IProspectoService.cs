using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProspectoService
    {
        Task<List<Prospectos>> Lista();
        Task<bool> Eliminar(int IdProspecto);
        Task<Prospectos> Crear(Prospectos entidad);
        Task<Prospectos> Editar(Prospectos entidad);
    }
}
