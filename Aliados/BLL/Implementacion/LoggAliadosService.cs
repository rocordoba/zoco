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
    public class LoggAliadosService: ILoggAliadosService
    {
        private readonly IGenericRepository<LoggAliado> _reposLogs;


        public LoggAliadosService(IGenericRepository<LoggAliado> repositorio)
        {
            _reposLogs = repositorio;
        }

        public async Task<LoggAliado> Crear(LoggAliado entidad)
        {
            entidad.FechaCrea = DateTime.Now;

            LoggAliado newLog = await _reposLogs.Obtener(d => d.IdLog == entidad.IdLog);
            if (newLog != null)
                throw new TaskCanceledException("El registro ya existe!");


            LoggAliado logg = await _reposLogs.Crear(entidad);
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

        public async Task<List<LoggAliado>> Lista()
        {
            IQueryable<LoggAliado> query = await _reposLogs.Consultar();
            return query.ToList();
        }
    }
}
