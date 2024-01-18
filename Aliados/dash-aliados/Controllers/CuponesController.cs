﻿using AutoMapper;
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
    public class CuponesController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
       
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenservice;

        public CuponesController(IBaseDashboardService sasService, IMapper mapper, ITokenService tok, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _tokenservice = tok;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }

        [HttpPost("cupones")]
        public async Task<ActionResult> Cupones([FromBody] VMDatosInicio request)
        {
            bool esTokenValido = await _tokenservice.ValidarTokenAsync(request.Token);
            if (esTokenValido == true)
            {

                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                var currentDate = DateTime.Today;
                var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.usuario.Usuario);
                //   var inflacion = await _inflacionService.ObtenerPorRubro(usuarioEncontrado.Usuario);
                // Verificar si el año, mes y semana son actuales
                if (request.Year == currentDate.Year && request.Month == currentDate.Month && request.Week == currentWeek)
                {


                    // Verificar si el comercio es "Todos"
                    if (request.comercio.ToLower() == "todos")
                    {


                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                       
                        
                        var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var totalBrutoHoy = ObtenerTotalBruto(listaMes);
                        // Llamada al método para obtener las sumas por día
                        var sumasPorDia = ObtenerSumaPorDia(listaMes);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            TotalOperaciones = totalOperaciones,
                            listaMes = sumasPorDia,
                            TotalBrutoHoy = totalBrutoHoy,
                            contracargo = 0,
                            retenciones = 0,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();

                        var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                     
                     
                        var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
                        var totalBrutoHoy = ObtenerTotalBruto(listaMes);
                      
                        var sumasPorDia = ObtenerSumaPorDia(listaMes);
                        var totalOperaciones = ObtenerTotalOperaciones(listaMes);
                        var resultado = new
                        {
                            AñoActual = request.Year,
                            TotalOperaciones = totalOperaciones,
                            listaMes = sumasPorDia,
                            TotalBrutoHoy = totalBrutoHoy,
                            contracargo = 0,
                            retenciones = 0,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                }
                else
                {
                    if (request.comercio.ToLower() == "todos")
                    {
                        DateTime fechaInicial = new DateTime(request.Year, request.Month, 1);
                        DateTime fechaInicialsemana = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicialsemana);

                        var listaFiltrada = sas.Where(s =>
                         s.FechaDePago.HasValue &&
                             s.FechaDePago.Value.Date >= fechaInicial.Date &&
                             s.FechaDePago.Value.Date <= fechaFinalDeLaSemana.Date)
                              .ToList();

                        var listaHoy = ObtenerListaPorFecha(listaFiltrada, fechaFinalDeLaSemana);
                        var listaMes = ObtenerListaPorRangoFecha(listaFiltrada, fechaInicial, fechaFinalDeLaSemana);


                        var totalBrutoHoy = ObtenerTotalBruto(listaMes);
                        var totalOperaciones = ObtenerTotalOperaciones(listaFiltrada);


                        
                        var sumasPorDia = ObtenerSumaPorDia(listaMes);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            TotalOperaciones = totalOperaciones,
                            listaMes = sumasPorDia,
                            TotalBrutoHoy = totalBrutoHoy,
                            contracargo = 0,
                            retenciones = 0,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                    else
                    {
                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();
                        DateTime fechaInicial = new DateTime(request.Year, request.Month, 1);
                        DateTime fechaInicialsemana = GetFirstDayOfWeekInMonth(request.Year, request.Month, request.Week);
                        DateTime fechaFinalDeLaSemana = GetLastDayOfWeek(fechaInicialsemana);

                        var listaFiltrada = sas.Where(s =>
                         s.FechaDePago.HasValue &&
                             s.FechaDePago.Value.Date >= fechaInicial.Date &&
                             s.FechaDePago.Value.Date <= fechaFinalDeLaSemana.Date)
                              .ToList();

                        var listaHoy = ObtenerListaPorFecha(listaFiltrada, fechaFinalDeLaSemana);
                        var listaMes = ObtenerListaPorRangoFecha(listaFiltrada, fechaInicial, fechaFinalDeLaSemana);


                        var totalBrutoHoy = ObtenerTotalBruto(listaMes);
                        var totalOperaciones = ObtenerTotalOperaciones(listaFiltrada);


                    
                        var sumasPorDia = ObtenerSumaPorDia(listaMes);

                        var resultado = new
                        {
                            AñoActual = request.Year,
                            TotalOperaciones = totalOperaciones,
                            listaMes = sumasPorDia,
                            TotalBrutoHoy = totalBrutoHoy,
                            contracargo = 0,
                            retenciones = 0,

                        };

                        return StatusCode(StatusCodes.Status200OK, resultado);
                    }
                }





            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }
        private List<BaseDashboard> ObtenerListaPorFecha(List<BaseDashboard> sas, DateTime fecha)
        {
            return sas.Where(s => s.FechaDePago == fecha.Date).ToList();
        }
        private double ObtenerTotalBruto(List<BaseDashboard> lista)
        {
            return (double)lista.Sum(s => s.TotalConDescuentos);
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
                .OrderByDescending(x => x.Fecha) 
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

    }
}
