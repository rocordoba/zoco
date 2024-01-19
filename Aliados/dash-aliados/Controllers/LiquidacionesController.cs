using AutoMapper;
using BLL.ImplementacionZoco;
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
    public class LiquidacionesController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;

        private readonly IMapper _mapper;
        private readonly IInflacionService _inflacionService;
        private readonly ITokenService _tokenservice;
        public LiquidacionesController(IBaseDashboardService sasService, ITokenService tok, IMapper mapper, IUsuarioZocoService usuarioZoco, IInflacionService inflacionService)
        {
            _baseService = sasService;

            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
            _inflacionService = inflacionService;
            _tokenservice = tok;
        }
        [HttpPost("listausuarios")]
        public async Task<ActionResult> listausuarios([FromBody] VMDatosInicio request)
        {

           

                var sasLista = await _usuarioZocoService.Lista();


                if (sasLista == null || sasLista.Count == 0)
                {
                    return NotFound("No hay datos para la lista de Sas");
                }


                var sasListaVM = sasLista.Select(s => _mapper.Map<Usuarios>(s)).ToList();

            


            return Ok();
        }
    }
}
