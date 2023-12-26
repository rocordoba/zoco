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
    public class DotacionService : IDotacionService
    {
        private readonly IGenericRepository<Dotacion> _repoDotacion;

        public DotacionService(IGenericRepository<Dotacion> repoDotacion)
        {
            _repoDotacion = repoDotacion;
        }

        //que se lo pueda eliminar, y se lo pueda dar de baja 
        //guardar fecha baja, y cambiar el esActivo


        public async Task<Dotacion> Crear(Dotacion entidad)
        {

            Dotacion newAsesor = await _repoDotacion.Obtener(d => d.CuitCuil == entidad.CuitCuil);

            if(newAsesor != null)
                throw new TaskCanceledException("El asesor ya existe!");


            Dotacion asesor = await _repoDotacion.Crear(entidad);
            try
            {
                if(asesor.IdDotacion == 0)
                    throw new TaskCanceledException("No se puede crear el asesor");


                return asesor;
            }

            catch (Exception ex)
            {
                throw;
            }

            //DEBE CREARSELE EL USUARIO? Y CONTRASEÑA // ENVIAR CORREO 
        }

        public async Task<Dotacion> Editar(Dotacion entidad)
        {
            Dotacion asesor_existe = await _repoDotacion.Obtener(u => u.Correo == entidad.Correo && u.IdDotacion != entidad.IdDotacion);

            if (asesor_existe != null)
                throw new TaskCanceledException("El asesor no existe");

            try
            {

                IQueryable<Dotacion> queryUsuario = await _repoDotacion.Consultar(u => u.IdDotacion == entidad.IdDotacion);
                Dotacion asesor_editar = queryUsuario.First();

                asesor_editar.ApellidoNombre = entidad.ApellidoNombre;
                asesor_editar.CuitCuil = entidad.CuitCuil;
                asesor_editar.Provincia = entidad.Provincia;
                asesor_editar.ProvinciaDos = entidad.ProvinciaDos;
                asesor_editar.Correo = entidad.Correo;
                asesor_editar.EsActivo = entidad.EsActivo;
                asesor_editar.FechaBaja = entidad.FechaBaja;
                asesor_editar.FechaAlta = entidad.FechaAlta;
                asesor_editar.Cargo = entidad.Cargo;
                asesor_editar.Banco = entidad.Banco;
                asesor_editar.TipoCuenta = entidad.TipoCuenta;
                asesor_editar.CbuCvu = entidad.CbuCvu;
                asesor_editar.NumCta= entidad.NumCta;
                asesor_editar.AliasCbu= entidad.AliasCbu;
                asesor_editar.Legajos= entidad.Legajos;
                asesor_editar.Observaciones = entidad.Observaciones;
                asesor_editar.Telefono = entidad.Telefono;
                asesor_editar.Domicilio= entidad.Domicilio;
                asesor_editar.Contrato=entidad.Contrato;
                asesor_editar.ExentoComision = entidad.ExentoComision;
                asesor_editar.ExentoDescuento = entidad.ExentoDescuento;
                asesor_editar.Sexo= entidad.Sexo;
                asesor_editar.Jefe= entidad.Jefe;

                bool respuesta = await _repoDotacion.Editar(asesor_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo modificar el asesor");

                return asesor_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idDotacion)
        {
            try
            {
                Dotacion Dot_encontrado = await _repoDotacion.Obtener(u => u.IdDotacion == idDotacion);

                if (Dot_encontrado == null)
                    throw new TaskCanceledException("El asesor no existe");

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Dotacion>> Lista()
        {
            IQueryable<Dotacion> query = await _repoDotacion.Consultar();
            return query.ToList();
        }
        
        //public async Task<List<Dotacion>> obtenerPorActivos()
        //{
        //    string ACTIVO = "ACTIVO";
        //    IQueryable<Dotacion> query = await _repoDotacion.Obtener(rep => rep.EsActivo == ACTIVO);
        //    return query.ToList();
        //}
    }
}
