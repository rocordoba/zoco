using AutoMapper;
using BLL.ImplementacionZoco;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly ITokenService _tokenservice;
        private readonly IMapper _mapper;
        public PDFController(IBaseDashboardService sasService, IMapper mapper, ITokenService tok, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _tokenservice = tok;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpPost("pdf")]
        public async Task<IActionResult> DownloadPdf([FromBody] VMPDF request)
        {
            bool esTokenValido = await _tokenservice.ValidarTokenAsync(request.Token);
            if (esTokenValido)
            {
                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.usuario.Usuario);
                var primerDiaMes = new DateTime(request.Year, request.Month, 1);
                var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                var datosFiltrados = sas.Where(dato => dato.FechaDePago?.Date >= primerDiaMes && dato.FechaDePago?.Date <= ultimoDiaMes)
                                   .Select(dato => new
                                   {
                                       Terminal = dato.NroDeAutorizacion?.ToString() ?? "",
                                       NroOperacion = dato.NroDeComercio?.ToString() ?? "",
                                       FechaOperacion = dato.FechaOperacion?.ToString("dd/MM/yyyy") ?? "N/A",
                                       FechaPago = dato.FechaDePago?.ToString("dd/MM/yyyy") ?? "N/A",
                                       NroCupon = dato.NroDeCupon?.ToString() ?? "",
                                       NroTarjeta = dato.NroDeTarjeta?.ToString() ?? "",
                                       Tarjeta = dato.Tarjeta ?? "N/A",
                                       Cuotas = dato.Cuotas?.ToString() ?? "N/A",
                                       Bruto = dato.TotalBruto?.ToString("N2") ?? "0.00",
                                       CostoFinanciero = dato.CostoFinanciero?.ToString("N2") ?? "0.00",
                                       CostoPorAnticipo = dato.CostoPorAnticipo?.ToString("N2") ?? "0.00",
                                       Arancel = dato.Arancel?.ToString("N2") ?? "0.00",
                                       IvaArancel = dato.Iva21?.ToString("N2") ?? "0.00",
                                       ImpDebitoCredito = dato.ImpuestoDebitoCredito?.ToString("N2") ?? "0.00",
                                       RetencionIIBB = dato.RetencionProvincial?.ToString("N2") ?? "0.00",
                                       RetencionGanancia = dato.RetencionGanacia?.ToString("N2") ?? "0.00",
                                       RetencionIVA = dato.RetencionIva?.ToString("N2") ?? "0.00",
                                       TotalOP = dato.TotalConDescuentos?.ToString("N2") ?? "0.00"
                                   })
.ToList();

                return Ok(datosFiltrados);
            }
            else
            {
                return Unauthorized("El token o el ID de la sesión no son válidos");
            }
        }
    }
}
