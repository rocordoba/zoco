//using BLL.Interfaces;
//using DAL.Interfaces;
//using Entity.Entity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Win32;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Metrics;
//using System.Globalization;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Implementacion
//{
//    public class InicioService : IInicioService
//    {
//        private readonly IGenericRepository<Sas> _repositorioSas;
//        private readonly IGenericRepository<Terminal> _repositorioTerminales;
//        private readonly IGenericRepository<FantasiaComercio> _repositorioFantasia;
//        private DateTime FechaInicio = DateTime.Now;

//        public InicioService(IGenericRepository<Sas> repositorioSas, IGenericRepository<Terminal> repositorioTerminales, IGenericRepository<FantasiaComercio> repositorioFantasia)
//        {
//            _repositorioSas = repositorioSas;
//            _repositorioTerminales = repositorioTerminales;
//            _repositorioFantasia = repositorioFantasia;
//            FechaInicio = FechaInicio.AddDays(-7);
//        }


//        //hay que traerlas por provincia, o por asesor

//        //public async Task<int> TotalActivas()
//        //{
//        //    try
//        //    {
//        //        int estadoActivo = 1;

//        //        IQueryable<Terminal> terminalesActivas = await _repositorioTerminales
//        //            .Consultar(t => t.Estado == estadoActivo);

//        //        int totalActivas = terminalesActivas.Count();

//        //        return totalActivas;
//        //    }
//        //    catch
//        //    {
//        //        throw;
//        //    }
//        //}


//        public async Task<int> TotalBajas()
//        {
//            try
//            {
//                //o el que corresponda
//                int estadoActivo = 0;

//                IQueryable<Terminal> terminalesActivas = await _repositorioTerminales
//                    .Consultar(t => t.Estado == estadoActivo);

//                int totalActivas = terminalesActivas.Count();

//                return totalActivas;
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public Task<Dictionary<string, int>> TotalComisionMesCurso()
//        {
//            //lo mismo que mes pasado, solo que sacando el porcentaje !
//                    throw new NotImplementedException();
//        }
//        public Task<Dictionary<string, int>> TotalComisionMesPasado()
//        {
//            throw new NotImplementedException();
//        }
//        public async Task<int> TotalTerminales()
//        {
//            try
//            {
//                int estadoActivo = 1;

//                IQueryable<Terminal> terminalesActivas = await _repositorioTerminales.Consultar();

//                int totalActivas = terminalesActivas.Count();

//                return totalActivas;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Dictionary<string, int>> VentasMesCurso()
//        {
//            try
//            {
//                DateTime fechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

//                IQueryable<Sas> query = await _repositorioSas
//                    .Consultar(v => v.FechadePago.Value.Date >= fechaInicioMes);

//                Dictionary<string, int> resultado = query
//                    .GroupBy(v => v.FechadePago.Value.Date)
//                    .OrderByDescending(g => g.Key)
//                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
//                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);

//                return resultado;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //public async Task<string> TotalIngresosUltimaSemana()
//        //{
//        //    try
//        //    {
//        //        IQueryable<Venta> query = await _repositorioVenta.Consultar(v => v.FechaRegistro.Value.Date >= FechaInicio.Date);

//        //        decimal resultado = query
//        //            .Select(v => v.Total)
//        //            .Sum(v => v.Value);

//        //        return Convert.ToString(resultado, new CultureInfo("es-PE"));
//        //    }
//        //    catch
//        //    {
//        //        throw;
//        //    }
//        //}

//        //public async Task<List<VMTotalComisionMesCurso>> VentasMesCurso()
//        //    {
//        //        try
//        //        {
//        //            DateTime fechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

//        //            IQueryable<SAS> query = await _repositorioSas
//        //                .Consultar(v => v.FechadePago.Value.Date >= fechaInicioMes);

//        //            List<VMTotalComisionMesCurso> resultado = query
//        //                .GroupBy(v => v.FechadePago.Value.Date)
//        //                .OrderByDescending(g => g.Key)
//        //                .Select(dv => new VMTotalComisionMesCurso
//        //                {
//        //                    Mes = dv.Key.ToString("dd/MM/yyyy"),
//        //                    Total = dv.Count()
//        //                })
//        //                .ToList();

//        //            return resultado;
//        //        }
//        //        catch
//        //        {
//        //            throw;
//        //        }
//        //    }

//        public async Task<Dictionary<string, int>> VentasMesPasado()
//        {
//            try
//            {
//                DateTime fechaInicioMesPasado = DateTime.Now.AddMonths(-1).Date;
//                DateTime fechaActual = DateTime.Now.Date;

//                IQueryable<Sas> query = await _repositorioSas
//                    .Consultar(v => v.FechadePago.Value.Date >= fechaInicioMesPasado && v.FechadePago.Value.Date <= fechaActual);

//                Dictionary<string, int> resultado = query
//                    .GroupBy(v => v.FechadePago.Value.Date)
//                    .OrderByDescending(g => g.Key)
//                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
//                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);

//                return resultado;
//            }
//            catch
//            {
//                throw;
//            }
//        }



//        Task<Dictionary<string, int>> IInicioService.TotalTipoDePago()
//        {
//            throw new NotImplementedException();
//        }
//    }

//}