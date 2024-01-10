using AutoMapper;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;
        public PDFController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }
        [HttpPost("pdf")]
        public async Task<IActionResult> DownloadPdf([FromBody] VMPDF request)
        {
            var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
            var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);

            // ... lógica para filtrar y preparar los datos ...

            using (var ms = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // Crear una tabla con la cantidad de columnas necesarias
                    PdfPTable table = new PdfPTable(18); // El número de columnas debe coincidir con el número de celdas que agregues

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
                    foreach (var dato in sas)
                    {
                        table.AddCell(dato.NroDeAutorizacion?.ToString() ?? "");
                        table.AddCell(dato.NroDeComercio?.ToString() ?? "");
                        table.AddCell(dato.FechaOperacion?.ToString("dd/MM/yyyy") ?? "N/A"); // Formato de fecha
                        table.AddCell(dato.FechaDePago?.ToString("dd/MM/yyyy") ?? "N/A"); // Formato de fecha
                        table.AddCell(dato.NroDeCupon?.ToString() ?? "");
                        table.AddCell(dato.NroDeTarjeta?.ToString() ?? "");
                        table.AddCell(dato.Tarjeta ?? "N/A");
                        table.AddCell(dato.Cuotas?.ToString() ?? "N/A");
                        table.AddCell(dato.TotalBruto?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.CostoFinanciero?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.CostoPorAnticipo?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.Arancel?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.Iva21?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.ImpuestoDebitoCredito?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.RetencionProvincial?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.RetencionGanacia?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.RetencionIva?.ToString("N2") ?? "0.00"); // Formato numérico
                        table.AddCell(dato.TotalConDescuentos?.ToString("N2") ?? "0.00"); // Formato numérico
                    }


                    document.Add(table);
                    document.Close();
                }

                return File(ms.ToArray(), "application/pdf", "datos.pdf");
            }
        }

    }
}
