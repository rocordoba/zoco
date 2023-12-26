//using BLL.Interfaces;
//using DAL.Interfaces;
//using Entity.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Implementacion
//{
//    public class RepresentantePosnetService : IRepresentantePosnetService
//    {
//        private readonly IGenericRepository<RepresentantePosnet> _repoRepresentantePosnet;

//        public RepresentantePosnetService(IGenericRepository<RepresentantePosnet> repoRepresentantePosnet)
//        {
//            _repoRepresentantePosnet = repoRepresentantePosnet;
//        }

//        public async Task<RepresentantePosnet> Crear(RepresentantePosnet entidad)
//        {
//            RepresentantePosnet newAsesor = await _repoRepresentantePosnet.Obtener(d => d.IdStockTerminales == entidad.IdStockTerminales);

//            if (newAsesor != null)
//                throw new TaskCanceledException("El asesor ya existe!");


//            RepresentantePosnet asesor = await _repoRepresentantePosnet.Crear(entidad);
//            try
//            {
//                if (asesor.id == 0)
//                    throw new TaskCanceledException("No se puede crear el asesor");


//                return asesor;
//            }

//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public async Task<RepresentantePosnet> Editar(RepresentantePosnet entidad)
//        {
//            RepresentantePosnet asesor_existe = await _repoRepresentantePosnet.Obtener(u => u.IdStockTerminales == entidad.IdStockTerminales);

//            if (asesor_existe != null)
//                throw new TaskCanceledException("El asesor no existe");

//            try
//            {

//                IQueryable<RepresentantePosnet> queryUsuario = await _repoRepresentantePosnet.Consultar(u => u.IdDotacion == entidad.IdDotacion);
//                RepresentantePosnet asesor_editar = queryUsuario.First();


//                bool respuesta = await _repoRepresentantePosnet.Editar(asesor_editar);

//                if (!respuesta)
//                    throw new TaskCanceledException("No se pudo modificar el asesor");

//                return asesor_editar;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<bool> Eliminar(int IdRepresentantePosnet)
//        {
//            try
//            {
//                RepresentantePosnet Dot_encontrado = await _repoRepresentantePosnet.Obtener(u => u.IdStockTerminales == idStockAsesor);

//                if (Dot_encontrado == null)
//                    throw new TaskCanceledException("El asesor no existe");

//                return true;

//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<List<RepresentantePosnet>> Lista()
//        {
//            IQueryable<RepresentantePosnet> query = await _repoRepresentantePosnet.Consultar();
//            return query.ToList();
//        }
//    }
//}
