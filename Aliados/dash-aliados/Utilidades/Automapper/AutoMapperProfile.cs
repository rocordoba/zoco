using ZocoAplicacion.Models.ViewModels;

using System.Globalization;
using AutoMapper;

using dash_aliados.Models.ViewModelsZoco;
using Entity.Zoco;

namespace dash_aliados.Utilidades.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Usuarios zoco
            CreateMap<Usuarios, VMUsuariosZoco>()
             .ForMember(destino =>
                 destino.Usuario,
                 opt => opt.MapFrom(origen => origen.Usuario))
             .ForMember(destino =>
                 destino.Password,
                 opt => opt.MapFrom(origen => origen.Password))
             .ForMember(destino =>
                 destino.Nombre,
                 opt => opt.MapFrom(origen => origen.Nombre))
             .ForMember(destino =>
                 destino.TipoUsuario,
                 opt => opt.MapFrom(origen => origen.TipoUsuario))
             .ForMember(destino =>
                 destino.CambioClave,
                 opt => opt.MapFrom(origen => origen.CambioClave))
             .ForMember(destino =>
                 destino.Correo,
                 opt => opt.MapFrom(origen => origen.Correo));

            CreateMap<VMUsuariosZoco, Usuarios>()
                .ForMember(destino =>
                    destino.Usuario,
                    opt => opt.MapFrom(origen => origen.Usuario))
                .ForMember(destino =>
                    destino.Password,
                    opt => opt.MapFrom(origen => origen.Password))
                .ForMember(destino =>
                    destino.Nombre,
                    opt => opt.MapFrom(origen => origen.Nombre))
                .ForMember(destino =>
                    destino.TipoUsuario,
                    opt => opt.MapFrom(origen => origen.TipoUsuario))
                .ForMember(destino =>
                    destino.CambioClave,
                    opt => opt.MapFrom(origen => origen.CambioClave))
                .ForMember(destino =>
                    destino.Correo,
                    opt => opt.MapFrom(origen => origen.Correo));
            #endregion
            #region BaseDashboard
            CreateMap<BaseDashboard, VMBaseDashboard>()
        .ForMember(dest => dest.NroDeComercio, opt => opt.MapFrom(src => src.NroDeComercio.ToString()))
        .ForMember(dest => dest.NroDeTarjeta, opt => opt.MapFrom(src => src.NroDeTarjeta.ToString()))
        .ForMember(dest => dest.TotalBruto, opt => opt.MapFrom(src => src.TotalBruto.ToString()))
        .ForMember(dest => dest.TotalDescuento, opt => opt.MapFrom(src => src.TotalDescuento.ToString()))
        .ForMember(dest => dest.TotalNeto, opt => opt.MapFrom(src => src.TotalNeto.ToString()))
        .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(src => src.Cuotas.ToString()))
        .ForMember(dest => dest.NroDeAutorizacion, opt => opt.MapFrom(src => src.NroDeAutorizacion.ToString()))
        .ForMember(dest => dest.CostoFinanciero, opt => opt.MapFrom(src => src.CostoFinanciero.ToString()))
        .ForMember(dest => dest.CostoFinancieroEn, opt => opt.MapFrom(src => src.CostoFinancieroEn.ToString()))
        .ForMember(dest => dest.CostoPorAnticipo, opt => opt.MapFrom(src => src.CostoPorAnticipo.ToString()))
        .ForMember(dest => dest.ComisionConIva, opt => opt.MapFrom(src => src.ComisionConIva.ToString()))
        .ForMember(dest => dest.Arancel, opt => opt.MapFrom(src => src.Arancel.ToString()))
        .ForMember(dest => dest.Iva21, opt => opt.MapFrom(src => src.Iva21.ToString()))
        .ForMember(dest => dest.ImpuestoDebitoCredito, opt => opt.MapFrom(src => src.ImpuestoDebitoCredito.ToString()))
        .ForMember(dest => dest.Cuit, opt => opt.MapFrom(src => src.Cuit.ToString()))
        .ForMember(dest => dest.RetencionProvincial, opt => opt.MapFrom(src => src.RetencionProvincial.ToString()))
        .ForMember(dest => dest.RetencionGanacia, opt => opt.MapFrom(src => src.RetencionGanacia.ToString()))
        .ForMember(dest => dest.RetencionIva, opt => opt.MapFrom(src => src.RetencionIva.ToString()))
        .ForMember(dest => dest.TotalConDescuentos, opt => opt.MapFrom(src => src.TotalConDescuentos.ToString()))
        .ForMember(dest => dest.RetencionMunicipal, opt => opt.MapFrom(src => src.RetencionMunicipal.ToString()))
        .ForMember(dest => dest.RetencionImpositiva, opt => opt.MapFrom(src => src.RetencionImpositiva.ToString()))
        .ForMember(dest => dest.FechaAltaComercio, opt => opt.MapFrom(src => src.FechaAltaComercio.ToString()))
        .ForMember(dest => dest.Legajo, opt => opt.MapFrom(src => src.Legajo.ToString()))
        .ForMember(dest => dest.CodActividad, opt => opt.MapFrom(src => src.CodActividad.ToString()))
        .ForMember(dest => dest.AñoOp, opt => opt.MapFrom(src => src.AñoOp))
        .ForMember(dest => dest.MesOp, opt => opt.MapFrom(src => src.MesOp))
        .ForMember(dest => dest.AñoPago, opt => opt.MapFrom(src => src.AñoPago))
        .ForMember(dest => dest.MesPago, opt => opt.MapFrom(src => src.MesPago))
        .ForMember(dest => dest.SemanaMesPago, opt => opt.MapFrom(src => src.SemanaMesPago))
        .ForMember(dest => dest.SemanaMesOp, opt => opt.MapFrom(src => src.SemanaMesOp))
        .ForMember(dest => dest.DiaSemana, opt => opt.MapFrom(src => src.DiaSemana))
        .ForMember(dest => dest.TipoDeCredito, opt => opt.MapFrom(src => src.TipoDeCredito))
        .ForMember(dest => dest.TipoFinanciacion, opt => opt.MapFrom(src => src.TipoFinanciacion));

            CreateMap<VMBaseDashboard, BaseDashboard>()
    .ForMember(dest => dest.NroDeComercio, opt => opt.MapFrom(src => int.Parse(src.NroDeComercio)))
    .ForMember(dest => dest.NroDeTarjeta, opt => opt.MapFrom(src => int.Parse(src.NroDeTarjeta)))
    .ForMember(dest => dest.TotalBruto, opt => opt.MapFrom(src => decimal.Parse(src.TotalBruto)))
    .ForMember(dest => dest.TotalDescuento, opt => opt.MapFrom(src => decimal.Parse(src.TotalDescuento)))
    .ForMember(dest => dest.TotalNeto, opt => opt.MapFrom(src => decimal.Parse(src.TotalNeto)))
    .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(src => int.Parse(src.Cuotas)))
    .ForMember(dest => dest.NroDeAutorizacion, opt => opt.MapFrom(src => int.Parse(src.NroDeAutorizacion)))
    .ForMember(dest => dest.CostoFinanciero, opt => opt.MapFrom(src => decimal.Parse(src.CostoFinanciero)))
    .ForMember(dest => dest.CostoFinancieroEn, opt => opt.MapFrom(src => decimal.Parse(src.CostoFinancieroEn)))
    .ForMember(dest => dest.CostoPorAnticipo, opt => opt.MapFrom(src => decimal.Parse(src.CostoPorAnticipo)))
    .ForMember(dest => dest.ComisionConIva, opt => opt.MapFrom(src => decimal.Parse(src.ComisionConIva)))
    .ForMember(dest => dest.Arancel, opt => opt.MapFrom(src => decimal.Parse(src.Arancel)))
    .ForMember(dest => dest.Iva21, opt => opt.MapFrom(src => decimal.Parse(src.Iva21)))
    .ForMember(dest => dest.ImpuestoDebitoCredito, opt => opt.MapFrom(src => decimal.Parse(src.ImpuestoDebitoCredito)))
    .ForMember(dest => dest.Cuit, opt => opt.MapFrom(src => long.Parse(src.Cuit)))
    .ForMember(dest => dest.RetencionProvincial, opt => opt.MapFrom(src => decimal.Parse(src.RetencionProvincial)))
    .ForMember(dest => dest.RetencionGanacia, opt => opt.MapFrom(src => decimal.Parse(src.RetencionGanacia)))
    .ForMember(dest => dest.RetencionIva, opt => opt.MapFrom(src => decimal.Parse(src.RetencionIva)))
    .ForMember(dest => dest.TotalConDescuentos, opt => opt.MapFrom(src => decimal.Parse(src.TotalConDescuentos)))
    .ForMember(dest => dest.RetencionMunicipal, opt => opt.MapFrom(src => decimal.Parse(src.RetencionMunicipal)))
    .ForMember(dest => dest.RetencionImpositiva, opt => opt.MapFrom(src => decimal.Parse(src.RetencionImpositiva)))
    .ForMember(dest => dest.FechaAltaComercio, opt => opt.MapFrom(src => DateTime.Parse(src.FechaAltaComercio)))
    .ForMember(dest => dest.Legajo, opt => opt.MapFrom(src => int.Parse(src.Legajo)))
    .ForMember(dest => dest.CodActividad, opt => opt.MapFrom(src => int.Parse(src.CodActividad)))
    .ForMember(dest => dest.AñoOp, opt => opt.MapFrom(src => src.AñoOp))
    .ForMember(dest => dest.MesOp, opt => opt.MapFrom(src => src.MesOp))
    .ForMember(dest => dest.AñoPago, opt => opt.MapFrom(src => src.AñoPago))
    .ForMember(dest => dest.MesPago, opt => opt.MapFrom(src => src.MesPago))
    .ForMember(dest => dest.SemanaMesPago, opt => opt.MapFrom(src => src.SemanaMesPago))
    .ForMember(dest => dest.SemanaMesOp, opt => opt.MapFrom(src => src.SemanaMesOp))
    .ForMember(dest => dest.DiaSemana, opt => opt.MapFrom(src => src.DiaSemana))
    .ForMember(dest => dest.TipoDeCredito, opt => opt.MapFrom(src => src.TipoDeCredito))
    .ForMember(dest => dest.TipoFinanciacion, opt => opt.MapFrom(src => src.TipoFinanciacion));

            #endregion


        }
    }
}
