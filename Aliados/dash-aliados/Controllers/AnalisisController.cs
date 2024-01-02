using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Entity.Zoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisisController : ControllerBase
    {

        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;
        private readonly IInflacionService _inflacionService;

        public AnalisisController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco,IInflacionService inflacionService)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
            _inflacionService = inflacionService;
        }
        [HttpPost("analisis")]
        public async Task<ActionResult> Analisis([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);
             //   var inflacion = await _inflacionService.ObtenerPorRubro(usuarioEncontrado.Usuario);

                var totalOperaciones = ObtenerTotalOperaciones(sas);
                var totalConDescuentoCuotas0 = ObtenerTotalConDescuentoCuotas(sas, 0);
                var totalConDescuentoCuotas1 = ObtenerTotalConDescuentoCuotas(sas, 1);
                var totalConDescuentoCuotas2 = ObtenerTotalConDescuentoCuotas(sas, 2);
                var totalCuotas = totalConDescuentoCuotas1 + totalConDescuentoCuotas2;
                // var tarea = ObtenerResumenUltimos7Meses(sas);
                // var resumenUltimos7Meses = tarea.Result;
               
                var debito = ObtenerTicketPromedio(sas, 0);
                var credito = ObtenerTicketPromedio(sas, 1);
                var porcentajeporcuotas = ObtenerPorcentaje(totalConDescuentoCuotas0, totalCuotas);
                var porcentajeticket = ObtenerPorcentaje(debito, credito);
                var porcentajetipopago = ObtenerPorcentaje(totalConDescuentoCuotas0, totalConDescuentoCuotas1);
                var resultado = new
                {
                    AñoActual = request.Year,
                    TotalOperaciones = totalOperaciones,
                    TotalConDescuentoCuotas0 = totalConDescuentoCuotas0,
                    TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                    TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,
                    TotalCuotas= totalCuotas,
                  //  ResumenUltimos7Meses = resumenUltimos7Meses,
                    Porcentajeporcuotas = porcentajeporcuotas,
                    Porcentajeticket = porcentajeticket,
                    Porcentajetipopago = porcentajetipopago,
                    Debito = debito,
                    Credito = credito
                };

                return StatusCode(StatusCodes.Status200OK, resultado);
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }
        private double ObtenerTotalOperaciones(List<BaseDashboard> sas)
        {
            return (double)sas.Count();
        }
        private double ObtenerTotalConDescuentoCuotas(List<BaseDashboard> sas, int cuotas)
        {
            if (cuotas == 2)
            {
                return (double)sas.Where(s => s.Cuotas >= cuotas)
                                  .Sum(s => s.TotalConDescuentos ?? 0);
            }
            else
            {
                return (double)sas.Where(s => s.Cuotas == cuotas)
                                  .Sum(s => s.TotalConDescuentos ?? 0);
            }
        }
        public async Task<List<object>> ObtenerResumenUltimos7Meses(List<BaseDashboard> sas)
        {
            DateTime primerDiaMesActual = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var resumenUltimos7Meses = new List<object>();
            string primerCuit = sas.FirstOrDefault()?.Cuit?.ToString();

            var inflacion = await _inflacionService.ObtenerPorRubro(primerCuit);

            for (int i = 0; i < 7; i++)
            {
                DateTime fechaMes = primerDiaMesActual.AddMonths(-i);
                DateTime primerDiaMes = new DateTime(fechaMes.Year, fechaMes.Month, 1);
                DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                // Obtener el mes siguiente, teniendo en cuenta la transición de año
                DateTime fechaMesSiguiente;
                if (fechaMes.Month == 12)
                {
                    fechaMesSiguiente = new DateTime(fechaMes.Year + 1, 1, 1);
                }
                else
                {
                    fechaMesSiguiente = fechaMes.AddMonths(1);
                }

                var datosMes = sas.Where(s =>
                    s.FechaDePago >= primerDiaMes && s.FechaDePago <= ultimoDiaMes
                ).ToList();

                decimal? totalBruto = datosMes.Sum(s => s.TotalBruto);
                int cantidadDatos = datosMes.Count;

                var inflacionMes = inflacion.FirstOrDefault(inf => inf.Fecha?.Month == fechaMesSiguiente.Month && inf.Fecha?.Year == fechaMesSiguiente.Year)?.Inflacion1 ?? 0; // Obtener el porcentaje de inflación para el mes siguiente


                // Calcula el total bruto menos el porcentaje de inflación
                double? totalBrutoMenosInflacion = 0; // Valor predeterminado

                if (inflacionMes != 0)
                {
                    totalBrutoMenosInflacion = Convert.ToDouble(totalBruto) - (Convert.ToDouble(totalBruto) * inflacionMes / 100);
                }

                var resumenMes = new
                {
                    Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fechaMes.Month).ToUpper(),
                    TotalBruto = totalBruto,
                    CantidadDatos = cantidadDatos,
                    Inflacion = inflacionMes,
                    TotalBrutoMenosInflacion = totalBrutoMenosInflacion
                };


                resumenUltimos7Meses.Add(resumenMes);
            }

            return resumenUltimos7Meses;
        }






        private double ObtenerPorcentaje(double comparativaHoy, double comparativaDiaAnterior)
        {
            var compa = comparativaHoy - comparativaDiaAnterior;
            var resultado = compa / comparativaHoy;
            return resultado;
        }
        private double ObtenerTicketPromedio(List<BaseDashboard> sas, int cuotas)
        {
            if (cuotas == 0)
            {
                var totaltipo = (double)sas.Where(s => s.Cuotas == cuotas && s.FechaDePago.HasValue && s.FechaDePago.Value.Month == DateTime.Today.Month)
                                               .Sum(s => s.TotalBruto ?? 0);

                var totaloperaciones = (double)sas.Count(s => s.Cuotas == cuotas);

                var ticket = totaltipo / totaloperaciones;
                return ticket;
            }else
            {
                var totaltipo = (double)sas.Where(s => s.Cuotas >= cuotas && s.FechaDePago.HasValue && s.FechaDePago.Value.Month == DateTime.Today.Month)
                                             .Sum(s => s.TotalBruto ?? 0);

                var totaloperaciones = (double)sas.Count(s => s.Cuotas == cuotas);

                var ticket = totaltipo / totaloperaciones;
                return ticket;
            }
           
        }

      
    }
}
