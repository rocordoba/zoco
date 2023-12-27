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

        //   public async Task<List<Inflacion>> ObtenerPorRubro(string CuitAliado)
        public async Task<List<Inflacion>> ObtenerPorRubro(string CuitAliado)
        {
            IQueryable<BaseDashboard> tbrubro = await _repoBaseDashBoard.Consultar(u => u.Cuit == Convert.ToDouble(CuitAliado));

            var rubrosUnicos = tbrubro.Select(r => r.Rubro).Distinct().ToList();

            var inflacionesCoincidentes = await _repoInflacion.Consultar(i => rubrosUnicos.Contains(i.Rubro) || i.Rubro == "Total");
            var meses = DateTime.Today.AddMonths(+1);
            var ultimos7Meses = meses.AddMonths(-7); // Obtener la fecha hace 7 meses desde hoy

            var inflacionesFiltradas = inflacionesCoincidentes
     .Where(i => i.Fecha >= ultimos7Meses && i.Fecha <= DateTime.Today)
     .OrderByDescending(i => i.Fecha)
     .Select(i => new Inflacion
     {
         Rubro = i.Rubro,
         Fecha = i.Fecha,
         Inflacion1 = i.Inflacion1,
         // Otras propiedades que tenga el modelo Inflacion, excluyendo el campo "id"
     })
     .ToList();

            return inflacionesFiltradas;

        }




        async Task<List<Inflacion>> IInflacionService.Lista()
        {
            IQueryable<Inflacion> query = await _repoInflacion.Consultar();
            return query.ToList();
        }
    }
}
