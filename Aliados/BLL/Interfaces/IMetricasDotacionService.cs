using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMetricasDotacionService
    {

        Task<List<MetricasDotacion>> Lista();
        Task<bool> Eliminar(int idMetricasDotacion);
        Task<MetricasDotacion> Crear(MetricasDotacion entidad);
        Task<MetricasDotacion> Editar(MetricasDotacion entidad);

    }
}
