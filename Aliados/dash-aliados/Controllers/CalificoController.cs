using AutoMapper;
using BLL.ImplementacionZoco;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Entity.Entity;
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
      
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenservice;
        public CalificoController(ICalificoComentarioService calificocomentario,IBaseDashboardService sasService, IMapper mapper, ITokenService tok, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _tokenservice = tok;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
            _ComentarioService = calificocomentario;
        }
        [HttpPost("calificocom")]
        public async Task<ActionResult> calificocom([FromBody] VMCalificoCom request)
        {
            bool esTokenValido = await _tokenservice.ValidarTokenAsync(request.Token);
            if (esTokenValido == true)
            {
                var entidad = _mapper.Map<CalificoCom>(request);

                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);

                entidad.UsuarioId = usuarioEncontrado.usuario.Id;
                var califico = await _ComentarioService.Crear(entidad);
                return StatusCode(StatusCodes.Status200OK);
          
           
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }
        [HttpPost("califico")]
        public async Task<ActionResult> califico([FromBody] VMCalifico request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                var entidad = _mapper.Map<Califico>(request);
                var califico = await _ComentarioService.CrearComentario(entidad);
                return StatusCode(StatusCodes.Status200OK);
                // Aquí puedes realizar cualquier lógica adicional antes de guardar en la base de datos

            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }


    }
}
