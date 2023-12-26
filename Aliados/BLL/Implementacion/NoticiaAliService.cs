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
    public class NoticiaAliService : INoticiaAliService
    {

        private readonly IGenericRepository<Noticias> _repository;

        public NoticiaAliService(IGenericRepository<Noticias> repository)
        {
            _repository = repository;
        }

        public async Task<Noticias> Crear(Noticias entidad)
        {
            Noticias newDesc = await _repository.Obtener(d => d.Id == entidad.Id);

            if (newDesc != null)
                throw new TaskCanceledException("La noticia ya existe!");


            Noticias asesor = await _repository.Crear(entidad);
            try
            {
                if (asesor.Id == 0)
                    throw new TaskCanceledException("No se puede crear la noticia");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Noticias> Editar(Noticias entidad)
        {
            Noticias newDesc_existe = await _repository.Obtener(u => u.Id == entidad.Id);

            if (newDesc_existe != null)
                throw new TaskCanceledException("La noticia no existe");

            try
            {

                IQueryable<Noticias> queryDesc = await _repository.Consultar(u => u.Id == entidad.Id);
                Noticias Desc_editar = queryDesc.First();



                bool respuesta = await _repository.Editar(Desc_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la noticias");


                return Desc_editar;
            }
            catch
            {
                throw;
            };
        }

        public async Task<bool> Eliminar(int IdNoticias)
        {
            try
            {
                Noticias Desc_encontrado = await _repository.Obtener(u => u.Id == IdNoticias);

                if (Desc_encontrado == null)
                    throw new TaskCanceledException("La noticia no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<Noticias>> Lista()
        {
            IQueryable<Noticias> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}
