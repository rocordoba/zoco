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
    public class RazonSocialService : IRazonSocialService
    {
        private readonly IGenericRepository<RazonSocial> _repository;

        public RazonSocialService(IGenericRepository<RazonSocial> repository)
        {
            _repository = repository;
        }

        public async Task<RazonSocial> Crear(RazonSocial entidad)
        {

            RazonSocial newRazSoc = await _repository.Obtener(d => d.Cuit == entidad.Cuit);

            if (newRazSoc != null)
                throw new TaskCanceledException("La razón social ya existe");


            RazonSocial RazSoc = await _repository.Crear(entidad);
            try
            {
                if (RazSoc.IdRazonSocial == 0)
                    throw new TaskCanceledException("No se puede crear la razón social");


                return RazSoc;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RazonSocial> Editar(RazonSocial entidad)
        {
            RazonSocial RazSoc_existe = await _repository.Obtener(u => u.IdRazonSocial == entidad.IdRazonSocial);

            if (RazSoc_existe != null)
                throw new TaskCanceledException("La razón social no existe");

            try
            {
                IQueryable<RazonSocial> queryRazSoc = await _repository.Consultar(u => u.IdRazonSocial == entidad.IdRazonSocial);
                RazonSocial RazSoc_editar = queryRazSoc.First();

                RazSoc_editar.IdUsuario = entidad.IdUsuario;
                RazSoc_editar.Cuit = entidad.Cuit;
                //RazSoc_editar.Exento = entidad.Exento;
                RazSoc_editar.NombreRazonSoc = entidad.NombreRazonSoc;

                RazSoc_editar.DomicilioFiscal = entidad.DomicilioFiscal;
                RazSoc_editar.Banco = entidad.Banco;
                RazSoc_editar.TipoCuenta = entidad.TipoCuenta;
                RazSoc_editar.CbuCvu = entidad.CbuCvu;
                RazSoc_editar.NumCta = entidad.NumCta;
                RazSoc_editar.LargoCbu = entidad.LargoCbu;
                RazSoc_editar.AliasCbu = entidad.AliasCbu;

                bool respuesta = await _repository.Editar(RazSoc_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la razón social");

                return RazSoc_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdRazonSocial)
        {
            try
            {
                RazonSocial RazSoc_encontrado = await _repository.Obtener(u => u.IdRazonSocial == IdRazonSocial);

                if (RazSoc_encontrado == null)
                    throw new TaskCanceledException("La razón social no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RazonSocial>> Lista()
        {
            IQueryable<RazonSocial> query = await _repository.Consultar();
            return query.ToList();
        }

        public async Task<List<RazonSocial>> obtenerPorCUIT(int cuit)
        {
            IQueryable<RazonSocial> query = await _repository.Consultar(u => u.Cuit == cuit);
            return query.ToList();
        }

    }
}
