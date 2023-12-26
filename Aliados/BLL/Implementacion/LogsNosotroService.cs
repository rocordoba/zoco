using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;

namespace BLL.Implementacion
{
    public class LogsNosotroService : ILogsService
	{
		private readonly IGenericRepository<LoggNosotro> _reposLogs;


        public LogsNosotroService(IGenericRepository<LoggNosotro> repositorio)
        {
            _reposLogs = repositorio;
        }

        public async Task<LoggNosotro> Crear(LoggNosotro entidad)
        {
            //tiene q enviarme de la vista 
            //descripcion, de la tarea  esta haciendo
            //idAccion creada
            //usuario q creo

            entidad.FechaCrea = DateTime.Now;

            LoggNosotro newLog = await _reposLogs.Obtener(d => d.IdLog == entidad.IdLog);
            if (newLog != null)
                throw new TaskCanceledException("El registro ya existe!");


            LoggNosotro logg = await _reposLogs.Crear(entidad);
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

        public async Task<List<LoggNosotro>> Lista()
        {
            IQueryable<LoggNosotro> query = await _reposLogs.Consultar();
            return query.ToList();
        }

        public async Task<LoggNosotro> obtenerPorId(int idUser)
        {
            LoggNosotro logg_existe = await _reposLogs.Obtener(u => u.IdUsuarioCrea == idUser);
            return logg_existe;
        }
    }
}
