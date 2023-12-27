using BLL.InterfacesZoco;
using DAL.Interfaces;

using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.ImplementacionZoco
{
    public class BaseDashboardService : IBaseDashboardService
    {
        private readonly IGenericRepository<BaseDashboard> _repoBaseDashBoard;
        private readonly IGenericRepository<Usuarios> _repoUsuario;
 
        public BaseDashboardService(IGenericRepository<BaseDashboard> repobasedashboard, IGenericRepository<Usuarios> repoUsuarios)
        {
            _repoBaseDashBoard = repobasedashboard;
            _repoUsuario = repoUsuarios;
       
        }
        public async Task<List<BaseDashboard>> DatosInicioAliados(string CuitAliado/*, int year, int month, int week, string comercio*/)
        {
            IQueryable<BaseDashboard> tbUsuario = await _repoBaseDashBoard.Consultar(u => u.Cuit == Convert.ToDouble(CuitAliado));

            //if (comercio != "Todos")
            //{
            //    tbUsuario = tbUsuario.Where(u =>
            //        u.NombreComercio == comercio &&
            //        u.AñoPago == year &&
            //        u.MesPago == month &&
            //        u.SemanaMesPago == week
            //    );
            //}
            //else
            //{
            //    tbUsuario = tbUsuario.Where(u =>
            //        u.AñoPago == year &&
            //        u.MesPago == month &&
            //        u.SemanaMesPago == week
            //    );
            //}
            return tbUsuario.ToList();
        }

        public async Task<List<BaseDashboard>> Lista()
        {
            IQueryable<BaseDashboard> query = await _repoBaseDashBoard.Consultar();
            return query.ToList();
        }
    }
}
