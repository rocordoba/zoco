using BLL.InterfacesZoco;
using DAL.Interfaces;
using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ImplementacionZoco
{
    public class NotificacionService : INotificacionService
    {
        private readonly IGenericRepository<Noticia> _repoNoticia;
        private readonly IGenericRepository<Usuarios> _repoUsuario;

        public NotificacionService(IGenericRepository<Noticia> repobasedashboard, IGenericRepository<Usuarios> repoUsuarios)
        {
            _repoNoticia = repobasedashboard;
            _repoUsuario = repoUsuarios;

        }
        public async Task<List<Noticia>> Lista()
        {
            IQueryable<Noticia> query = await _repoNoticia.Consultar();
            return query.ToList();
        }
    }
}
