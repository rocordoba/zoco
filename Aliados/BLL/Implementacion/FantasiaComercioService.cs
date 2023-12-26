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
    public class FantasiaComercioService : IFantasiaComercioService
    {

        private readonly IGenericRepository<FantasiaComercio> _repoFantasia;
        private readonly IGenericRepository<Sas> _repoSas;
        private readonly IGenericRepository<Usuarios> _repoUsuario;
        private readonly IGenericRepository<RazonSocial> _repoRazonSocial;
        private readonly IGenericRepository<FantasiaComercio> _repoFantaciaComercio;
        private readonly IGenericRepository<Terminal> _repoTerminal;
        public FantasiaComercioService(IGenericRepository<FantasiaComercio> repoDotacion, IGenericRepository<Sas> repoSas, IGenericRepository<Usuarios> repoUsuarios, IGenericRepository<RazonSocial> repoRazonSocial,
            IGenericRepository<FantasiaComercio> repoFantasiaComercio, IGenericRepository<Terminal> repoTerminal)
        {
            _repoSas = repoSas;
            _repoUsuario = repoUsuarios;
            _repoRazonSocial = repoRazonSocial;
            _repoFantaciaComercio = repoFantasiaComercio;
            _repoTerminal = repoTerminal;
            _repoFantasia = repoDotacion;
        }


        public async Task<List<FantasiaComercio>> DatosInicioAliadosFiltros(int IdUsuario)
        {
            IQueryable<Usuarios> tbUsuarios = await _repoUsuario.Consultar(u => u.IdUsuario == IdUsuario);
            IQueryable<RazonSocial> tbRazonSocial = await _repoRazonSocial.Consultar();
            IQueryable<FantasiaComercio> tbFantasiaComercio = await _repoFantaciaComercio.Consultar();
            var query = from usuario in tbUsuarios
                        join razonsocial in tbRazonSocial on usuario.IdUsuario equals razonsocial.IdUsuario
                        join fantasiacomercion in tbFantasiaComercio on razonsocial.IdRazonSocial equals fantasiacomercion.RazSocial
                        select fantasiacomercion;


            return query.ToList();

        }
        public async Task<FantasiaComercio> Crear(FantasiaComercio entidad)
        {
            FantasiaComercio newFantasia = await _repoFantasia.Obtener(d => d.RazSocial == entidad.RazSocial && d.NombreFantasia == entidad.NombreFantasia);

            if (newFantasia != null)
                throw new TaskCanceledException("El comercio con el mismo nombre, ya existe!");


            FantasiaComercio fantasia = await _repoFantasia.Crear(entidad);
            try
            {
                if (fantasia.IdFantasiaCom == 0)
                    throw new TaskCanceledException("No se puede crear el comercio");

                return fantasia;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FantasiaComercio> Editar(FantasiaComercio entidad)
        {
            FantasiaComercio fantasia_existe = await _repoFantasia.Obtener(u => u.NombreFantasia == entidad.NombreFantasia && u.RazSocial != entidad.RazSocial);

            if (fantasia_existe != null)
                throw new TaskCanceledException("El comercio no existe");

            try
            {

                IQueryable<FantasiaComercio> queryFantasia = await _repoFantasia.Consultar(u => u.IdFantasiaCom == entidad.IdFantasiaCom);
                FantasiaComercio fantasia_editar = queryFantasia.First();

                fantasia_editar.NombreFantasia = entidad.NombreFantasia;
                fantasia_editar.DomicilioFiscal = entidad.DomicilioFiscal;
                fantasia_editar.Telefono = entidad.Telefono;
                fantasia_editar.LinkDePago = entidad.LinkDePago;
                fantasia_editar.EstadoAfip = entidad.EstadoAfip;
                fantasia_editar.EstadoRentas = entidad.EstadoRentas;
                fantasia_editar.Provincia = entidad.Provincia;
                fantasia_editar.RubroUno = entidad.RubroUno;
                fantasia_editar.RubroDos = entidad.RubroDos;
                fantasia_editar.ActividadAfip = entidad.ActividadAfip;
                fantasia_editar.ActividadAfipDos = entidad.ActividadAfipDos;
                fantasia_editar.RazSocial = entidad.RazSocial;
                fantasia_editar.ActividadRentas = entidad.ActividadRentas;
                fantasia_editar.ActividadRentasDos = entidad.ActividadRentasDos;
                fantasia_editar.AltaAhoraDoce = entidad.AltaAhoraDoce;
                fantasia_editar.FechaAlta = entidad.FechaAlta;
                fantasia_editar.DiasParaAlta = entidad.DiasParaAlta;
                fantasia_editar.NumDeComercio = entidad.NumDeComercio;
                fantasia_editar.NumLocal = entidad.NumLocal;


                bool respuesta = await _repoFantasia.Editar(fantasia_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el comercio");


                return fantasia_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdFantasiaComercio)
        {
            try
            {
                FantasiaComercio Fant_encontrado = await _repoFantasia.Obtener(u => u.IdFantasiaCom == IdFantasiaComercio);
                if (Fant_encontrado == null)
                    throw new TaskCanceledException("El comercio no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<FantasiaComercio>> Lista()
        {
            IQueryable<FantasiaComercio> query = await _repoFantasia.Consultar();
            return query.ToList();
        }

        public async Task<FantasiaComercio> obtenerPorId(int idFant)
        {
            FantasiaComercio fants_existe = await _repoFantasia.Obtener(u => u.IdFantasiaCom == idFant);
            return fants_existe;
        }


        //fantias traer por aliado - por terminal 

        //public async Task<FantasiaComercio> obtenerPorAliado(int provincia)
        //{
        //    FantasiaComercio newAsesor = await _repoDotacion.Obtener(d => d.RazSocial == entidad.RazSocial && d.NombreFantasia == entidad.NombreFantasia);

        //    if (newAsesor != null)
        //        throw new TaskCanceledException("El comercio con el mismo nombre, ya existe!");


        //    FantasiaComercio asesor = await _repoDotacion.Crear(entidad);
        //    try
        //    {
        //        if (asesor.IdFantasiaCom == 0)
        //            throw new TaskCanceledException("No se puede crear el comercio");

        //        return asesor;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
