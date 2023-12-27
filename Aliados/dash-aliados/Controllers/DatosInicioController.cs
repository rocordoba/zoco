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


        //[HttpPost("base")]
        //public async Task<ActionResult> Inicio([FromBody] VMDatosInicio request)
        //{
        //    if (!string.IsNullOrEmpty(request.Token))
        //    {
        //        var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);



        //        var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario, request.Year, request.Month, request.Week, request.comercio);

        //        HashSet<string> fantasiasnombre = new HashSet<string>();
        //        int index = 0;

        //        while (index < sas.Count)
        //        {
        //            if (!fantasiasnombre.Contains(sas[index].NombreComercio))
        //            {
        //                fantasiasnombre.Add(sas[index].NombreComercio);
        //            }
        //            index++;
        //        }
        //        int numeroDia = request.Day;
        //        DateTime hoy = new DateTime(request.Year, request.Month, numeroDia);

        //        int añoActual = request.Year;


        //        List<string> mesesHastaHoy = new List<string>();
        //        for (DateTime date = new DateTime(añoActual, 1, 1); date <= hoy; date = date.AddMonths(1))
        //        {
        //            mesesHastaHoy.Add(date.ToString("MMMM"));
        //        }
        //        Dictionary<string, List<int>> semanasPorMes = new Dictionary<string, List<int>>();
        //        foreach (var mes in mesesHastaHoy)
        //        {
        //            DateTime primerDiaDelMes = new DateTime(añoActual, DateTime.ParseExact(mes, "MMMM", CultureInfo.CurrentCulture).Month, 1);
        //            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        //            int numeroSemanas = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(ultimoDiaDelMes, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);


        //            List<int> semanasDelMes = Enumerable.Range(1, numeroSemanas)
        //                                                 .Where(week => primerDiaDelMes.AddDays((week - 1) * 7).Month == primerDiaDelMes.Month)
        //                                                 .ToList();
        //            semanasPorMes.Add(mes, semanasDelMes);
        //        }
        //        foreach (var mes in semanasPorMes.Keys.ToList())
        //        {
        //            int numeroSemanasEnMes = semanasPorMes[mes].Count;
        //            semanasPorMes[mes] = Enumerable.Range(1, numeroSemanasEnMes).ToList();
        //        }

        //        DateTime mañana = hoy.AddDays(1);
        //        DateTime primero = new DateTime(hoy.Year, hoy.Month, 1);
        //        DateTime ultimoMesMismoDia = hoy.AddMonths(-1);
        //        DateTime mismoDiaMesAnterior = new DateTime(ultimoMesMismoDia.Year, ultimoMesMismoDia.Month, hoy.Day);
        //        DateTime haceUnaSemana = DateTime.Today.AddDays(-7);

        //        var listaMismoDiaMesAnterior = sas.Where(s => s.FechaDePago == mismoDiaMesAnterior).ToList();
        //        var listaHoy = sas.Where(s => s.FechaDePago == hoy).ToList();
        //        var listaMañana = sas.Where(s => s.FechaDePago == mañana).ToList();
        //        var listaMes = sas.Where(s => s.FechaDePago >= primero && s.FechaDePago <= hoy).ToList();
        //        var movimientosUltimos7Dias = sas.Where(s => s.FechaDePago >= haceUnaSemana && s.FechaDePago <= DateTime.Today);
        //        var fechasUnicas = movimientosUltimos7Dias.Select(s => s.FechaDePago).Distinct().OrderByDescending(d => d).ToList();

        //        var totalesPorDiaPorTarjeta = new List<object>();
        //        foreach (var fecha in fechasUnicas)
        //        {
        //            int semanaActual = ObtenerSemanaDelMesActual();

        //            var totalesPorTarjetaEnFecha = sas
        //                .Where(s => s.SemanaMesOp == semanaActual) 
        //                .GroupBy(s => new { s.FechaDePago, s.Tarjeta, s.DiaSemana })
        //                .Select(group => new
        //                {
        //                    Fecha = group.Key.FechaDePago,
        //                    Tarjeta = group.Key.Tarjeta,
        //                    DiaSemana = group.Key.DiaSemana,
        //                    TotalConDescuentoPorTarjeta = group.Sum(item => item.TotalConDescuentos)
        //                })
        //                .ToList();

        //            totalesPorDiaPorTarjeta.AddRange(totalesPorTarjetaEnFecha);
        //        }
        //        var descuentosPorTarjeta = sas.GroupBy(s => s.Tarjeta)
        //            .Select(group => new
        //            {
        //                Tarjeta = group.Key,
        //                TotalConDescuento = group.Sum(item => item.TotalConDescuentos)
        //            }).ToList();
        //        double totalOperaciones = (double)sas.Count();
        //        double totalConDescuentoCuotas1 = (double)listaMes.Where(s => s.Cuotas == 1).Sum(s => s.TotalConDescuentos ?? 0);
        //        double totalConDescuentoCuotas2 = (double)listaMes.Where(s => s.Cuotas > 1).Sum(s => s.TotalConDescuentos ?? 0);

        //        double totalNetoHoy = (double)listaHoy.Sum(s => s.TotalNeto);
        //        double totalBrutoHoy = (double)listaHoy.Sum(s => s.TotalBruto);
        //        double totalNetoMañana = (double)listaMañana.Sum(s => s.TotalNeto);
        //        double totalBrutoMañana = (double)listaMañana.Sum(s => s.TotalBruto);
        //        double totalNetoMes = (double)listaMes.Sum(s => s.TotalNeto);
        //        double totalBrutoMes = (double)listaMes.Sum(s => s.TotalBruto);
        //        double totalretencionesmes = (double)listaMes.Sum(s => s.RetencionImpositiva);
        //        double totalivames = (double)listaMes.Sum(s => s.Arancel + s.Iva21);
        //        double comparativahot = (double)listaHoy.Sum(s => s.TotalConDescuentos);
        //        double comparativaHotmesanterior = (double)listaMismoDiaMesAnterior.Sum(s => s.TotalConDescuentos);
        //        double porcentaje = comparativahot / (comparativaHotmesanterior != 0 ? comparativaHotmesanterior : 1);



        //        var resultado = new
        //        {
        //            AñoActual = añoActual,
        //            MesesHastaHoy = mesesHastaHoy,
        //            SemanasPorMes = semanasPorMes,
        //            TotalNetoHoy = totalNetoHoy,
        //            TotalBrutoHoy = totalBrutoHoy,
        //            TotalNetoMañana = totalNetoMañana,
        //            TotalBrutoMañana = totalBrutoMañana,
        //            TotalNetoMes = totalNetoMes,
        //            TotalBrutoMes = totalBrutoMes,
        //            Comparativahot = comparativahot,
        //            ComparativaHotmesanterior = comparativaHotmesanterior,
        //            Porcentaje = porcentaje,
        //            DescuentosPorTarjeta = descuentosPorTarjeta,
        //            TotalesPorDiaTarjeta = totalesPorDiaPorTarjeta,
        //            Fantasiasnombre = fantasiasnombre,
        //            TotalRetencionesMes = totalretencionesmes,
        //            TotalIvaMes = totalivames,
        //            TotalOperaciones = totalOperaciones,
        //            TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
        //            TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,
        //        };






        //        return StatusCode(StatusCodes.Status200OK, resultado);

        //    }
        //    return Unauthorized("El token o el ID de la sesión no son válidos");
        //}
        [HttpPost("base")]
        public async Task<ActionResult> Inicio([FromBody] VMDatosInicio request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario /*, request.Year, request.Month, request.Week, request.comercio*/);

                var fantasiasnombre = ObtenerFantasiasNombre(sas);
                var mesesHastaHoy = ObtenerMesesHastaHoy(request.Year, request.Month, request.Day);
                var semanasPorMes = ObtenerSemanasPorMes(mesesHastaHoy, request.Year);

                var listaMismoDiaMesAnterior = ObtenerListaMismoDiaMesAnterior(sas);
                var listaHoy = ObtenerListaPorFecha(sas, DateTime.Today);
                var listaMañana = ObtenerListaPorFecha(sas, DateTime.Today.AddDays(1));
                var listaMes = ObtenerListaPorRangoFecha(sas, new DateTime(request.Year, request.Month, 1), DateTime.Today);
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
                var totalRetencionesMes = ObtenerTotalRetenciones(listaMes);
                var totalIvaMes = ObtenerTotalIva(listaMes);
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
                    TotalRetencionesMes = totalRetencionesMes,
                    TotalIvaMes = totalIvaMes,
                    TotalOperaciones = totalOperaciones,
                    TotalConDescuentoCuotas1 = totalConDescuentoCuotas1,
                    TotalConDescuentoCuotas2 = totalConDescuentoCuotas2,
                };

                return StatusCode(StatusCodes.Status200OK, resultado);
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
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
            DateTime haceUnaSemana = DateTime.Today.AddDays(-7);
            return sas.Where(s => s.FechaDePago >= haceUnaSemana && s.FechaDePago <= DateTime.Today).ToList();
        }

        // Este método recibe una lista de movimientos y devuelve una lista de fechas únicas ordenadas de forma descendente
        public List<DateTime> ObtenerFechasUnicas(List<BaseDashboard> movimientosUltimos7Dias)
        {
            // Usamos el operador ?? para asignar un valor por defecto en caso de que la fecha sea nula
            var fechasUnicas = movimientosUltimos7Dias.Select(s => s.FechaDePago ?? DateTime.MinValue).Distinct().OrderByDescending(d => d).ToList();
            return fechasUnicas;
        }

        private Dictionary<string, List<object>> ObtenerTotalesPorDiaPorTarjeta(List<BaseDashboard> sas, List<DateTime> fechasUnicas)
        {
            var totalesPorDiaPorTarjeta = new Dictionary<string, List<object>>();

            foreach (var fecha in fechasUnicas)
            {
                int semanaActual = ObtenerSemanaDelMesActual();

                var totalesPorTarjetaEnFecha = sas
                    .Where(s => s.SemanaMesOp == semanaActual && s.FechaDePago == fecha.Date)
                    .GroupBy(s => s.NombreComercio.Replace(" ", ""))
                    .ToList();

                foreach (var grupoTarjeta in totalesPorTarjetaEnFecha)
                {
                    if (!totalesPorDiaPorTarjeta.ContainsKey(grupoTarjeta.Key))
                    {
                        totalesPorDiaPorTarjeta[grupoTarjeta.Key] = new List<object>();
                    }

                    var totalesPorDia = grupoTarjeta
                        .GroupBy(s => s.DiaSemana)
                        .Select(group => new
                        {
                            NombreComercio = grupoTarjeta.Key,
                            DiaSemana = group.Key,
                            TotalConDescuentoPorDia = group.Sum(item => item.TotalConDescuentos)
                        })
                        .OrderBy(d => GetDayOfWeekNumber(d.DiaSemana)) // Ordenar por día de la semana
                        .ToList();

                    totalesPorDiaPorTarjeta[grupoTarjeta.Key].AddRange(totalesPorDia);
                }
            }

            // Ordenar por días de la semana al finalizar todos los cálculos
            foreach (var key in totalesPorDiaPorTarjeta.Keys.ToList())
            {
                totalesPorDiaPorTarjeta[key] = totalesPorDiaPorTarjeta[key]
                    .OrderBy(obj => GetDayOfWeekNumber(obj.GetType().GetProperty("DiaSemana").GetValue(obj).ToString()))
                    .ToList();
            }

            return totalesPorDiaPorTarjeta;
        }

        // Función para obtener el número del día de la semana
        private int GetDayOfWeekNumber(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Lunes": return 0;
                case "Martes": return 1;
                case "Miércoles": return 2;
                case "Jueves": return 3;
                case "Viernes": return 4;
                case "Sábado": return 5;
                case "Domingo": return 6;
                default: return -1; // Valor predeterminado en caso de error
            }
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