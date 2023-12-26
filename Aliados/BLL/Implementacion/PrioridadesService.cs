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
    public class PrioridadesService : IPrioridadesService
    {
        private readonly IGenericRepository<Prioridades> _repoPrioridades;

        public PrioridadesService(IGenericRepository<Prioridades> repoPrioridades)
        {
            _repoPrioridades = repoPrioridades;
        }

        public async Task<Prioridades> Crear(Prioridades entidad)
        {
            Prioridades newTerminal = await _repoPrioridades.Obtener(d => d.IdPrioridades == entidad.IdPrioridades);

            if (newTerminal != null)
                throw new TaskCanceledException("La documentaciòn ya existe");


            Prioridades asesor = await _repoPrioridades.Crear(entidad);
            try
            {
                if (asesor.IdPrioridades == 0)
                    throw new TaskCanceledException("No se puede crear el archivo");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Prioridades> Editar(Prioridades entidad)
        {
            Prioridades Terminal_existe = await _repoPrioridades.Obtener(u => u.IdPrioridades == entidad.IdPrioridades);

            if (Terminal_existe != null)
                throw new TaskCanceledException("El archivo no existe");

            try
            {

                IQueryable<Prioridades> queryTerminal = await _repoPrioridades.Consultar(u => u.IdPrioridades == entidad.IdPrioridades);
                Prioridades Terminal_editar = queryTerminal.First();




                bool respuesta = await _repoPrioridades.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el archivo");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdPrioridades)
        {
            try
            {
                Prioridades Term_encontrado = await _repoPrioridades.Obtener(u => u.IdPrioridades == IdPrioridades);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El archivo no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Prioridades>> Lista()
        {
            IQueryable<Prioridades> query = await _repoPrioridades.Consultar();
            return query.ToList();
        }
    }
}
