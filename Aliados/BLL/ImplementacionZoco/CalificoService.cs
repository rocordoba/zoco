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
    public class CalificoService : ICalificoComentarioService
    {
        private readonly IGenericRepository<CalificoCom> _repoCalificoCom;
        private readonly IGenericRepository<Usuarios> _repoUsuario;

        public CalificoService(IGenericRepository<CalificoCom> calificocom, IGenericRepository<Usuarios> repoUsuarios)
        {
            _repoCalificoCom = calificocom;
            _repoUsuario = repoUsuarios;

        }

        public async Task<CalificoCom> Crear(CalificoCom entidad)
        {
            Usuarios usuario_existe = await _repoUsuario.Obtener(u => u.Id == entidad.UsuarioId);

            if (usuario_existe == null)
                throw new TaskCanceledException("No existe el usuario: " + usuario_existe.Nombre);
            var nuevoCalifico = new CalificoCom
            {
                UsuarioId = entidad.UsuarioId,
                NumCalifico=entidad.NumCalifico,
                Descripcion=entidad.Descripcion,
                Fecha=entidad.Fecha,
      

    };
            CalificoCom Comentario = await _repoCalificoCom.Crear(nuevoCalifico);
           
          return Comentario;
        }
       
    }
}
