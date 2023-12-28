﻿using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificoController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;

        public CalificoController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpPost("califico")]
        public async Task<ActionResult> Inicio([FromBody] VMCalificoCom request)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
              
             
                var resultado = new
                {
                   ID=request.Id,
                   token=request.Token,
                   califico=request.NumCalifico,
                   calificoreques=request.Descripcion,
                   fecha=request.Fecha,

                 
                };

                return StatusCode(StatusCodes.Status200OK, resultado);
            }

            return Unauthorized("El token o el ID de la sesión no son válidos");
        }
    }
}
