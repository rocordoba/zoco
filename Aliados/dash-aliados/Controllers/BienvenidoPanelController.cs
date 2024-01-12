using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BienvenidoPanelController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public BienvenidoPanelController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpPost("bienvenidopanel")]


        public async Task<ActionResult> bienvenidopanel([FromBody] VMBienvenidopanel request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);

                var resultado = new
                {
                    Anios = sas
                        .Where(d => d.FechaDePago.HasValue)
                        .Select(d => d.FechaDePago.Value.Year)
                        .Distinct()
                        .OrderBy(a => a)
                        .ToList(),

                    Meses = sas
                        .Where(d => d.FechaDePago.HasValue)
                        .Select(d => new { Año = d.FechaDePago.Value.Year, Mes = d.FechaDePago.Value.Month })
                        .Distinct()
                        .OrderBy(fm => fm.Año)
                        .ThenBy(fm => fm.Mes)
                        .ToList(),

                    Semanas = sas
                        .Where(d => d.FechaDePago.HasValue)
                        .Select(d => new { Año = d.FechaDePago.Value.Year, Mes = d.FechaDePago.Value.Month, Semana = GetWeekOfYear(d.FechaDePago.Value) })
                        .Distinct()
                        .OrderBy(w => w.Año)
                        .ThenBy(w => w.Mes)
                        .ThenBy(w => w.Semana)
                        .ToList(),

                    Comercios = sas
                        .Where(d => !string.IsNullOrEmpty(d.NombreComercio))
                        .Select(d => d.NombreComercio)
                        .Distinct()
                        .ToList()
                };

                // Agregar "Todos" al inicio de la lista de comercios
                resultado.Comercios.Insert(0, "Todos");

                return Ok(resultado);
            }

            return BadRequest("Token es nulo o vacío");
        }

        // Método para obtener la semana del año
        private int GetWeekOfYear(DateTime date)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNum = ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            return weekNum;
        }



    }
}
