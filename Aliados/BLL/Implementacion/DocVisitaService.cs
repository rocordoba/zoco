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
    public class DocVisitaService : IDocVisitaService
    {
        private readonly IGenericRepository<DocVisita> _repositoryDocumentacion;

        public DocVisitaService(IGenericRepository<DocVisita> repository)
        {
            _repositoryDocumentacion = repository;
        }

        public async Task<DocVisita> Crear(DocVisita entidad)
        {
            DocVisita newTerminal = await _repositoryDocumentacion.Obtener(d => d.IdDocumentacion == entidad.IdDocumentacion);

            if (newTerminal != null)
                throw new TaskCanceledException("La documentaciòn ya existe");


            DocVisita asesor = await _repositoryDocumentacion.Crear(entidad);
            try
            {
                if (asesor.IdDocumentacion == 0)
                    throw new TaskCanceledException("No se puede crear el archivo");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<DocVisita> Editar(DocVisita entidad)
        {
            DocVisita Terminal_existe = await _repositoryDocumentacion.Obtener(u => u.IdDocumentacion == entidad.IdDocumentacion);

            if (Terminal_existe != null)
                throw new TaskCanceledException("El archivo no existe");

            try
            {

                IQueryable<DocVisita> queryTerminal = await _repositoryDocumentacion.Consultar(u => u.IdDocumentacion == entidad.IdDocumentacion);
                DocVisita Terminal_editar = queryTerminal.First();


                Terminal_editar.Descripcion = entidad.Descripcion;
                Terminal_editar.NombreArchivo = entidad.NombreArchivo;
                Terminal_editar.UrlArchivo = entidad.UrlArchivo;
                Terminal_editar.Idvisita = entidad.Idvisita;

                bool respuesta = await _repositoryDocumentacion.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el archivo");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdDocVisita)
        {
            try
            {
                DocVisita Term_encontrado = await _repositoryDocumentacion.Obtener(u => u.IdDocumentacion == IdDocVisita);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El archivo no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DocVisita>> Lista()
        {
            IQueryable<DocVisita> query = await _repositoryDocumentacion.Consultar();
            return query.ToList();
        }
    }
}
