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
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _notificacionservice;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;
        public NotificacionController(INotificacionService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _notificacionservice = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpGet("noticias")]
        public async Task<ActionResult<List<Noticia>>> Lista()
        {

            var sasLista = await _notificacionservice.Lista();


            if (sasLista == null || sasLista.Count == 0)
            {
                return NotFound("No hay datos para la lista de Sas");
            }


            var sasListaVM = sasLista.Select(s => _mapper.Map<Noticia>(s)).ToList();

            return Ok(sasListaVM);
        }
    }
}
