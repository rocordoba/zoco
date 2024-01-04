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
        public async Task<ActionResult> Contabilidad([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var currentDate = DateTime.Today;
                var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                // Verificar si el año, mes y semana son actuales
                if (request.Year == currentDate.Year && request.Month == currentDate.Month && request.Week == currentWeek)
                {
                    var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                    var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);

                    // Verificar si el comercio es "Todos"
                    if (request.comercio.ToLower() == "todos")
                    {
                        //var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                        //var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario /*, request.Year, request.Month, request.Week, request.comercio*/);

                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                        var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
                        var totalNetoHoy = ObtenerTotalNeto(listaHoy);
                        var totalBrutoHoy = ObtenerTotalBruto(listaHoy);

                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                        var totalIvaMes = ObtenerTotalIva(listaMes);
                        var totalIva21Mes = ObtenerTotalIva21(listaMes);
                        var totalbrutomes = ObtenerTotalBruto(listaMes);
                        var totaldebito = totalbrutomes * 21;
                        var arancel = obtenerarancelmes(listaMes);
                        var ingresobruto = obteneringresobruto(listaMes);
                        var retencionganancia = obtenerretencionganancia(listaMes);
                        var resultado = new
                        {
                            AñoActual = request.Year,

                            TotalNetoHoy = totalNetoHoy,
                            TotalBrutoHoy = totalBrutoHoy,
                            TotalOperaciones = totalOperaciones,
                            TotalRetencionesMes = totalRetencionesMes,
                            TotalIvaMes = totalIvaMes,
                            TotalIva21Mes = totalIva21Mes,
                            Totaldebito = totaldebito,
                            Arancel = arancel,
                            TotalBrutoMes = totalbrutomes,
                            Ingresobruto = ingresobruto,
                            Retencionganancia = retencionganancia,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();

                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                        var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
                        var totalNetoHoy = ObtenerTotalNeto(listaHoy);
                        var totalBrutoHoy = ObtenerTotalBruto(listaHoy);

                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                        var totalIvaMes = ObtenerTotalIva(listaMes);
                        var totalIva21Mes = ObtenerTotalIva21(listaMes);
                        var totalbrutomes = ObtenerTotalBruto(listaMes);
                        var totaldebito = totalbrutomes * 21;
                        var arancel = obtenerarancelmes(listaMes);
                        var ingresobruto = obteneringresobruto(listaMes);
                        var retencionganancia = obtenerretencionganancia(listaMes);
                        var resultado = new
                        {
                            AñoActual = request.Year,

                            TotalNetoHoy = totalNetoHoy,
                            TotalBrutoHoy = totalBrutoHoy,
                            TotalOperaciones = totalOperaciones,
                            TotalRetencionesMes = totalRetencionesMes,
                            TotalIvaMes = totalIvaMes,
                            TotalIva21Mes = totalIva21Mes,
                            Totaldebito = totaldebito,
                            Arancel = arancel,
                            TotalBrutoMes = totalbrutomes,
                            Ingresobruto = ingresobruto,
                            Retencionganancia = retencionganancia,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                }
                else 
                {
                    var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                    var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);

                    // Verificar si el comercio es "Todos"
                    if (request.comercio.ToLower() == "todos")
                    {
                        //var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                        //var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario /*, request.Year, request.Month, request.Week, request.comercio*/);

                        DateTime fechaInicial = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicial);

                        var listaFiltrada = sas.Where(s =>
                            s.FechaDePago.HasValue &&
                            s.FechaDePago.Value.Year == request.Year &&
                            s.FechaDePago.Value.Month == request.Month &&
                            GetWeekOfYear(s.FechaDePago.Value) == request.Week)
                        .ToList();

                        var listaHoy = ObtenerListaPorFecha(listaFiltrada, fechaFinalDeLaSemana);
                        var listaMes = ObtenerListaPorRangoFecha(listaFiltrada, fechaInicial, fechaFinalDeLaSemana);

                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                        var totalIvaMes = ObtenerTotalIva(listaMes);
                        var totalIva21Mes = ObtenerTotalIva21(listaMes);
                        var totalbrutomes = ObtenerTotalBruto(listaMes);
                        var totaldebito = totalbrutomes * 21;
                        var arancel = obtenerarancelmes(listaMes);
                        var ingresobruto = obteneringresobruto(listaMes);
                        var retencionganancia = obtenerretencionganancia(listaMes);
                        var resultado = new
                        {
                            AñoActual = request.Year,

                            TotalNetoHoy = 0,
                            TotalBrutoHoy = 0,
                            TotalOperaciones = totalOperaciones,
                            TotalRetencionesMes = totalRetencionesMes,
                            TotalIvaMes = totalIvaMes,
                            TotalIva21Mes = totalIva21Mes,
                            Totaldebito = totaldebito,
                            Arancel = arancel,
                            TotalBrutoMes = totalbrutomes,
                            Ingresobruto = ingresobruto,
                            Retencionganancia = retencionganancia,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();

                        DateTime fechaInicial = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicial);

                        var listaFiltrada = sas.Where(s =>
                            s.FechaDePago.HasValue &&
                            s.FechaDePago.Value.Year == request.Year &&
                            s.FechaDePago.Value.Month == request.Month &&
                            GetWeekOfYear(s.FechaDePago.Value) == request.Week)
                        .ToList();
                        var listaHoy = ObtenerListaPorFecha(listaFiltrada, fechaFinalDeLaSemana);
                        var listaMes = ObtenerListaPorRangoFecha(listaFiltrada, fechaInicial, fechaFinalDeLaSemana);

                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                        var totalIvaMes = ObtenerTotalIva(listaMes);
                        var totalIva21Mes = ObtenerTotalIva21(listaMes);
                        var totalbrutomes = ObtenerTotalBruto(listaMes);
                        var totaldebito = totalbrutomes * 21;
                        var arancel = obtenerarancelmes(listaMes);
                        var ingresobruto = obteneringresobruto(listaMes);
                        var retencionganancia = obtenerretencionganancia(listaMes);
                        var resultado = new
                        {
                            AñoActual = request.Year,

                            TotalNetoHoy = 0,
                            TotalBrutoHoy = 0,
                            TotalOperaciones = totalOperaciones,
                            TotalRetencionesMes = totalRetencionesMes,
                            TotalIvaMes = totalIvaMes,
                            TotalIva21Mes = totalIva21Mes,
                            Totaldebito = totaldebito,
                            Arancel = arancel,
                            TotalBrutoMes = totalbrutomes,
                            Ingresobruto = ingresobruto,
                            Retencionganancia = retencionganancia,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                }
            }
            return Unauthorized("El token o el ID de la sesión no son válidos");
        }
        private DateTime GetFirstDayOfWeekInMonth(int year, int month, int weekNumber)
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            var firstDayOfMonth = new DateTime(year, month, 1);
            var dayOfWeek = cultureInfo.Calendar.GetDayOfWeek(firstDayOfMonth);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            var offset = (7 + (dayOfWeek - firstDayOfWeek)) % 7;
            var firstWeekStart = firstDayOfMonth.AddDays(-offset);
            var weekStart = firstWeekStart.AddDays((weekNumber - 1) * 7);

            // Asegurarse de que la fecha de inicio esté dentro del mes especificado
            return weekStart.Month == month ? weekStart : firstDayOfMonth;
        }
        private DateTime GetLastDayOfWeek(DateTime startDate)
        {
            var endDate = startDate.AddDays(6); // Asumiendo que una semana completa tiene 7 días

            // Asegurarse de que la fecha final no exceda el último día del mes
            var lastDayOfMonth = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
            if (endDate > lastDayOfMonth)
            {
                endDate = lastDayOfMonth;
            }

            return endDate;
        }
        private int GetWeekOfYear(DateTime date)
        {
            // Ejemplo de cálculo de la semana del año
            var cultureInfo = CultureInfo.CurrentCulture;
            var calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            return cultureInfo.Calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);
        }
        private DateTime GetLastDayOfWeek(DateTime date, int weekNumber)
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            var calendar = cultureInfo.Calendar;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            // Encontrar el primer día de la semana del año
            var firstDayOfYear = new DateTime(date.Year, 1, 1);
            var daysOffset = firstDayOfWeek - firstDayOfYear.DayOfWeek;
            var firstDayOfFirstWeek = firstDayOfYear.AddDays(daysOffset);

            // Calcular el último día de la semana solicitada
            var weekStart = firstDayOfFirstWeek.AddDays((weekNumber - 1) * 7);
            var weekEnd = weekStart.AddDays(6); // Sumar 6 días para llegar al domingo

            return weekEnd;
        }
        private object obtenerretencionganancia(List<BaseDashboard> listaMes)
        {
            return (double)listaMes.Sum(s => s.RetencionGanacia);
        }

        private object obteneringresobruto(List<BaseDashboard> listaMes)
        {
            return (double)listaMes.Sum(s => s.RetencionProvincial);
        }

        private object obtenerarancelmes(List<BaseDashboard> listaMes)
        {
            return (double)listaMes.Sum(s => s.Arancel);
        }

        private double ObtenerTotalOperaciones(List<BaseDashboard> sas)
        {
            return (double)sas.Count();
        }
        private double ObtenerTotalIva21(List<BaseDashboard> listaMes)
        {
            return (double)listaMes.Sum(s => s.Iva21);
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
            return (double)lista.Sum(s => s.TotalConDescuentos);
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
