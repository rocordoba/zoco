using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                var resultado = new List<dynamic>();

                // Obtener nombres de comercio únicos y agregar "Todos" al inicio
                var comercios = sas
                    .Where(d => !string.IsNullOrEmpty(d.NombreComercio))
                    .Select(d => d.NombreComercio)
                    .Distinct()
                    .ToList();
                comercios.Insert(0, "Todos");

                // Obtener años y meses únicos
                var fechasUnicas = sas
                    .Where(d => d.FechaDePago.HasValue)
                    .Select(d => new { Año = d.FechaDePago.Value.Year, Mes = d.FechaDePago.Value.Month })
                    .Distinct()
                    .OrderBy(d => d.Año).ThenBy(d => d.Mes);

                foreach (var fecha in fechasUnicas)
                {
                    var semanasDelMes = new List<List<DateTime>>();

                    var primerDiaMes = new DateTime(fecha.Año, fecha.Mes, 1);
                    var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                    var inicioSemana = primerDiaMes;
                    var finSemana = inicioSemana.AddDays(6 - (int)inicioSemana.DayOfWeek);

                    while (inicioSemana <= ultimoDiaMes)
                    {
                        if (finSemana > ultimoDiaMes)
                            finSemana = ultimoDiaMes;

                        semanasDelMes.Add(Enumerable.Range(0, (finSemana - inicioSemana).Days + 1)
                                                    .Select(i => inicioSemana.AddDays(i))
                                                    .ToList());

                        inicioSemana = finSemana.AddDays(1);
                        finSemana = inicioSemana.AddDays(6 - (int)inicioSemana.DayOfWeek);
                    }

                    resultado.Add(new { Año = fecha.Año, Mes = fecha.Mes, Semanas = semanasDelMes });
                }

                // Agregar comercios al resultado
                resultado.Add(new { Comercios = comercios });

                return Ok(resultado);
            }

            return BadRequest("Token es nulo o vacío");
        }


    }
}
