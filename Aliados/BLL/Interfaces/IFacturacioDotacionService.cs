using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFacturacioDotacionService
    {

        Task<List<FacturacionDotacion>> Lista();
        Task<FacturacionDotacion> Crear(FacturacionDotacion entidad);
        Task<FacturacionDotacion> Editar(FacturacionDotacion entidad);
        Task<bool> Eliminar(int IdFacturacioDotacion);

    }
}
