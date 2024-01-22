using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenservice;
        public TokenController(ITokenService tok)
        {

            _tokenservice = tok;
        }
        [HttpPost("token")]
        public async Task<IActionResult> ValidarToken([FromBody] VMToken request)
        {
            if (string.IsNullOrEmpty(request.Token))
            {
                return BadRequest("El token no puede estar vacío");
            }

            bool esTokenValido = await _tokenservice.ValidarTokenAsync(request.Token);
            if (esTokenValido)
            {
                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                var rol = usuarioEncontrado.usuario.TipoUsuario;
                return StatusCode(StatusCodes.Status200OK, rol);
            }
            else
            {

                return StatusCode(StatusCodes.Status401Unauthorized, "Token inválido");
            }
        }

    }
}
