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
        private readonly IMapper _mapper;
        private readonly string secretKey;
        public AccesoController(IUsuarioZocoService usuariosService, IMapper mapper, IConfiguration config)
        {
            _usuariosService = usuariosService;
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

            var usuarioVM = _mapper.Map<VMUsuariosZoco>(usuarioEncontrado);
            var usuarioJson = JsonConvert.SerializeObject(usuarioEncontrado);
            var respuestaJson = new
            {
                usuario = _mapper.Map<VMUsuariosZoco>(usuarioVM),
                token = tokenCreado,
                userId = usuarioEncontrado.Id
            };

            return Ok(respuestaJson);
        }
      
        [HttpGet("califico")]
        public async Task<ActionResult> califico([FromQuery] string token, [FromQuery] int id)
        {
            if (token != null)
            {
                var usuario = await _usuariosService.Guardarcalificacion(id);
                     

                return Ok();
            }
            return Unauthorized("El token o el ID de la sesión no son válidos");
        }

            // API para listar los usuarios
            [HttpGet("lista")]
        public async Task<ActionResult<List<VMUsuarios>>> Lista()
        
        {
            // Obtener la lista de usuarios
            var usuarios = await _usuariosService.Lista();

            // Si no hay usuarios, devolver un error
            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound("No hay usuarios registrados");
            }

            // Si hay usuarios, devolverlos como una lista de VMUsuarios
            var usuariosVM = usuarios.Select(u => _mapper.Map<VMUsuarios>(u)).ToList(); // Usar el mapper para convertir la lista de usuarios

            return Ok(usuariosVM);
        }

    }
}