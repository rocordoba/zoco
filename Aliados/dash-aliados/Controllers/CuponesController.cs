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
    public class CuponesController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public CuponesController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }

        [HttpPost("cupones")]
        public async Task<ActionResult> Cupones([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);

                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);
                //   var inflacion = await _inflacionService.ObtenerPorRubro(usuarioEncontrado.Usuario);

                var totalOperaciones = ObtenerTotalOperaciones(sas);
                var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);

                // Llamada al método para obtener las sumas por día
                var sumasPorDia = ObtenerSumaPorDia(listaMes);

                var resultado = new
                {
                    AñoActual = request.Year,
                    TotalOperaciones = totalOperaciones,
                    listaMes = sumasPorDia // Aquí usamos las sumas por día en lugar de la lista original
                };

                return StatusCode(StatusCodes.Status200OK, resultado);
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }


        private double ObtenerTotalOperaciones(List<BaseDashboard> sas)
        {
            return (double)sas.Count();
        }
        private List<BaseDashboard> ObtenerListaPorRangoFecha(List<BaseDashboard> sas, DateTime fechaInicio, DateTime fechaFin)
        {
            return sas.Where(s => s.FechaDePago >= fechaInicio.Date && s.FechaDePago <= fechaFin.Date).ToList();
        }
       

        public List<object> ObtenerSumaPorDia(List<BaseDashboard> lista)
        {
            var sumasPorDia = lista
                .GroupBy(item => item.FechaDePago)
                .Select(group => new
                {
                    Fecha = group.Key,
                    Totales = new
                    {
                        TotalBruto = group.Sum(item => item.TotalBruto ?? 0),
                        CostoFinancieroEn = group.Sum(item => item.CostoFinancieroEn ?? 0),
                        Arancel = group.Sum(item => item.Arancel ?? 0),
                        Iva21 = group.Sum(item => item.Iva21 ?? 0),
                        ImpuestoDebitoCredito = group.Sum(item => item.ImpuestoDebitoCredito ?? 0),
                        RetencionProvincial = group.Sum(item => item.RetencionProvincial ?? 0),
                        RetencionGanacia = group.Sum(item => item.RetencionGanacia ?? 0),
                        RetencionIva = group.Sum(item => item.RetencionIva ?? 0),
                        TotalConDescuentos = group.Sum(item => item.TotalConDescuentos ?? 0)
                    }
                })
                .Select(x => new
                {
                    Fecha = x.Fecha,
                    x.Totales.TotalBruto,
                    x.Totales.CostoFinancieroEn,
                    x.Totales.Arancel,
                    x.Totales.Iva21,
                    x.Totales.ImpuestoDebitoCredito,
                    x.Totales.RetencionProvincial,
                    x.Totales.RetencionGanacia,
                    x.Totales.RetencionIva,
                    x.Totales.TotalConDescuentos
                })
                .ToList<object>();

            return sumasPorDia;
        }


    }
}
