using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ZocoAplicacion.Models.ViewModels;
using BLL.Interfaces; // Importar la librería AutoMapper
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IUsuarioZocoService _usuariosService;
        private readonly ITokenService _tokenService; // Añadir el servicio de Token
        private readonly IMapper _mapper;
        private readonly string secretKey;

        public AccesoController(IUsuarioZocoService usuariosService, ITokenService tokenService, IMapper mapper, IConfiguration config)
        {
            _usuariosService = usuariosService;
            _tokenService = tokenService; // Inicializar el servicio de Token
            _mapper = mapper;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost("login")]
        public async Task<ActionResult<VMUsuariosZoco>> Login([FromBody] VMUsuarios usuario)
        {
            var usuarioEncontrado = await _usuariosService.ObtenerPorCredenciales(usuario.UsuarioCuit, usuario.Clave);

            if (usuarioEncontrado == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = "Credenciales inválidas" });
            }

            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioCuit));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            DateTime fechaCreacion = DateTime.UtcNow;
            DateTime fechaExpiracion = fechaCreacion.AddMinutes(60);
            await _tokenService.GenerarActualizarTokenAsync(usuarioEncontrado.Id, tokenCreado, fechaCreacion, fechaExpiracion);

            var usuarioVM = _mapper.Map<VMUsuariosZoco>(usuarioEncontrado);
            var usuarioJson = JsonConvert.SerializeObject(usuarioEncontrado);
            var respuestaJson = new
            {
                usuario = _mapper.Map<VMUsuariosZoco>(usuarioVM),
                token = tokenCreado,
                rol = usuarioEncontrado.TipoUsuario
            };

            return Ok(respuestaJson);
        }
        [HttpPost("cambiarClave")]
        public async Task<IActionResult> CambiarClave([FromBody] VMCambioClave cambioClave)
        {
            if (cambioClave.ClaveNueva != cambioClave.ConfirmarClave)
            {
                return BadRequest("Las contraseñas nuevas no coinciden.");
            }

            var resultado = await _usuariosService.CambiarClave(cambioClave.Id, cambioClave.ClaveActual, cambioClave.ClaveNueva);

            if (resultado)
            {
                return Ok("Contraseña cambiada con éxito.");
            }
            else
            {
                return BadRequest("No se pudo cambiar la contraseña.");
            }
        }
        [HttpPost("logout")]
        public async Task<ActionResult> Logout([FromBody] VMToken request)
        {
            bool esTokenValido = await _tokenService.ValidarTokenAsync(request.Token);
            if (esTokenValido)
            {
                var usuarioEncontrado = await _tokenService.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                if (usuarioEncontrado.usuario != null)
                {
                    var resultado = await _tokenService.EliminarTokenAsync(usuarioEncontrado.usuario.Id);
                    if (resultado)
                    {
                        return Ok("Sesión cerrada correctamente.");
                    }
                    else
                    {
                        return BadRequest("Error al cerrar sesión.");
                    }
                }
                else
                {
                    return BadRequest("Usuario no encontrado.");
                }
            }
            else
            {
                return BadRequest("Token inválido.");
            }
        }




    }
}