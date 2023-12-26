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
    public class ProspectoService : IProspectoService
    {

        private readonly IGenericRepository<Prospectos> _repoProspecto;

        public ProspectoService(IGenericRepository<Prospectos> repoDotacion)
        {
            _repoProspecto = repoDotacion;
        }
        public async Task<Prospectos> Crear(Prospectos entidad)
        {
            Prospectos newProspecto = await _repoProspecto.Obtener(d => d.IdProspecto == entidad.IdProspecto && d.NombreResponsable == entidad.NombreResponsable);

            if (newProspecto != null)
                throw new TaskCanceledException("El prospecto ya existe!");


            Prospectos Prospecto = await _repoProspecto.Crear(entidad);
            try
            {
                if (Prospecto.IdProspecto == 0)
                    throw new TaskCanceledException("No se puede crear el prospecto");

                return Prospecto;
            }

            catch (Exception ex)
            {
                throw;
            };
        }

        public async Task<Prospectos> Editar(Prospectos entidad)
        {
            Prospectos Prospecto_existe = await _repoProspecto.Obtener(u => u.IdProspecto == entidad.IdProspecto );

            if (Prospecto_existe != null)
                throw new TaskCanceledException("El prospecto no existe");

            try
            {

                IQueryable<Prospectos> queryProsp = await _repoProspecto.Consultar(u => u.IdProspecto == entidad.IdProspecto);
                Prospectos prosp_editar = queryProsp.First();



                prosp_editar.IdUsuario = entidad.IdUsuario;
                //prosp_editar.IDPRO = entidad.IdLocalidad;
                prosp_editar.NombreResponsable = entidad.NombreResponsable;
                prosp_editar.TelefonoRespon = entidad.TelefonoRespon;
                prosp_editar.FactAprox = entidad.FactAprox;
                prosp_editar.TermCerrada = entidad.TermProyectadas;
                prosp_editar.TermProyectadas = entidad.TermProyectadas;
                prosp_editar.Observaciones = entidad.Observaciones;


                bool respuesta = await _repoProspecto.Editar(prosp_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el prospecto");


                return prosp_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdProspecto)
        {
            try
            {
                Prospectos Prosp_encontrado = await _repoProspecto.Obtener(u => u.IdProspecto == IdProspecto);
                if (Prosp_encontrado == null)
                    throw new TaskCanceledException("El Prospecto no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Prospectos>> Lista()
        {
            IQueryable<Prospectos> query = await _repoProspecto.Consultar();
            return query.ToList();
        }


        public async Task<List<Prospectos>> obtenerPorUsuario(int idUser)
        {
            IQueryable<Prospectos> query = await _repoProspecto.Consultar(u => u.IdUsuario == idUser);
            return query.ToList();
        }


        //public async Task<List<Prospecto>> obtenerPorLocalidad(int idLocalidad)
        //{
        //    IQueryable<Prospecto> query = await _repoProspecto.Consultar(u => u.IdLocalidad == idLocalidad);
        //    return query.ToList();
        //}
    }
}
