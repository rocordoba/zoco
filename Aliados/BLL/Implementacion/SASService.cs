using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Implementacion;
using DAL.Interfaces;
using Entity;
using Entity.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Implementacion
{
    public class SASService : ISASService
    {
        private readonly IGenericRepository<Sas> _repoSas;
        private readonly IGenericRepository<Usuarios> _repoUsuario;
        private readonly IGenericRepository<RazonSocial> _repoRazonSocial;
        private readonly IGenericRepository<FantasiaComercio> _repoFantaciaComercio; 
              private readonly IGenericRepository<Terminal> _repoTerminal;
        public SASService(IGenericRepository<Sas> repoSas, IGenericRepository<Usuarios> repoUsuarios, IGenericRepository<RazonSocial> repoRazonSocial,
            IGenericRepository<FantasiaComercio> repoFantasiaComercio, IGenericRepository<Terminal> repoTerminal)
        {
            _repoSas = repoSas;
            _repoUsuario = repoUsuarios;
            _repoRazonSocial = repoRazonSocial;
            _repoFantaciaComercio = repoFantasiaComercio;
            _repoTerminal = repoTerminal;
                }

        public Task<List<Sas>> ComisionMesAnteriorXidAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> ComisionMesAnteriorXProvincia(int idProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> ComisionXidAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> ComisionxProvincia(int idProvincia)
        {
            throw new NotImplementedException();
        }

       
        public async Task<List<Sas>> DatosInicioAliados(int IdUsuario)
        {
            /*    IQueryable<Usuarios> tbUsuario = await _repoUsuario.Consultar(u => u.IdUsuario == IdUsuario);
                IQueryable<RazonSocial> tbRazonSocial = await _repoRazonSocial.Consultar();
                 IQueryable<FantasiaComercio> tbFantasiaComercio = await _repoFantaciaComercio.Consultar();
                 IQueryable<Terminal> tbTerminal = await _repoTerminal.Consultar();
                 IQueryable<Sas> tbSas = await _repoSas.Consultar();
                var query = from usuario in tbUsuario
                            join razonSocial in tbRazonSocial on usuario.IdUsuario equals razonSocial.IdUsuario
                            join fantasiaComercio in tbFantasiaComercio on razonSocial.IdRazonSocial equals fantasiaComercio.RazSocial
                            join terminal in tbTerminal on fantasiaComercio.IdFantasiaCom equals terminal.IdFantasiaCom
                            join sass in tbSas on terminal.IdTerminal equals sass.NumTerminal
                            select sass;


               */

            throw new NotImplementedException();
        }


        public Task<List<Sas>> FactPorIdAsesorxRubro(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> FactPorProvinciaxRubro(int idProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> FactXTipoXidAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> FactXTipoXProvincia(int idProvincia)
        {
            throw new NotImplementedException();
        }


        //que se pueda eliminar todo un bloque por fecha???


        public async Task<List<Sas>> Historial(string fechaInicio, string fechaFin)
        {
            //cambiarle
            //a la fecha del mes en curso, del primero 

            IQueryable<Sas> query = await _repoSas.Consultar();
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            if (fechaInicio != "" && fechaFin != "")
            {
                return query.ToList();
            }
            DateTime fech_inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
            DateTime fech_fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));
            return query.Where(v => v.FechadePago.Value.Date >= fech_inicio.Date && v.FechadePago.Value.Date <= fech_fin.Date).ToList();
        }

        public async Task<List<Sas>> Lista()
        {
            IQueryable<Sas> query = await _repoSas.Consultar();
            return query.ToList();
        }

        public Task<List<Sas>> TerminalesXCincoFiltrosXAsesor(int IdAsesor, int decTomada, int TipoAlta, int Activación, int RazSoc)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> TerminalesXCincoFiltrosXProv(int IdProvincia, int decTomada, int TipoAlta, int Activación, int RazSoc)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> TotalPorCobrarXAsesor(int IdAsesor)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sas>> TotalPorCobrarXProvincia(int idProvincia)
        {
            throw new NotImplementedException();
        }

       
    }
}
