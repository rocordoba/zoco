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
    public class LoggDotacionService : ILoggDotacionService
    {
        private readonly IGenericRepository<LoggDotacion> _reposLogs;
        public LoggDotacionService(IGenericRepository<LoggDotacion> repositorio)
        {
            _reposLogs = repositorio;
        }

        public async Task<LoggDotacion> Crear(LoggDotacion entidad)
        {
            //tiene q enviarme de la vista 
            //descripcion, de la tarea  esta haciendo
            //idAccion creada
            //usuario q creo

            entidad.FechaCrea = DateTime.Now;

            LoggDotacion newLog = await _reposLogs.Obtener(d => d.IdLog == entidad.IdLog);
            if (newLog != null)
                throw new TaskCanceledException("El registro ya existe!");


            LoggDotacion logg = await _reposLogs.Crear(entidad);
            try
            {
                if (logg.IdLog == 0)
                    throw new TaskCanceledException("No se puede crear el registro");


                return logg;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<LoggDotacion>> Lista()
        {
            IQueryable<LoggDotacion> query = await _reposLogs.Consultar();
            return query.ToList();
        }
    }
}
