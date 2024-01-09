using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BLL.Interfaces;
using ZocoAplicacion.Models.ViewModels;
using BLL.Implementacion;
using Entity.Entity;
using System.Globalization;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using System;
using Entity.Zoco;
using System.Diagnostics.Eventing.Reader;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosInicioController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public DatosInicioController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<VMBaseDashboard>>> Lista()
        {

            var sasLista = await _baseService.Lista();


            if (sasLista == null || sasLista.Count == 0)
            {
                return NotFound("No hay datos para la lista de Sas");
            }


            var sasListaVM = sasLista.Select(s => _mapper.Map<VMBaseDashboard>(s)).ToList();

            return Ok(sasListaVM);
        }


        [HttpPost("base")]
        public async Task<ActionResult> Inicio([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var currentDate = DateTime.Today;
                var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);
                // Verificar si el año, mes y semana son actuales
                if (request.Year == currentDate.Year && request.Month == currentDate.Month && request.Week == currentWeek)
                {


                    // Verificar si el comercio es "Todos"
                    if (request.comercio.ToLower() == "todos")
                    {
                        var fantasiasnombre = ObtenerFantasiasNombre(sas);
                        var mesesHastaHoy = ObtenerMesesHastaHoy(request.Year, request.Month, request.Day);
                        var semanasPorMes = ObtenerSemanasPorMes(mesesHastaHoy, request.Year);

                        var listaMismoDiaMesAnterior = ObtenerListaMismoDiaMesAnterior(sas);
                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                       
                        // Calcular la fecha de mañana
                        DateTime fechaFin = DateTime.Today.AddDays(1);

                        // Ajustar la fecha si mañana es sábado o domingo
                        if (fechaFin.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fechaFin = fechaFin.AddDays(2); // Ajustar al lunes (saltar sábado y domingo)
                        }
                        else if (fechaFin.DayOfWeek == DayOfWeek.Sunday)
                        {
                            fechaFin = fechaFin.AddDays(1); // Ajustar al lunes (saltar domingo)
                        }

                        // Llamar a la función con la fecha de inicio y la fecha fin ajustada
                        var fechaInicio = new DateTime(request.Year, request.Month, 1);
                        var listaMes = ObtenerListaPorRangoFecha(sas, fechaInicio, fechaFin);
                        var listaMañana = ObtenerListaPorFecha(sas, fechaFin);
                        var movimientosUltimos7Dias = ObtenerMovimientosUltimos7Dias(sas);
                        var fechasUnicas = ObtenerFechasUnicas(movimientosUltimos7Dias);

                        var totalesPorDiaPorTarjeta = ObtenerTotalesPorDiaPorTarjeta(sas, fechasUnicas);
                        var descuentosPorTarjeta = ObtenerDescuentosPorTarjeta(sas);
                        var totalOperaciones = ObtenerTotalOperaciones(sas);
                        var totalConDescuentoCuotas1 = ObtenerTotalConDescuentoCuotas(sas, 1);
                        var totalConDescuentoCuotas2 = ObtenerTotalConDescuentoCuotas(sas, 2);
                        var totalNetoHoy = ObtenerTotalNeto(listaHoy);
                        var totalBrutoHoy = ObtenerTotalBruto(listaHoy);
                        var totalNetoMañana = ObtenerTotalNeto(listaMañana);
                        var totalBrutoMañana = ObtenerTotalBruto(listaMañana);
                        var totalNetoMes = ObtenerTotalNeto(listaMes);
                        var totalBrutoMes = ObtenerTotalBruto(listaMes);

                        var comparativahot = ObtenerComparativa(sas, listaHoy);
                        var comparativaHotmesanterior = ObtenerComparativa(sas, listaMismoDiaMesAnterior);
                        var porcentaje = ObtenerPorcentaje(comparativahot, comparativaHotmesanterior);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            MesesHastaHoy = mesesHastaHoy,
                            SemanasPorMes = semanasPorMes,
                            TotalNetoHoy = totalNetoHoy,
                            TotalBrutoHoy = totalBrutoHoy,
                            TotalNetoMañana = totalNetoMañana,
                            TotalBrutoMañana = totalBrutoMañana,
                            TotalNetoMes = totalNetoMes,
                            TotalBrutoMes = totalBrutoMes,
                            Comparativahoy = comparativahot,
                            ComparativaHoymesanterior = comparativaHotmesanterior,
                            Porcentaje = porcentaje,
                            DescuentosPorTarjeta = descuentosPorTarjeta,
                            TotalesPorDiaTarjeta = totalesPorDiaPorTarjeta,
                            Fantasiasnombre = fantasiasnombre,

                            TotalOperaciones = totalOperaciones,
                            TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                            TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,


                            comparativadiasemana = "dia",
                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();
                        var fantasiasnombre = ObtenerFantasiasNombre(sas);
                        var mesesHastaHoy = ObtenerMesesHastaHoy(request.Year, request.Month, request.Day);
                        var semanasPorMes = ObtenerSemanasPorMes(mesesHastaHoy, request.Year);

                        var listaMismoDiaMesAnterior = ObtenerListaMismoDiaMesAnterior(sas);
                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                        
                        // Calcular la fecha de mañana
                        DateTime fechaFin = DateTime.Today.AddDays(1);

                        // Ajustar la fecha si mañana es sábado o domingo
                        if (fechaFin.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fechaFin = fechaFin.AddDays(2); // Ajustar al lunes (saltar sábado y domingo)
                        }
                        else if (fechaFin.DayOfWeek == DayOfWeek.Sunday)
                        {
                            fechaFin = fechaFin.AddDays(1); // Ajustar al lunes (saltar domingo)
                        }

                        // Llamar a la función con la fecha de inicio y la fecha fin ajustada
                        var fechaInicio = new DateTime(request.Year, request.Month, 1);
                        var listaMes = ObtenerListaPorRangoFecha(sas, fechaInicio, fechaFin);
                        var listaMañana = ObtenerListaPorFecha(sas, fechaFin);
                        var movimientosUltimos7Dias = ObtenerMovimientosUltimos7Dias(sas);
                        var fechasUnicas = ObtenerFechasUnicas(movimientosUltimos7Dias);

                        var totalesPorDiaPorTarjeta = ObtenerTotalesPorDiaPorTarjeta(sas, fechasUnicas);
                        var descuentosPorTarjeta = ObtenerDescuentosPorTarjeta(sas);
                        var totalOperaciones = ObtenerTotalOperaciones(sas);
                        var totalConDescuentoCuotas1 = ObtenerTotalConDescuentoCuotas(sas, 1);
                        var totalConDescuentoCuotas2 = ObtenerTotalConDescuentoCuotas(sas, 2);
                        var totalNetoHoy = ObtenerTotalNeto(listaHoy);
                        var totalBrutoHoy = ObtenerTotalBruto(listaHoy);
                        var totalNetoMañana = ObtenerTotalNeto(listaMañana);
                        var totalBrutoMañana = ObtenerTotalBruto(listaMañana);
                        var totalNetoMes = ObtenerTotalNeto(listaMes);
                        var totalBrutoMes = ObtenerTotalBruto(listaMes);

                        var comparativahot = ObtenerComparativa(sas, listaHoy);
                        var comparativaHotmesanterior = ObtenerComparativa(sas, listaMismoDiaMesAnterior);
                        var porcentaje = ObtenerPorcentaje(comparativahot, comparativaHotmesanterior);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            MesesHastaHoy = mesesHastaHoy,
                            SemanasPorMes = semanasPorMes,
                            TotalNetoHoy = totalNetoHoy,
                            TotalBrutoHoy = totalBrutoHoy,
                            TotalNetoMañana = totalNetoMañana,
                            TotalBrutoMañana = totalBrutoMañana,
                            TotalNetoMes = totalNetoMes,
                            TotalBrutoMes = totalBrutoMes,
                            Comparativahoy = comparativahot,
                            ComparativaHoymesanterior = comparativaHotmesanterior,
                            Porcentaje = porcentaje,
                            DescuentosPorTarjeta = descuentosPorTarjeta,
                            TotalesPorDiaTarjeta = totalesPorDiaPorTarjeta,
                            Fantasiasnombre = fantasiasnombre,

                            TotalOperaciones = totalOperaciones,
                            TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                            TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,




                            comparativadiasemana = "dia",
                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }

                }
                else
                {
                    // Verificar si el comercio es "Todos"
                    if (request.comercio.ToLower() == "todos")
                    {

                        DateTime fechaInicial = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicial);

                        // Determinar si estamos en la misma semana del año actual
                        int semanaActualDelSistema = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                        bool esLaMismaSemana = request.Week == semanaActualDelSistema && request.Year == DateTime.Today.Year;

                        // Si es la misma semana, usar DateTime.Today, de lo contrario, usar el último día de la semana solicitada
                        DateTime fechaFin = esLaMismaSemana ? DateTime.Today : fechaFinalDeLaSemana;

                        // Continúa con el procesamiento usando fechaFin
                        var listaFiltrada = sas.Where(s =>
                            s.FechaDePago.HasValue &&
                            s.FechaDePago.Value.Date >= fechaInicial.Date &&
                            s.FechaDePago.Value.Date <= fechaFin.Date)
                            .ToList();
                        var fantasiasnombre = ObtenerFantasiasNombre(sas);
                        var mesesHastaHoy = ObtenerMesesHastaHoy(fechaFinalDeLaSemana.Year, fechaFinalDeLaSemana.Month, fechaFinalDeLaSemana.Day);
                        var semanasPorMes = ObtenerSemanasPorMes(mesesHastaHoy, fechaFinalDeLaSemana.Year);

                        var listaMismoSemanaMesAnterior = ObtenerListaMismoSemanaMesAnterior(sas, fechaFinalDeLaSemana.Year,fechaFinalDeLaSemana.Month,request.Week);

                      

                        var listaMes = ObtenerListaPorRangoFecha(sas, fechaInicial, fechaFin);

                        var movimientosUltimos7Dias = ObtenerMovimientosUltimos7Dias(listaFiltrada);
                        var fechasUnicas = ObtenerFechasUnicas(movimientosUltimos7Dias);

                        var totalesPorDiaPorTarjeta = ObtenerTotalesPorDiaPorTarjeta(listaFiltrada, fechasUnicas);
                        var descuentosPorTarjeta = ObtenerDescuentosPorTarjeta(listaFiltrada);
                        var totalOperaciones = ObtenerTotalOperaciones(listaFiltrada);
                        var totalConDescuentoCuotas1 = ObtenerTotalConDescuentoCuotas(listaFiltrada, 1);
                        var totalConDescuentoCuotas2 = ObtenerTotalConDescuentoCuotas(listaFiltrada, 2);
                       
                        var totalNetoMes = ObtenerTotalNeto(listaMes);
                        var totalBrutoMes = ObtenerTotalBruto(listaMes);

                        var comparativahot = ObtenerComparativa(sas, listaFiltrada);
                        var comparativaHotmesanterior = ObtenerComparativa(sas, listaMismoSemanaMesAnterior);
                        var porcentaje = ObtenerPorcentaje(comparativahot, comparativaHotmesanterior);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            MesesHastaHoy = mesesHastaHoy,
                            SemanasPorMes = semanasPorMes,
                            TotalNetoHoy = 0,
                            TotalBrutoHoy = 0,
                            TotalNetoMañana = 0,
                            TotalBrutoMañana = 0,
                            TotalNetoMes = totalNetoMes,
                            TotalBrutoMes = totalBrutoMes,
                            Comparativahoy = comparativahot,
                            ComparativaHoymesanterior = comparativaHotmesanterior,
                            Porcentaje = porcentaje,
                            DescuentosPorTarjeta = descuentosPorTarjeta,
                            TotalesPorDiaTarjeta = totalesPorDiaPorTarjeta,
                            Fantasiasnombre = fantasiasnombre,

                            TotalOperaciones = totalOperaciones,
                            TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                            TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,






                            comparativadiasemana = "semana",
                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                       // var fantasiasnombre = ObtenerFantasiasNombre(sas);
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();
                        DateTime fechaInicial = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicial);

                        var listaFiltrada = sas.Where(s =>
                         s.FechaDePago.HasValue &&
                             s.FechaDePago.Value.Date >= fechaInicial.Date &&
                             s.FechaDePago.Value.Date <= fechaFinalDeLaSemana.Date)
                              .ToList();
                       
                        var mesesHastaHoy = ObtenerMesesHastaHoy(fechaFinalDeLaSemana.Year, fechaFinalDeLaSemana.Month, fechaFinalDeLaSemana.Day);
                        var semanasPorMes = ObtenerSemanasPorMes(mesesHastaHoy, fechaFinalDeLaSemana.Year);

                        var listaMismoSemanaMesAnterior = ObtenerListaMismoSemanaMesAnterior(sas, fechaFinalDeLaSemana.Year, fechaFinalDeLaSemana.Month, request.Week);

                        DateTime fechaInicio = new DateTime(request.Year, request.Month, 1);
                        DateTime fechaFin;

                        // Determinar si estamos en el mes y año de la solicitud
                        bool esMesActual = request.Year == DateTime.Now.Year && request.Month == DateTime.Now.Month;

                        // Si es el mes y año actual, usar DateTime.Today, de lo contrario, usar el último día del mes de la solicitud
                        fechaFin = esMesActual ? DateTime.Today : new DateTime(request.Year, request.Month, DateTime.DaysInMonth(request.Year, request.Month));

                        var listaMes = ObtenerListaPorRangoFecha(sas, fechaInicio, fechaFin);

                        var movimientosUltimos7Dias = ObtenerMovimientosUltimos7Dias(listaFiltrada);
                        var fechasUnicas = ObtenerFechasUnicas(movimientosUltimos7Dias);

                        var totalesPorDiaPorTarjeta = ObtenerTotalesPorDiaPorTarjeta(listaFiltrada, fechasUnicas);
                        var descuentosPorTarjeta = ObtenerDescuentosPorTarjeta(listaFiltrada);
                        var totalOperaciones = ObtenerTotalOperaciones(listaFiltrada);
                        var totalConDescuentoCuotas1 = ObtenerTotalConDescuentoCuotas(listaFiltrada, 1);
                        var totalConDescuentoCuotas2 = ObtenerTotalConDescuentoCuotas(listaFiltrada, 2);

                        var totalNetoMes = ObtenerTotalNeto(listaMes);
                        var totalBrutoMes = ObtenerTotalBruto(listaMes);

                        var comparativahot = ObtenerComparativa(sas, listaFiltrada);
                        var comparativaHotmesanterior = ObtenerComparativa(sas, listaMismoSemanaMesAnterior);
                        var porcentaje = ObtenerPorcentaje(comparativahot, comparativaHotmesanterior);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            MesesHastaHoy = mesesHastaHoy,
                            SemanasPorMes = semanasPorMes,
                            TotalNetoHoy = 0,
                            TotalBrutoHoy = 0,
                            TotalNetoMañana = 0,
                            TotalBrutoMañana = 0,
                            TotalNetoMes = totalNetoMes,
                            TotalBrutoMes = totalBrutoMes,
                            Comparativahoy = comparativahot,
                            ComparativaHoymesanterior = comparativaHotmesanterior,
                            Porcentaje = porcentaje,
                            DescuentosPorTarjeta = descuentosPorTarjeta,
                            TotalesPorDiaTarjeta = totalesPorDiaPorTarjeta,
                            //Fantasiasnombre = fantasiasnombre,

                            TotalOperaciones = totalOperaciones,
                            TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                            TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,






                            comparativadiasemana = "semana",
                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                }
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        } 

        private List<BaseDashboard> ObtenerListaMismoSemanaMesAnterior(List<BaseDashboard> sas, int year, int month, int week)
{
    // Calcular el primer y último día de la semana en el mes y año actual
    DateTime primerDiaMesActual = new DateTime(year, month, 1);
    DateTime primerDiaSemanaActual = GetFirstDayOfWeekInMonth(year, month, week);
    DateTime ultimoDiaSemanaActual = GetLastDayOfWeek(primerDiaSemanaActual);

    // Ajustar al mes anterior
    DateTime primerDiaMesAnterior = primerDiaMesActual.AddMonths(-1);
    int diasDiferencia = (primerDiaSemanaActual - primerDiaMesActual).Days;
    DateTime primerDiaSemanaMesAnterior = primerDiaMesAnterior.AddDays(diasDiferencia);
    DateTime ultimoDiaSemanaMesAnterior = GetLastDayOfWeek(primerDiaSemanaMesAnterior);

    return sas.Where(s => 
        s.FechaDePago.HasValue &&
        s.FechaDePago.Value.Date >= primerDiaSemanaMesAnterior.Date &&
        s.FechaDePago.Value.Date <= ultimoDiaSemanaMesAnterior.Date)
        .ToList();
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
        private HashSet<string> ObtenerFantasiasNombre(List<BaseDashboard> sas)
        {
            HashSet<string> fantasiasnombre = new HashSet<string>();
            int index = 0;

            while (index < sas.Count)
            {
                if (!fantasiasnombre.Contains(sas[index].NombreComercio))
                {
                    fantasiasnombre.Add(sas[index].NombreComercio);
                }
                index++;
            }

            return fantasiasnombre;
        }

        private List<string> ObtenerMesesHastaHoy(int year, int month, int day)
        {
            DateTime hoy = new DateTime(year, month, day);
            int añoActual = year;

            List<string> mesesHastaHoy = new List<string>();
            for (DateTime date = new DateTime(añoActual, 1, 1); date <= hoy; date = date.AddMonths(1))
            {
                mesesHastaHoy.Add(date.ToString("MMMM"));
            }

            return mesesHastaHoy;
        }

        private Dictionary<string, List<int>> ObtenerSemanasPorMes(List<string> mesesHastaHoy, int year)
        {
            Dictionary<string, List<int>> semanasPorMes = new Dictionary<string, List<int>>();
            foreach (var mes in mesesHastaHoy)
            {
                DateTime primerDiaDelMes = new DateTime(year, DateTime.ParseExact(mes, "MMMM", CultureInfo.CurrentCulture).Month, 1);
                DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
                int numeroSemanas = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(ultimoDiaDelMes, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                List<int> semanasDelMes = Enumerable.Range(1, numeroSemanas)
                                                     .Where(week => primerDiaDelMes.AddDays((week - 1) * 7).Month == primerDiaDelMes.Month)
                                                     .ToList();
                semanasPorMes.Add(mes, semanasDelMes);
            }

            return semanasPorMes;
        }
        private List<BaseDashboard> ObtenerListaMismoDiaMesAnterior(List<BaseDashboard> sas)
        {
            DateTime hoy = DateTime.Today;
            DateTime ultimoMesMismoDia = hoy.AddMonths(-1);
            DateTime mismoDiaMesAnterior = new DateTime(ultimoMesMismoDia.Year, ultimoMesMismoDia.Month, hoy.Day);

            return sas.Where(s => s.FechaDePago == mismoDiaMesAnterior).ToList();
        }

        private List<BaseDashboard> ObtenerListaPorFecha(List<BaseDashboard> sas, DateTime fecha)
        {
            return sas.Where(s => s.FechaDePago == fecha.Date).ToList();
        }

        private List<BaseDashboard> ObtenerListaPorRangoFecha(List<BaseDashboard> sas, DateTime fechaInicio, DateTime fechaFin)
        {
            return sas.Where(s => s.FechaDePago >= fechaInicio.Date && s.FechaDePago <= fechaFin.Date).ToList();
        }
        private List<BaseDashboard> ObtenerMovimientosUltimos7Dias(List<BaseDashboard> sas)
        {
            // Encuentra la fecha más reciente en 'sas' o usa la fecha actual si 'sas' está vacía
            DateTime fechaMasReciente = sas.Max(s => s.FechaDePago) ?? DateTime.Today;

            // Calcula la fecha de hace 7 días desde la fecha más reciente
            DateTime haceUnaSemana = fechaMasReciente.AddDays(-7);

            // Filtra 'sas' para obtener los movimientos de los últimos 7 días hasta la fecha más reciente
            return sas.Where(s => s.FechaDePago.HasValue && s.FechaDePago.Value.Date >= haceUnaSemana.Date && s.FechaDePago.Value.Date <= fechaMasReciente.Date).ToList();
        }


        // Este método recibe una lista de movimientos y devuelve una lista de fechas únicas ordenadas de forma descendente
        public List<DateTime> ObtenerFechasUnicas(List<BaseDashboard> movimientosUltimos7Dias)
        {
            // Encuentra el primer día de la semana actual que pertenezca al mes en curso
          

            // Encuentra la fecha más reciente en FechaDePago
            DateTime fechaMasReciente = movimientosUltimos7Dias.Max(s => s.FechaDePago) ?? DateTime.MinValue;

            DateTime primerDiaSemanaMesActual = fechaMasReciente.AddDays(-(int)fechaMasReciente.DayOfWeek + (int)DayOfWeek.Monday);
            if (primerDiaSemanaMesActual.Month != fechaMasReciente.Month)
            {
                primerDiaSemanaMesActual = new DateTime(fechaMasReciente.Year, fechaMasReciente.Month, 1);
            }

            // Comprueba si la fecha más reciente es anterior a hoy
            DateTime fechaHasta = fechaMasReciente < DateTime.Today ? fechaMasReciente : DateTime.Today;

            var fechasUnicas = movimientosUltimos7Dias
                .Select(s => s.FechaDePago ?? DateTime.MinValue)
                .Distinct()
                .Where(d => d >= primerDiaSemanaMesActual && d <= fechaHasta)
                .OrderByDescending(d => d)
                .ToList();

            return fechasUnicas;
        }





        private Dictionary<string, List<object>> ObtenerTotalesPorDiaPorTarjeta(List<BaseDashboard> sas, List<DateTime> fechasUnicas)
        {
            var totalesPorDiaPorTarjeta = new Dictionary<string, List<object>>();

            DateTime fechaPagoMasReciente = fechasUnicas.Any() ? fechasUnicas.Max() : DateTime.MinValue;
            DateTime fechaLimite = fechaPagoMasReciente < DateTime.Today ? fechaPagoMasReciente : DateTime.Today;

            var fechasHastaHoy = fechasUnicas.Where(fecha => fecha.Date <= fechaLimite).ToList();

            // Determinar la semana del mes para la fecha límite
    



            foreach (var fecha in fechasHastaHoy)
            {
                int semanaDelMes = fechaLimite < DateTime.Today ? ObtenerSemanaDelMes(fechaLimite) : ObtenerSemanaDelMesActual();
                var totalesPorTarjetaEnFecha = sas
      .Where(s => s.FechaDePago.HasValue &&
                  s.FechaDePago.Value.Year == fecha.Year &&
                  s.FechaDePago.Value.Month == fecha.Month &&
                  s.FechaDePago.Value.Date == fecha.Date)
      .GroupBy(s => s.NombreComercio.Replace(" ", ""))
      .ToList();

                foreach (var grupoTarjeta in totalesPorTarjetaEnFecha)
                {
                    if (!totalesPorDiaPorTarjeta.ContainsKey(grupoTarjeta.Key))
                    {
                        totalesPorDiaPorTarjeta[grupoTarjeta.Key] = new List<object>();
                    }

                    var totalesPorDia = grupoTarjeta
                        .GroupBy(s => s.FechaDePago)
                        .Select(group => new
                        {
                            NombreComercio = grupoTarjeta.Key,
                            DiaSemana = group.Key.Value.ToString("dddd"),
                            TotalConDescuentoPorDia = group.Sum(item => item.TotalConDescuentos)
                        })
                        .ToList();

                    totalesPorDiaPorTarjeta[grupoTarjeta.Key].AddRange(totalesPorDia);
                }
            }

            // Ordenar por días de la semana al finalizar todos los cálculos
            foreach (var key in totalesPorDiaPorTarjeta.Keys.ToList())
            {
                totalesPorDiaPorTarjeta[key] = totalesPorDiaPorTarjeta[key]
                    .OrderBy(obj =>
                    {
                        dynamic d = obj;
                        return GetDayOfWeekNumber(d.DiaSemana);
                    })
                    .ToList();
            }


            return totalesPorDiaPorTarjeta;
        }

        private int ObtenerSemanaDelMes(DateTime fecha)
        {
            var primeraSemanaDelMes = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(new DateTime(fecha.Year, fecha.Month, 1), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstDay, DayOfWeek.Monday) - primeraSemanaDelMes + 1;
        }

        private int GetDayOfWeekNumber(string dayOfWeek)
        {
            return dayOfWeek switch
            {
                "lunes" => 0,
                "martes" => 1,
                "miércoles" => 2,
                "jueves" => 3,
                "viernes" => 4,
                "sábado" => 5,
                "domingo" => 6,
                _ => 7 // Por si acaso hay algún valor inesperado
            };
        }




        private List<object> ObtenerDescuentosPorTarjeta(List<BaseDashboard> sas)
        {
            return sas.GroupBy(s => s.Tarjeta)
                      .Select(group => new
                      {
                          Tarjeta = group.Key,
                          TotalConDescuento = group.Sum(item => item.TotalConDescuentos)
                      }).ToList<object>();
        }

        private double ObtenerTotalOperaciones(List<BaseDashboard> sas)
        {
            return (double)sas.Count();
        }

        private double ObtenerTotalConDescuentoCuotas(List<BaseDashboard> sas, int cuotas)
        {
            return (double)sas.Where(s => s.Cuotas == cuotas)
                              .Sum(s => s.TotalConDescuentos ?? 0);
        }
        private double ObtenerTotalNeto(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalConDescuentos);
        }

        private double ObtenerTotalBruto(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalBruto);
        }

     

        private double ObtenerComparativa(List<BaseDashboard> sas, List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalConDescuentos);
        }

        private double ObtenerPorcentaje(double comparativaHoy, double comparativaDiaAnterior)
        {

            var resultadoResta = comparativaHoy - comparativaDiaAnterior;
            var resultado = resultadoResta / comparativaHoy;
            return resultado;

        }


        public int ObtenerSemanaDelMesActual()
        {
            DateTime fechaHoy = DateTime.Now;
            DateTime primerDiaDelMes = new DateTime(fechaHoy.Year, fechaHoy.Month, 1);
            int diaDeLaSemanaDelPrimerDia = (int)primerDiaDelMes.DayOfWeek;

            int semanaDelMes = (fechaHoy.Day + diaDeLaSemanaDelPrimerDia - 1) / 7 + 1;
            return semanaDelMes;
        }



    }
}