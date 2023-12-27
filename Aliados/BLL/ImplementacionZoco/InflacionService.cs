using BLL.InterfacesZoco;
using DAL.Interfaces;
using Entity.Entity;
using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ImplementacionZoco
{
    public class InflacionService : IInflacionService
    {
        private readonly IGenericRepository<BaseDashboard> _repoBaseDashBoard;
        private readonly IGenericRepository<Inflacion> _repoInflacion;
      

        public InflacionService( IGenericRepository<Inflacion> reposInflacion ,IGenericRepository<BaseDashboard> repobasedashboard)
        {
            _repoBaseDashBoard = repobasedashboard;
            _repoInflacion = reposInflacion;

        }





        /* public async Task<List<Inflacion>> ObtenerPorRubro(string rubro)
         {
             IQueryable<BaseDashboard> tbRubro = await _repoBaseDashBoard.Consultar(u => u.Rubro == rubro);

             IQueryable<Inflacion> inflacions= await _repoInflacion.Consultar(i=>i.Rubro == tbRubro);

             return inflacions.ToList();
         }*/

        public async Task<List<Inflacion>> ObtenerPorRubro(string CuitAliado)
        {
            IQueryable<BaseDashboard> tbrubro = await _repoBaseDashBoard.Consultar(u => u.Cuit == Convert.ToDouble(CuitAliado));

            var rubrosUnicos = tbrubro.Select(r => r.Rubro).Distinct().ToList();

            var inflacionesCoincidentes = await _repoInflacion.Consultar(i => rubrosUnicos.Contains(i.Rubro) || i.Rubro == "Total");

            var inflacionesFiltradas = inflacionesCoincidentes
                .Where(i => i.Fecha <= DateTime.Today)
                .OrderByDescending(i => i.Fecha)
                .ToList();

            var inflacionTotal = inflacionesFiltradas.FirstOrDefault(i => i.Rubro == "Total");

            var resultado = new List<Inflacion>();
            resultado.AddRange(inflacionesFiltradas.Where(i => i.Rubro != "Total"));

            if (inflacionTotal != null)
            {
                resultado.Add(inflacionTotal);
            }

            return resultado;
        }



        async Task<List<Inflacion>> IInflacionService.Lista()
        {
            IQueryable<Inflacion> query = await _repoInflacion.Consultar();
            return query.ToList();
        }
    }
}
