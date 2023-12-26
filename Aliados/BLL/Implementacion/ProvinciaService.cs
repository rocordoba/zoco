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
    public class ProvinciaService : IProvinciaService
    {

        private readonly IGenericRepository<Provincia> _repoProv;

        public ProvinciaService(IGenericRepository<Provincia> repoDotacion)
        {
            _repoProv = repoDotacion;
        }
        public async Task<Provincia> Crear(Provincia entidad)
        {
            Provincia newProv = await _repoProv.Obtener(d => d.NombreProvincia == entidad.NombreProvincia);

            if (newProv != null)
                throw new TaskCanceledException("La provincia ya existe");


            Provincia Prov = await _repoProv.Crear(entidad);
            try
            {
                if (Prov.IdProvincia == 0)
                    throw new TaskCanceledException("No se puede crear la provincia");

                return Prov;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Provincia> Editar(Provincia entidad)
        {
            Provincia Prov_existe = await _repoProv.Obtener(u => u.IdProvincia == entidad.IdProvincia);

            if (Prov_existe != null)
                throw new TaskCanceledException("La provincia no existe");

            try
            {
                IQueryable<Provincia> queryUsuario = await _repoProv.Consultar(u => u.IdProvincia == entidad.IdProvincia);
                Provincia Prov_editar = queryUsuario.First();

                Prov_editar.NombreProvincia = entidad.NombreProvincia;
                Prov_editar.Estado = entidad.Estado;
                //Prov_editar.Alicuota = entidad.Alicuota;

                bool respuesta = await _repoProv.Editar(Prov_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la provincia");

                return Prov_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdProvincia)
        {
            try
            {
                Provincia Prov_encontrado = await _repoProv.Obtener(u => u.IdProvincia == IdProvincia);

                if (Prov_encontrado == null)
                    throw new TaskCanceledException("La provincia no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Provincia>> Lista()
        {
            IQueryable<Provincia> query = await _repoProv.Consultar();
            return query.ToList();
        }



    }
}
