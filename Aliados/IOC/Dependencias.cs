using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Implementacion;
using BLL.Interfaces;
using BLL.Implementacion;

using BLL.InterfacesZoco;
using Entity.Entity;
using DAL.DBContext;
using BLL.ImplemtacionZoco;
using BLL.ImplementacionZoco;
using Entity.Zoco;

namespace IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<zocowebContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUsuarioZocoService, UsuarioZocoService>();
            services.AddScoped<IBaseDashboardService, BaseDashboardService>();
            services.AddScoped<IInflacionService, InflacionService>();
            services.AddScoped<ICalificoComentarioService, CalificoService>();
            services.AddScoped<INotificacionService, NotificacionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITasaInteresService, TasaInteresService>();



            services.AddScoped<IActivacionService, ActivacionService>();
            services.AddScoped<IActividadAfipService, ActividadAfipService>();

            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<ICoordenadaService, CoordenadaService>();
            services.AddScoped<ICorreoService, CorreoService>();

            services.AddScoped<IDecTomadaService, DecTomadaService>();
            services.AddScoped<IDocumentacionService, DocumentacionService>();
            services.AddScoped<IDocVisitaService, DocVisitaService>();
            services.AddScoped<IDotacionService, DotacionService>();

            services.AddScoped<IEstadoAfipService, EstadoAfipService>();
            services.AddScoped<IEstadoMovimientoService, EstadoMovimientoService>();
            services.AddScoped<IEstadoPlantillaService, EstadoPlantillaService>();
            services.AddScoped<IEstadoRentasService, EstadoRentasService>();
            services.AddScoped<IEstadoVisitaService, EstadoVisitaService>();

            services.AddScoped<IFantasiaComercioService, FantasiaComercioService>();
            services.AddScoped<IFireBaseService, FireBaseService>();


            services.AddScoped<IHistCorreoAliadoService, HistCorreoAliadoService>();
            services.AddScoped<IHistCorreoDotacionService, HistCorreoDotacionService>();
            services.AddScoped<IHistCorreoNosService, HistCorreoNosService>();

            services.AddScoped<ILocalidadService, LocalidadService>();
            services.AddScoped<ILogsService, LogsNosotroService>();
            services.AddScoped<ILoggAliadosService, LoggAliadosService>();
            services.AddScoped<ILoggDotacionService, LoggDotacionService>();

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMovimientoTermService, MovimientoTermService>();

            services.AddScoped<INoticiasDotService, NoticiasDotService>();
            services.AddScoped<INoticiaAliService, NoticiaAliService>();

            services.AddScoped<IPlantillaAltaFisicaService, PlantillaAltaFisicaService>();
            services.AddScoped<IPlantillaAltaJurService, PlantillaAltaJurService>();
            services.AddScoped<IPlantillaBajaService, PlantillaBajaService>();
            services.AddScoped<IPlantillaModService, PlantillaModService>();
            services.AddScoped<IProspectoService, ProspectoService>();
            services.AddScoped<IProvinciaService, ProvinciaService>();

            services.AddScoped<IRazonSocialService, RazonSocialService>();
            services.AddScoped<IRegSessionesAliadoService, RegSessionesAliadoService>();
            services.AddScoped<IRegSessionesDotacionService, RegSessionesDotacionService>();
            services.AddScoped<IRegSessionesNosService, RegSessionesNosService>();
            services.AddScoped<IRespNoticiasDotService, RespNoticiasDotService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IRubroService, RubroService>();

            services.AddScoped<ISASService, SASService>();

            services.AddScoped<ITerminalService, TerminalesService>();
            services.AddScoped<ITipoDeAltaService, TipoDeAltaService>();

            services.AddScoped<IUsuarioDotacionService, UsuarioDotacionService>();
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<IUsuarioNosService, UsuarioNosService>();

            services.AddScoped<IUtilidadesService, UtilidadesService>();
            services.AddScoped<IVisitaService, VisitaService>();
        }
    }
}
