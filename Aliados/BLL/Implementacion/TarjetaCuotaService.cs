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
    public class TarjetaCuotaService : ITarjetaCuotaService
    {

        private readonly IGenericRepository<TarjetaCuotas> _repoTarjetaCuota;

        public TarjetaCuotaService(IGenericRepository<TarjetaCuotas> repoTarjetaCuota)
        {
            _repoTarjetaCuota = repoTarjetaCuota;
        }

        public async Task<TarjetaCuotas> Crear(TarjetaCuotas entidad)
        {
            TarjetaCuotas newTerminal = await _repoTarjetaCuota.Obtener(d => d.IdTarjetas == entidad.IdTarjetas);

            if (newTerminal != null)
                throw new TaskCanceledException("El registro ya existe");


            TarjetaCuotas asesor = await _repoTarjetaCuota.Crear(entidad);
            try
            {
                if (asesor.IdTarjetas == 0)
                    throw new TaskCanceledException("No se puede crear el registro");

                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TarjetaCuotas> Editar(TarjetaCuotas entidad)
        {
            TarjetaCuotas Terminal_existe = await _repoTarjetaCuota.Obtener(u => u.IdTarjetas == entidad.IdTarjetas);

            if (Terminal_existe != null)
                throw new TaskCanceledException("La tarjeta no existe");

            try
            {

                IQueryable<TarjetaCuotas> queryTerminal = await _repoTarjetaCuota.Consultar(u => u.IdTarjetas == entidad.IdTarjetas);
                TarjetaCuotas Terminal_editar = queryTerminal.First();

                Terminal_editar.Cuota = Terminal_editar.Cuota;


                bool respuesta = await _repoTarjetaCuota.Editar(Terminal_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el registro");


                return Terminal_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idTarjetaCuota)
        {
            try
            {
                TarjetaCuotas Term_encontrado = await _repoTarjetaCuota.Obtener(u => u.IdTarjetas == idTarjetaCuota);

                if (Term_encontrado == null)
                    throw new TaskCanceledException("El registro no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TarjetaCuotas>> Lista()
        {
            IQueryable<TarjetaCuotas> query = await _repoTarjetaCuota.Consultar();
            return query.ToList();
        }
    }
}
