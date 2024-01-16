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
            if (esTokenValido == true)
            {

                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.usuario.Usuario);
                var primerDiaMes = new DateTime(request.Year, request.Month, 1);
                var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                // Filtrar datos basados en el rango de fechas
                var datosFiltrados = sas.Where(dato => dato.FechaDePago?.Date >= primerDiaMes && dato.FechaDePago?.Date <= ultimoDiaMes).ToList();

                using (var ms = new MemoryStream())
                {
                    using (var document = new Document())
                    {
                        PdfWriter.GetInstance(document, ms);
                        document.Open();

                        // Crear una tabla con la cantidad de columnas necesarias
                        PdfPTable table = new PdfPTable(18); // El número de columnas debe coincidir con el número de celdas que agregues
                        table.SetWidths(new float[] { 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                        table.WidthPercentage = 100f; // Establecer el ancho de la tabla al 100% de la página
                        table.DefaultCell.Border = PdfPCell.NO_BORDER;
                        table.DefaultCell.Padding = 5;

                        // Agregar los encabezados de las columnas
                        table.AddCell("TERMINAL");
                        table.AddCell("N OP");
                        table.AddCell("Fecha OP");
                        table.AddCell("Fecha Pago");
                        table.AddCell("N Cupón");
                        table.AddCell("N Tarjeta");
                        table.AddCell("Tarjeta");
                        table.AddCell("Cuotas");
                        table.AddCell("Bruto");
                        table.AddCell("Costo Fin.");
                        table.AddCell("Costo Ant");
                        table.AddCell("Arancel");
                        table.AddCell("IVA Arancel");
                        table.AddCell("Imp. Deb/Cred");
                        table.AddCell("Reten. IIBB");
                        table.AddCell("Ret. Ganancia");
                        table.AddCell("Ret. IVA");
                        table.AddCell("Total OP");

                        // Agregar los datos a las celdas
                        foreach (var dato in datosFiltrados)
                        {
                            table.AddCell(dato.NroDeAutorizacion?.ToString() ?? "");
                            table.AddCell(dato.NroDeComercio?.ToString() ?? "");
                            table.AddCell(dato.FechaOperacion?.ToString("dd/MM/yyyy") ?? "N/A");
                            table.AddCell(dato.FechaDePago?.ToString("dd/MM/yyyy") ?? "N/A");
                            table.AddCell(dato.NroDeCupon?.ToString() ?? "");
                            table.AddCell(dato.NroDeTarjeta?.ToString() ?? "");
                            table.AddCell(dato.Tarjeta ?? "N/A");
                            table.AddCell(dato.Cuotas?.ToString() ?? "N/A");
                            table.AddCell(dato.TotalBruto?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.CostoFinanciero?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.CostoPorAnticipo?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.Arancel?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.Iva21?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.ImpuestoDebitoCredito?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.RetencionProvincial?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.RetencionGanacia?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.RetencionIva?.ToString("N2") ?? "0.00");
                            table.AddCell(dato.TotalConDescuentos?.ToString("N2") ?? "0.00");
                        }

                        document.Add(table);
                        document.Close();
                    }

                    return File(ms.ToArray(), "application/pdf", "datos.pdf");
                }
            }
            return Unauthorized("El token o el ID de la sesión no son válidos");
        }

    }
}
