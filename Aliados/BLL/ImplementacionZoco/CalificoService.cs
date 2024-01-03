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
        private readonly IGenericRepository<Califico> _repoCalifico;
        private readonly IGenericRepository<Usuarios> _repoUsuario;

        public CalificoService(IGenericRepository<CalificoCom> calificocom, IGenericRepository<Califico> califico, IGenericRepository<Usuarios> repoUsuarios)
        {
            _repoCalificoCom = calificocom;
            _repoUsuario = repoUsuarios;
            _repoCalifico = califico;
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

        public async Task<Califico> CrearComentario(Califico entidad)
        {
            // Verificar si el usuario existe
            Usuarios usuario_existe = await _repoUsuario.Obtener(u => u.Id == entidad.UsuarioId);

            if (usuario_existe == null)
            {
                throw new TaskCanceledException("No existe el usuario con ID: " + entidad.UsuarioId);
            }

            // Crear un nuevo comentario
            var nuevoCalifico = new Califico
            {
                UsuarioId = entidad.UsuarioId,
                NumCalifico = entidad.NumCalifico,
                Califico1 = true, // Asegúrate de que este campo se maneje adecuadamente
                Fecha = entidad.Fecha
            };

            // Guardar el nuevo comentario en el repositorio
            Califico comentarioCreado = await _repoCalifico.Crear(nuevoCalifico);

            return comentarioCreado;
        }

    }
}
