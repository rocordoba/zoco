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

        public async Task<bool> Califico(int IdUsuario)
        {
            // Verificar si el usuario existe
            Usuarios usuario_existe = await _repoUsuario.Obtener(u => u.Id == IdUsuario);
            if (usuario_existe == null)
                throw new TaskCanceledException("No existe el usuario: " + usuario_existe.Nombre);

            // Obtener todos los registros Califico para el usuario
            var calificaciones = await _repoCalifico.Consultar(c => c.UsuarioId == IdUsuario);

            // Verificar si hoy es día 10 o posterior del mes actual
            if (DateTime.Now.Day >= 10)
            {
                // Verificar si hay calificaciones en el mes actual
                bool hayCalificacionesEsteMes = calificaciones.Any(c => c.Fecha.HasValue &&
                                                                        c.Fecha.Value.Month == DateTime.Now.Month &&
                                                                        c.Fecha.Value.Year == DateTime.Now.Year);

                // Si no hay calificaciones en el mes actual, retorna false
                if (!hayCalificacionesEsteMes)
                {
                    return false;
                }
            }

            // Encontrar la fecha más reciente entre las calificaciones
            var fechaMasReciente = calificaciones.Max(c => c.Fecha);

            // Comparar con la fecha actual
            if (fechaMasReciente.HasValue)
            {
                // Si la fecha más reciente es del mes actual o posterior, retorna true
                if (fechaMasReciente.Value.Month == DateTime.Now.Month &&
                    fechaMasReciente.Value.Year == DateTime.Now.Year)
                {
                    return true;
                }
            }

            // Si no hay fecha más reciente o es de un mes anterior, retorna false
            return false;
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
