using BLL.Interfaces;
using DAL.Interfaces;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementacion
{
    public class RespNoticiasDotService: IRespNoticiasDotService
    {

        private readonly IGenericRepository<RespNoticiasDot> _repositorio;

        public RespNoticiasDotService(IGenericRepository<RespNoticiasDot> repository)
        {
            _repositorio = repository;
        }

        public async Task<RespNoticiasDot> Crear(RespNoticiasDot entidad)
        {
            RespNoticiasDot newTerminal = await _repositorio.Obtener(d => d.IdNoticias == entidad.IdNoticias);

            if (newTerminal != null)
                throw new TaskCanceledException("La respuesta ya existe");


            RespNoticiasDot asesor = await _repositorio.Crear(entidad);
            try
            {
                if (asesor.IdNoticias == 0)
                    throw new TaskCanceledException("No se puede crear la respuesta");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RespNoticiasDot> Editar(RespNoticiasDot entidad)
        {
            RespNoticiasDot Terminal_existe = await _repositorio.Obtener(u => u.IdNoticias == entidad.IdNoticias);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La respuesta no existe");

            try
            {

                IQueryable<RespNoticiasDot> queryTerminal = await _repositorio.Consultar(u => u.IdNoticias == entidad.IdNoticias);
                RespNoticiasDot Terminal_editar = queryTerminal.First();

                DateTime horaActual = DateTime.Now;


                Terminal_editar.Descripcion = entidad.Descripcion;
                Terminal_editar.Titulo = entidad.Titulo;
                Terminal_editar.FechaNot = horaActual;

                bool respuesta = await _repositorio.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la respuesta");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdRespNoticiasDot)
        {
            try
            {
                RespNoticiasDot Term_encontrado = await _repositorio.Obtener(u => u.IdNoticias == IdRespNoticiasDot);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La respuesta no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RespNoticiasDot>> Lista()
        {
            IQueryable<RespNoticiasDot> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
