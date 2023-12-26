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
    public class TerminalesService : ITerminalService
    {
        private readonly IGenericRepository<Terminal> _repoTerminales;

        public TerminalesService(IGenericRepository<Terminal> repoDotacion)
        {
            _repoTerminales = repoDotacion;
        }
        public async Task<List<Terminal>> Lista()
        {
            IQueryable<Terminal> query = await _repoTerminales.Consultar();
            return query.ToList();
        }


        public async Task<Terminal> Crear(Terminal entidad)
        {
            Terminal newTerminal = await _repoTerminales.Obtener(d => d.IdTerminal == entidad.IdTerminal);

            if (newTerminal != null)
                throw new TaskCanceledException("La terminal ya existe");


            Terminal asesor = await _repoTerminales.Crear(entidad);
            try
            {
                if (asesor.IdTerminal == 0)
                    throw new TaskCanceledException("No se puede crear la terminal");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Terminal> Editar(Terminal entidad)
        {
            Terminal Terminal_existe = await _repoTerminales.Obtener(u => u.IdTerminal == entidad.IdTerminal);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La terminal no existe");

            try
            {

                IQueryable<Terminal> queryTerminal = await _repoTerminales.Consultar(u => u.IdTerminal == entidad.IdTerminal);
                Terminal Terminal_editar = queryTerminal.First();

                //Terminal_editar.Origen = Terminal_editar.Origen;
                //Terminal_editar.Destino = Terminal_editar.Destino;
                //Terminal_editar.ReUbicacion = Terminal_editar.ReUbicacion;

                bool respuesta = await _repoTerminales.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la terminal");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdTerminales)
        {
            try
            {
                Terminal Term_encontrado = await _repoTerminales.Obtener(u => u.IdTerminal == IdTerminales);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("La terminal no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }


        public async Task<Terminal> obtenerPorNumTerm(int NumTerm)
        {
            Terminal Terminal_existe = await _repoTerminales.Obtener(u => u.NumTerminal == NumTerm);
            return Terminal_existe;
        }

        public Task<int> obtenerPorActivasTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorAltasTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajoAnalisisTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorReubicarTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorDisponibleTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajasTodas()
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorActivasXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorActivasXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorAltasXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorAltasXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajoAnalisisXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajoAnalisisXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorReubicarXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorReubicarXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorDisponiblesXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorDisponiblesXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajasXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> obtenerPorBajasXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<int> TerminalesTodasXIdAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<int> TerminalesTodasXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> obtenerPorEstadoXAsesor(int IdEstado, int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> obtenerPorEstadoXProvincia(int IdEstado, int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> obtenerPorEstadoXAsesorMesPasado(int IdEstado, int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> obtenerPorEstadoXProvinciaMesPasado(int IdEstado, int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TermPorRazSoc(int IdRazSoc)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TermPorRazSocXAsersor(int IdRazSoc, int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TermPorRazSocXProvincia(int IdRazSoc, int IdProvincia)
        {
            throw new NotImplementedException();
        }

        Task<List<Terminal>> ITerminalService.obtenerPorNumTerm(int IdTerminales)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TermTodasXIdAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TermTodasXProvincia(int IdProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TerminalesXCincoFiltrosXAsesor(int IdAsesor, int decTomada, int TipoAlta, int Activación, int RazSoc)
        {
            throw new NotImplementedException();
        }

        public Task<List<Terminal>> TerminalesXCincoFiltrosXProv(int IdProvincia, int decTomada, int TipoAlta, int Activación, int RazSoc)
        {
            throw new NotImplementedException();
        }
    }
}
