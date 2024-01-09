using AutoMapper;
using BLL.ImplemtacionZoco;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly IFantasiaComercioService _fantasiaService;
        private readonly IMapper _mapper;
        public ExcelController(IBaseDashboardService sasService, IMapper mapper, IFantasiaComercioService fantasiaService, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _fantasiaService = fantasiaService;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }


        [HttpPost("excel")]
        public async Task<ActionResult> Excel([FromBody] VMDatosInicio request)
        {
            var usuarioEncontrado = await _usuarioZocoService.ObtenerPorId(request.Id);
            var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.Usuario);

            // Suponiendo que sas sea una lista de objetos que corresponden a las filas del Excel
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");

                // Definir las cabeceras Tarjeta

                var currentRow = 1; 

                worksheet.Cell(currentRow, 1).Value = "TERMINAL";
                worksheet.Cell(currentRow, 2).Value = "N OP";
                worksheet.Cell(currentRow, 3).Value = "Fecha OP";
                worksheet.Cell(currentRow, 4).Value = "Fecha Pago";
                worksheet.Cell(currentRow, 5).Value = "N Cupòn";
                worksheet.Cell(currentRow, 6).Value = "N Tarjeta";
                worksheet.Cell(currentRow, 7).Value = "Tarjeta";
                worksheet.Cell(currentRow, 8).Value = "Cuotas";
                worksheet.Cell(currentRow, 9).Value = "Bruto";
                worksheet.Cell(currentRow, 10).Value = "Costo Fin.";
                worksheet.Cell(currentRow, 11).Value = "Costo Ant";
                worksheet.Cell(currentRow, 12).Value = "Arancel";
                worksheet.Cell(currentRow, 13).Value = "IVA Arancel";
                worksheet.Cell(currentRow, 14).Value = "Imp. Deb/Cred";
                worksheet.Cell(currentRow, 15).Value = "Reten. IIBB";
                worksheet.Cell(currentRow, 16).Value = "Ret. Ganancia";
                worksheet.Cell(currentRow, 17).Value = "Ret. IVA";
                worksheet.Cell(currentRow, 18).Value = "Total OP";
                foreach (var dato in sas)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = dato.NroDeAutorizacion;
                    worksheet.Cell(currentRow, 2).Value = dato.NroDeComercio;
                    worksheet.Cell(currentRow, 3).Value = dato.FechaOperacion;
                    worksheet.Cell(currentRow, 4).Value = dato.FechaDePago;
                    worksheet.Cell(currentRow, 5).Value = dato.NroDeCupon;
                    worksheet.Cell(currentRow, 6).Value = dato.NroDeTarjeta;
                    worksheet.Cell(currentRow, 7).Value = dato.Tarjeta;
                    worksheet.Cell(currentRow, 8).Value = dato.Cuotas;
                    worksheet.Cell(currentRow, 9).Value = dato.TotalBruto;
                    worksheet.Cell(currentRow, 10).Value = dato.CostoFinanciero;
                    worksheet.Cell(currentRow, 11).Value = dato.CostoPorAnticipo;
                    worksheet.Cell(currentRow, 12).Value = dato.Arancel;
                    worksheet.Cell(currentRow, 13).Value = dato.Iva21;
                    worksheet.Cell(currentRow, 14).Value = dato.ImpuestoDebitoCredito;
                    worksheet.Cell(currentRow, 15).Value = dato.RetencionProvincial;
                    worksheet.Cell(currentRow, 16).Value = dato.RetencionGanacia;
                    worksheet.Cell(currentRow, 17).Value = dato.RetencionIva;
                    worksheet.Cell(currentRow, 18).Value = dato.TotalConDescuentos;
                }

                // Preparar la respuesta para descargar
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "datos.xlsx"
                    );
                }
            }
        }

    }

}
