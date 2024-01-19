using AutoMapper;
using BLL.ImplemtacionZoco;
using BLL.Interfaces;
using BLL.InterfacesZoco;
using dash_aliados.Models.ViewModelsZoco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace dash_aliados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IBaseDashboardService _baseService;
        private readonly IUsuarioZocoService _usuarioZocoService;
        private readonly ITokenService _tokenservice;
        private readonly IMapper _mapper;
        public ExcelController(IBaseDashboardService sasService, IMapper mapper, ITokenService tok, IUsuarioZocoService usuarioZoco)
        {
            _baseService = sasService;
            _tokenservice = tok;
            _mapper = mapper;
            _usuarioZocoService = usuarioZoco;
        }


        [HttpPost("excel")]
        public async Task<ActionResult> Excel([FromBody] VMExcel request)
        {
            bool esTokenValido = await _tokenservice.ValidarTokenAsync(request.Token);
            if (esTokenValido == true)
            {
                var currentDate = DateTime.Today;
                var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                var usuarioEncontrado = await _tokenservice.ObtenerTokenYUsuarioPorUsuarioIdAsync(request.Token);
                var sas = await _baseService.DatosInicioAliados(usuarioEncontrado.usuario.Usuario);
           
                    if (request.comercio.ToLower() == "todos")
                    {
                        // Calcular el primer y último día del mes
                        var primerDiaMes = new DateTime(request.Year, request.Month, 1);
                        var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                    // Filtrar datos basados en el rango de fechas
                           var datosFiltrados = sas.Where(dato => dato.FechaDePago?.Date >= primerDiaMes && dato.FechaDePago?.Date <= ultimoDiaMes)
                             .OrderByDescending(dato => dato.FechaDePago) // Ordenar por FechaDePago de manera descendente
                                   .ToList();
                    using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Datos");



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
                            foreach (var dato in datosFiltrados)
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
                    else
                    {

                        sas = sas.Where(s => s.NombreComercio != null && s.NombreComercio.ToLower() == request.comercio.ToLower()).ToList();
                        // Calcular el primer y último día del mes
                        var primerDiaMes = new DateTime(request.Year, request.Month, 1);
                        var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

                    // Filtrar datos basados en el rango de fechas
                    var datosFiltrados = sas.Where(dato => dato.FechaDePago?.Date >= primerDiaMes && dato.FechaDePago?.Date <= ultimoDiaMes)
                    .OrderByDescending(dato => dato.FechaDePago) // Ordenar por FechaDePago de manera descendente
                        .ToList();


                    using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Datos");



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
                            foreach (var dato in datosFiltrados)
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
            return Unauthorized("El token o el ID de la sesión no son válidos");
        }

    }

}
