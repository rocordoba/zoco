using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Entity.Zoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContablidadController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public ContablidadController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpPost("contabilidad")]
        public async Task<ActionResult> Inicio([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario /*, request.Year, request.Month, request.Week, request.comercio*/);

                var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
                var totalNetoHoy = ObtenerTotalNeto(listaHoy);
                var totalBrutoHoy = ObtenerTotalBruto(listaHoy);
              
                var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                var totalIvaMes = ObtenerTotalIva(listaMes);
              
                var resultado = new
                {
                    AñoActual = request.Year,
                  
                    TotalNetoHoy = totalNetoHoy,
                    TotalBrutoHoy = totalBrutoHoy,
                 
                    TotalRetencionesMes = totalRetencionesMes,
                    TotalIvaMes = totalIvaMes
               
                };

                return StatusCode(StatusCodes.Status200OK, resultado);
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }

        private List<BaseDashboard> ObtenerListaPorFecha(List<BaseDashboard> sas, DateTime fecha)
        {
            return sas.Where(s => s.FechaDePago == fecha.Date).ToList();
        }
        private List<BaseDashboard> ObtenerListaPorRangoFecha(List<BaseDashboard> sas, DateTime fechaInicio, DateTime fechaFin)
        {
            return sas.Where(s => s.FechaDePago >= fechaInicio.Date && s.FechaDePago <= fechaFin.Date).ToList();
        }
        private double ObtenerTotalNeto(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalNeto);
        }
        private double ObtenerTotalBruto(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalBruto);
        }
        private double ObtenerTotalRetenciones(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.RetencionImpositiva);
        }
        private double ObtenerTotalIva(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.Arancel + s.Iva21);
        }
    }
}
