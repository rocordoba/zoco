using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface ISASService
    {
        Task<List<Sas>> DatosInicioAliados(int IdUsuario);
      //  Task<List<Sas>> DatosInicioAliadosFiltros(int IdUsuario);
        Task<List<Sas>> Lista();
        Task<List<Sas>> FactPorIdAsesorxRubro(int IdAsesor);
        Task<List<Sas>> FactPorProvinciaxRubro(int idProvincia);
        Task<List<Sas>> Historial(string fechaInicio, string fechaFin);
        Task<List<Sas>> ComisionxProvincia(int idProvincia);
        Task<List<Sas>> ComisionMesAnteriorXProvincia(int idProvincia);
        Task<List<Sas>> ComisionXidAsesor(int IdAsesor);
        Task<List<Sas>> ComisionMesAnteriorXidAsesor(int IdAsesor);
        Task<List<Sas>> FactXTipoXidAsesor(int IdAsesor);
        Task<List<Sas>> FactXTipoXProvincia(int idProvincia);
        Task<List<Sas>> TotalPorCobrarXAsesor(int IdAsesor);
        Task<List<Sas>> TotalPorCobrarXProvincia(int idProvincia);

        // los 5, o 1, esto es de SAS
        Task<List<Sas>> TerminalesXCincoFiltrosXAsesor(int IdAsesor, int decTomada, int TipoAlta, int Activación, int RazSoc);
        Task<List<Sas>> TerminalesXCincoFiltrosXProv(int IdProvincia, int decTomada, int TipoAlta, int Activación, int RazSoc);

    }
}
