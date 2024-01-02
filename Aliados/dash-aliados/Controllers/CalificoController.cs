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
    public class CalificoController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly ICalificoComentarioService _ComentarioService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public CalificoController(ICalificoComentarioService calificocomentario,IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
            _ComentarioService = calificocomentario;
        }
        [HttpPost("califico")]
        public async Task<ActionResult> Inicio([FromBody] VMCalificoCom request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var entidad = _mapper.Map<CalificoCom>(request);

                var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
                var califico = await _ComentarioService.Crear(entidad);
                return StatusCode(StatusCodes.Status200OK);
                // Aquí puedes realizar cualquier lógica adicional antes de guardar en la base de datos
           
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }

    }
}
