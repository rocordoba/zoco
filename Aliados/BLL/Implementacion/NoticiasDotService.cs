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
    public class NoticiasDotService: INoticiasDotService
    {
        private readonly IGenericRepository<NoticiasDot> _repository;

        public NoticiasDotService(IGenericRepository<NoticiasDot> repository)
        {
            _repository = repository;
        }

        public async Task<NoticiasDot> Crear(NoticiasDot entidad)
        {
            NoticiasDot newDesc = await _repository.Obtener(d => d.IdNoticias == entidad.IdNoticias && d.Descripcion == entidad.Descripcion);

            if (newDesc != null)
                throw new TaskCanceledException("La noticia ya existe!");


            NoticiasDot asesor = await _repository.Crear(entidad);
            try
            {
                if (asesor.IdNoticias == 0)
                    throw new TaskCanceledException("No se puede crear la noticia");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<NoticiasDot> Editar(NoticiasDot entidad)
        {
            NoticiasDot newDesc_existe = await _repository.Obtener(u => u.IdNoticias == entidad.IdNoticias);

            if (newDesc_existe != null)
                throw new TaskCanceledException("La noticia no existe");

            try
            {

                IQueryable<NoticiasDot> queryDesc = await _repository.Consultar(u => u.IdNoticias == entidad.IdNoticias);
                NoticiasDot Desc_editar = queryDesc.First();

                Desc_editar.Descripcion = entidad.Descripcion;
                Desc_editar.IdUsDotacion = entidad.IdUsDotacion;
                Desc_editar.IdAutor = entidad.IdAutor;
                Desc_editar.Titulo = entidad.Titulo;
                Desc_editar.FechaNot = entidad.FechaNot;


                bool respuesta = await _repository.Editar(Desc_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la noticia");


                return Desc_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdNoticiasDot)
        {
            try
            {
                NoticiasDot Desc_encontrado = await _repository.Obtener(u => u.IdNoticias == IdNoticiasDot);

                if (Desc_encontrado == null)
                    throw new TaskCanceledException("El descuento no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<NoticiasDot>> Lista()
        {
            IQueryable<NoticiasDot> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
