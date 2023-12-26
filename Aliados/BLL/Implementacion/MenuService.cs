using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;

namespace BLL.Implementacion
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> _repositorioMenu;
        private readonly IGenericRepository<RolMenu> _repositorioRolMenu;
        private readonly IGenericRepository<UsuarioNos> _repositorioUsuario;

        public MenuService(
            IGenericRepository<Menu> repositorioMenu,
            IGenericRepository<RolMenu> repositorioRolMenu,
            IGenericRepository<UsuarioNos> repositorioUsuario
            )
        {
            _repositorioMenu = repositorioMenu;
            _repositorioRolMenu = repositorioRolMenu;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<List<Menu>> ObtenerMenus(int idUsuario)
        {
            IQueryable<UsuarioNos> tbUsuario = await _repositorioUsuario.Consultar(u => u.IdUsuario == idUsuario);
            IQueryable<RolMenu> tbRolMenu = await _repositorioRolMenu.Consultar();
            IQueryable<Menu> tbMenu = await _repositorioMenu.Consultar();

            IQueryable<Menu> MenuPadre = from u in tbUsuario
                                         join rm in tbRolMenu on u.IdRol equals rm.IdRol
                                         join m in tbMenu on rm.IdMenu equals m.IdMenu
                                         where m.IdMenuPadre == null
                                         select m;

            List<Menu> listaMenu = (from mpadre in MenuPadre
                                    select new Menu()
                                    {
                                        Descripcion = mpadre.Descripcion,
                                        Icono = mpadre.Icono,
                                        Controlador = mpadre.Controlador,
                                        PaginaAccion = mpadre.PaginaAccion
                                    }).ToList();

            return listaMenu;
        }

        public async Task<bool> TienePermisoMenu(int idUsuario, string controlador, string accion)
        {


            IQueryable<UsuarioNos> tbUsuario = await _repositorioUsuario.Consultar(u => u.IdUsuario == idUsuario);
            IQueryable<RolMenu> tbRolMenu = await _repositorioRolMenu.Consultar();
            IQueryable<Menu> tbMenu = await _repositorioMenu.Consultar();

            Menu Menu_Encontrado = (from u in tbUsuario join rm in tbRolMenu on u.IdRol equals rm.IdRol
                                    join m in tbMenu on rm.IdMenu equals m.IdMenu
                                    where m.Controlador == controlador && m.PaginaAccion == accion
                                    select m).FirstOrDefault();

            if(Menu_Encontrado == null) 
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
