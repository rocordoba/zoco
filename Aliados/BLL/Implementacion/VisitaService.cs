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
    public class VisitaService : IVisitaService
    {
        private readonly IGenericRepository<Visita> _visitasRepo;

        public VisitaService(IGenericRepository<Visita> visitasRepo)
        {
            _visitasRepo = visitasRepo;
        }

        public async Task<Visita> Crear(Visita entidad)
        {
            Visita newVisita = await _visitasRepo.Obtener(d => d.IdVisita == entidad.IdVisita);

            if (newVisita != null)
                throw new TaskCanceledException("La visita ya existe!");


            Visita asesor = await _visitasRepo.Crear(entidad);
            try
            {
                if (asesor.IdVisita == 0)
                    throw new TaskCanceledException("No se puede crear la visita");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Visita> Editar(Visita entidad)
        {
            Visita Visita_existe = await _visitasRepo.Obtener(u => u.IdVisita == entidad.IdVisita);

            if (Visita_existe != null)
                throw new TaskCanceledException("La visita no existe");

            try
            {
                IQueryable<Visita> queryVisita = await _visitasRepo.Consultar(u => u.IdVisita == entidad.IdVisita);
                Visita Visita_editar = queryVisita.First();

                //enrealidad solo seria ESTADO?

                Visita_editar.Observacion = entidad.Observacion;
                Visita_editar.Fecha = entidad.Fecha;
                Visita_editar.IdUsDotacion = entidad.IdUsDotacion;
                Visita_editar.IdTerminal = entidad.IdTerminal;
                Visita_editar.EstadoVisitas = entidad.EstadoVisitas;
                Visita_editar.Coordenadas = entidad.Coordenadas;
                Visita_editar.ImgTerminalUrl = entidad.ImgTerminalUrl;


                bool respuesta = await _visitasRepo.Editar(Visita_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar la visita");


                return Visita_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int IdVisitas)
        {
            try
            {
                Visita Visita_encontrado = await _visitasRepo.Obtener(u => u.IdVisita == IdVisitas);

                if (Visita_encontrado == null)
                    throw new TaskCanceledException("La visita no existe");

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Visita>> Lista()
        {
            IQueryable<Visita> query = await _visitasRepo.Consultar();
            return query.ToList();
        }

        public async Task<List<Visita>> obtenerPorUser(int idUser)
        {
            IQueryable<Visita> query = await _visitasRepo.Consultar(u => u.IdUsDotacion == idUser);
            return query.ToList();
        }

    }
}
