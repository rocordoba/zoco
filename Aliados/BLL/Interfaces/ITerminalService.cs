using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface ITerminalService
    {
        Task<List<Terminal>> Lista();
        Task<Terminal> Crear(Terminal entidad);
        Task<Terminal> Editar(Terminal entidad);
        Task<bool> Eliminar(int IdTerminales);
        Task<int> obtenerPorActivasTodas();
        Task<int> obtenerPorAltasTodas();
        Task<int> obtenerPorBajoAnalisisTodas();
        Task<int> obtenerPorReubicarTodas();
        Task<int> obtenerPorDisponibleTodas();
        Task<int> obtenerPorBajasTodas();
        Task<int> obtenerPorActivasXAsesor(int IdAsesor);
        Task<int> obtenerPorActivasXProvincia(int IdProvincia);
        Task<int> obtenerPorAltasXAsesor(int IdAsesor);
        Task<int> obtenerPorAltasXProvincia(int IdProvincia);
        Task<int> obtenerPorBajoAnalisisXAsesor(int IdAsesor);
        Task<int> obtenerPorBajoAnalisisXProvincia(int IdProvincia);
        Task<int> obtenerPorReubicarXAsesor(int IdAsesor);
        Task<int> obtenerPorReubicarXProvincia(int IdProvincia);
        Task<int> obtenerPorDisponiblesXAsesor(int IdAsesor);
        Task<int> obtenerPorDisponiblesXProvincia(int IdProvincia);
        Task<int> obtenerPorBajasXAsesor(int IdAsesor);
        Task<int> obtenerPorBajasXProvincia(int IdProvincia);
        Task<int> TerminalesTodasXIdAsesor(int IdAsesor);
        Task<int> TerminalesTodasXProvincia(int IdProvincia);


        //del charts- separadas por estado 
        Task<List<Terminal>> obtenerPorEstadoXAsesor(int IdEstado, int IdAsesor);
        Task<List<Terminal>> obtenerPorEstadoXProvincia(int IdEstado, int IdProvincia);
        Task<List<Terminal>> obtenerPorEstadoXAsesorMesPasado(int IdEstado, int IdAsesor);
        Task<List<Terminal>> obtenerPorEstadoXProvinciaMesPasado(int IdEstado, int IdProvincia);



        Task<List<Terminal>> TermPorRazSoc(int IdRazSoc);
        Task<List<Terminal>> TermPorRazSocXAsersor(int IdRazSoc, int IdAsesor);
        Task<List<Terminal>> TermPorRazSocXProvincia(int IdRazSoc, int IdProvincia);
        Task<List<Terminal>> obtenerPorNumTerm(int IdTerminales);


        //del charts- separadas por estado 
        Task<List<Terminal>> TermTodasXIdAsesor(int IdAsesor);
        Task<List<Terminal>> TermTodasXProvincia(int IdProvincia);


        //pueden recbiri los 5, o 1, esto es de SAS y del Charts
        Task<List<Terminal>> TerminalesXCincoFiltrosXAsesor(int IdAsesor, int decTomada, int TipoAlta, int Activación, int RazSoc);
        Task<List<Terminal>> TerminalesXCincoFiltrosXProv(int IdProvincia, int decTomada, int TipoAlta, int Activación, int RazSoc);

    }
}
