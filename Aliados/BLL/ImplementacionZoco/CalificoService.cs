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
    internal class CalificoService : ICalificoComentarioService
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

            if (usuario_existe != null)
                throw new TaskCanceledException("No existe el usuario: " + usuario_existe.Nombre);

            CalificoCom Comentario = await _repoCalificoCom.Crear(entidad);
           
          return Comentario;
        }
        //public async Task<Usuarios> Crear(Usuarios entidad)
        //{
        //    Usuarios usuario_existe = await _repositorioUser.Obtener(u => u.Correo == entidad.Correo);

        //    if (usuario_existe != null)
        //        throw new TaskCanceledException("El correo ya existe, con el nombre: " + usuario_existe.Nombre);

        //    Usuarios usuario_creado = await _repositorioUser.Crear(entidad);
        //    try
        //    {

        //        string clave_generada = _utilidadesService.GenerarClave();
        //        entidad.Clave = _utilidadesService.ConvertirSha256(clave_generada);

        //        if (usuario_creado.IdUsuario == 0)
        //            throw new TaskCanceledException("No se pudo crear el usuario");


        //        IQueryable<Usuarios> query = await _repositorioUser.Consultar(u => u.IdUsuario == usuario_creado.IdUsuario);
        //        usuario_creado = query.First();

        //        return usuario_creado;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
