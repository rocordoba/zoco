using System;
using System.Collections.Generic;

using Entity.Zoco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DBContext
{
    public partial class zocowebContext : DbContext
    {
        public zocowebContext()
        {
        }

        public zocowebContext(DbContextOptions<zocowebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseCuota> BaseCuotas { get; set; } = null!;
        public virtual DbSet<BaseDashboard> BaseDashboards { get; set; } = null!;
        public virtual DbSet<Califico> Calificos { get; set; } = null!;
        public virtual DbSet<CalificoCom> CalificoComs { get; set; } = null!;
        public virtual DbSet<CompMensual> CompMensuals { get; set; } = null!;
        public virtual DbSet<Inflacion> Inflacions { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Noticia> Noticias { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<RolMenu> RolMenus { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioNo> UsuarioNos { get; set; } = null!;

        public virtual DbSet<Token> Tokens { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("tokens");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.Token1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            });

            modelBuilder.Entity<BaseCuota>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("base_cuotas");

                entity.Property(e => e.AñoPago).HasColumnName("Año_Pago");

                entity.Property(e => e.CodigoPosnet)
                    .HasMaxLength(255)
                    .HasColumnName("codigo posnet");

                entity.Property(e => e.Cuit).HasColumnName("CUIT");

                entity.Property(e => e.MesPago).HasColumnName("Mes_Pago");

                entity.Property(e => e.NombreComercio)
                    .HasMaxLength(255)
                    .HasColumnName("Nombre Comercio");

                entity.Property(e => e.SemanaMesPago).HasColumnName("semana_mes_pago");

                entity.Property(e => e.TotalBruto)
                    .HasColumnType("money")
                    .HasColumnName("total_bruto");
            });

            modelBuilder.Entity<BaseDashboard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("base_dashboard");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.Arancel).HasColumnType("money");

                entity.Property(e => e.AsesorAbm)
                    .HasMaxLength(255)
                    .HasColumnName("Asesor ABM");

                entity.Property(e => e.AñoOp)
                    .HasColumnName("Año_op")
                    .HasComputedColumnSql("(datepart(year,[Fecha Operacion]))", false);

                entity.Property(e => e.AñoPago)
                    .HasColumnName("Año_Pago")
                    .HasComputedColumnSql("(datepart(year,[Fecha de Pago]))", false);

                entity.Property(e => e.Banco).HasMaxLength(255);

                entity.Property(e => e.CbuCvu)
                    .HasMaxLength(255)
                    .HasColumnName("CBU/CVU");

                entity.Property(e => e.CodActividad).HasColumnName("Cod. Actividad");

                entity.Property(e => e.ComercioParticipante)
                    .HasMaxLength(255)
                    .HasColumnName("Comercio Participante");

                entity.Property(e => e.ComisionConIva).HasColumnName("% Comision con IVA");

                entity.Property(e => e.CondicionFiscal)
                    .HasMaxLength(255)
                    .HasColumnName("Condicion Fiscal");

                entity.Property(e => e.CostoFinanciero).HasColumnName("Costo Financiero");

                entity.Property(e => e.CostoFinancieroEn)
                    .HasColumnType("money")
                    .HasColumnName("Costo Financiero en $");

                entity.Property(e => e.CostoPorAnticipo)
                    .HasColumnType("money")
                    .HasColumnName("Costo por anticipo");

                entity.Property(e => e.CuentaBancaria)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta Bancaria");

                entity.Property(e => e.Cuit).HasColumnName("CUIT");

                entity.Property(e => e.DiaSemana)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("dia_semana")
                    .HasComputedColumnSql("(case datename(weekday,[Fecha Operacion]) when 'Sunday' then 'Domingo' when 'Monday' then 'Lunes' when 'Tuesday' then 'Martes' when 'Wednesday' then 'Miércoles' when 'Thursday' then 'Jueves' when 'Friday' then 'Viernes' when 'Saturday' then 'Sábado'  end)", false);

                entity.Property(e => e.EntidadPagadora)
                    .HasMaxLength(255)
                    .HasColumnName("Entidad Pagadora");

                entity.Property(e => e.Estado).HasMaxLength(255);

                entity.Property(e => e.FechaAltaComercio).HasColumnName("Fecha Alta comercio");

                entity.Property(e => e.FechaDePago)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha de Pago");

                entity.Property(e => e.FechaDePresentacion)
                    .HasMaxLength(255)
                    .HasColumnName("Fecha de Presentacion");

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha Operacion");

                entity.Property(e => e.ImpuestoDebitoCredito)
                    .HasColumnType("money")
                    .HasColumnName("IMPUESTO DEBITO/CREDITO");

                entity.Property(e => e.Iva21)
                    .HasColumnType("money")
                    .HasColumnName("IVA 21%");

                entity.Property(e => e.MesOp)
                    .HasColumnName("Mes_op")
                    .HasComputedColumnSql("(datepart(month,[Fecha Operacion]))", false);

                entity.Property(e => e.MesPago)
                    .HasColumnName("Mes_Pago")
                    .HasComputedColumnSql("(datepart(month,[Fecha de Pago]))", false);

                entity.Property(e => e.Moneda).HasMaxLength(255);

                entity.Property(e => e.NombreComercio)
                    .HasMaxLength(255)
                    .HasColumnName("Nombre Comercio");

                entity.Property(e => e.NroDeAutorizacion).HasColumnName("Nro# de Autorizacion");

                entity.Property(e => e.NroDeComercio).HasColumnName("Nro# de Comercio");

                entity.Property(e => e.NroDeCuenta)
                    .HasMaxLength(255)
                    .HasColumnName("Nro de cuenta");

                entity.Property(e => e.NroDeCupon)
                    .HasMaxLength(255)
                    .HasColumnName("Nro# de Cupon");

                entity.Property(e => e.NroDeLote)
                    .HasMaxLength(255)
                    .HasColumnName("Nro# de Lote");

                entity.Property(e => e.NroDeTarjeta).HasColumnName("Nro# de Tarjeta");

                entity.Property(e => e.NroLiquidacion)
                    .HasMaxLength(255)
                    .HasColumnName("Nro# Liquidacion");

                entity.Property(e => e.PromocionPlan)
                    .HasMaxLength(255)
                    .HasColumnName("Promocion Plan");

                entity.Property(e => e.Provincia).HasMaxLength(255);

                entity.Property(e => e.ProvinciaAbm)
                    .HasMaxLength(255)
                    .HasColumnName("Provincia ABM");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(255)
                    .HasColumnName("Razon Social");

                entity.Property(e => e.Retencion)
                    .HasMaxLength(255)
                    .HasColumnName("RETENCION");

                entity.Property(e => e.RetencionGanacia)
                    .HasColumnType("money")
                    .HasColumnName("Retencion Ganacia");

                entity.Property(e => e.RetencionImpositiva)
                    .HasColumnType("money")
                    .HasColumnName("Retencion impositiva");

                entity.Property(e => e.RetencionIva)
                    .HasColumnType("money")
                    .HasColumnName("Retencion IVA");

                entity.Property(e => e.RetencionMunicipal)
                    .HasColumnType("money")
                    .HasColumnName("Retencion Municipal");

                entity.Property(e => e.RetencionProvincial)
                    .HasColumnType("money")
                    .HasColumnName("Retencion Provincial");

                entity.Property(e => e.Rubro).HasMaxLength(255);

                entity.Property(e => e.SemanaMesOp)
                    .HasColumnName("semana_mes_op")
                    .HasComputedColumnSql("((datepart(week,[Fecha Operacion])-datepart(week,dateadd(month,datediff(month,(0),[Fecha Operacion]),(0))))+(1))", false);

                entity.Property(e => e.SemanaMesPago)
                    .HasColumnName("semana_mes_pago")
                    .HasComputedColumnSql("((datepart(week,[Fecha de Pago])-datepart(week,dateadd(month,datediff(month,(0),[Fecha de Pago]),(0))))+(1))", false);

                entity.Property(e => e.Tarjeta).HasMaxLength(255);

                entity.Property(e => e.TarjetaTipo)
                    .HasMaxLength(255)
                    .HasColumnName("Tarjeta-Tipo");

                entity.Property(e => e.TipoDeCredito)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("TIPO DE CREDITO")
                    .HasComputedColumnSql("(case when [Cuotas]=(0) then 'Debito' when [Cuotas]=(1) then '1 Pago' else 'Credito' end)", false);

                entity.Property(e => e.TipoDeCuenta)
                    .HasMaxLength(255)
                    .HasColumnName("Tipo de cuenta");

                entity.Property(e => e.TipoDeFinanciacion)
                    .HasMaxLength(255)
                    .HasColumnName("Tipo de Financiacion");

                entity.Property(e => e.TipoDeLiquidacion)
                    .HasMaxLength(255)
                    .HasColumnName("Tipo de Liquidacion");

                entity.Property(e => e.TipoDeOperacion)
                    .HasMaxLength(255)
                    .HasColumnName("Tipo de Operacion");

                entity.Property(e => e.TipoFinanciacion)
                    .HasMaxLength(255)
                    .HasColumnName("Tipo_Financiacion")
                    .HasComputedColumnSql("(case when [Tipo de Financiacion]='1' then 'Debito' when [Tipo de Financiacion] IS NULL then 'Debito' when [Tipo de Financiacion]='' then 'Debito' when [Tipo de Financiacion]='0' then 'Debito' else [Tipo de Financiacion] end)", false);

                entity.Property(e => e.TotalBruto)
                    .HasColumnType("money")
                    .HasColumnName("Total Bruto");

                entity.Property(e => e.TotalConDescuentos)
                    .HasColumnType("money")
                    .HasColumnName("Total Con descuentos");

                entity.Property(e => e.TotalDescuento)
                    .HasColumnType("money")
                    .HasColumnName("Total Descuento");

                entity.Property(e => e.TotalNeto)
                    .HasColumnType("money")
                    .HasColumnName("Total Neto");
            });

            modelBuilder.Entity<Califico>(entity =>
            {
                entity.ToTable("Califico");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Califico1).HasColumnName("Califico");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Calificos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Califico__Usuari__71D1E811");
            });

            modelBuilder.Entity<CalificoCom>(entity =>
            {
                entity.ToTable("CalificoCom");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CalificoComs)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CalificoC__Usuar__74AE54BC");
            });

            modelBuilder.Entity<CompMensual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("comp_mensual");

                entity.Property(e => e.AñoPago).HasColumnName("Año_Pago");

                entity.Property(e => e.Cuit).HasColumnName("CUIT");

                entity.Property(e => e.Dia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("dia");

                entity.Property(e => e.Mes)
                    .HasMaxLength(30)
                    .HasColumnName("mes");

                entity.Property(e => e.NombreComercio)
                    .HasMaxLength(255)
                    .HasColumnName("Nombre Comercio");

                entity.Property(e => e.TotalBruto)
                    .HasColumnType("money")
                    .HasColumnName("Total Bruto");
            });

            modelBuilder.Entity<Inflacion>(entity =>
            {
                entity.ToTable("Inflacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Inflacion1).HasColumnName("Inflacion");

                entity.Property(e => e.Rubro).HasMaxLength(255);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__Menu__C26AF48392B45677");

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.Controlador)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("controlador");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.Icono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("icono");

                entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");

                entity.Property(e => e.PaginaAccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("paginaAccion");

                entity.HasOne(d => d.IdMenuPadreNavigation)
                    .WithMany(p => p.InverseIdMenuPadreNavigation)
                    .HasForeignKey(d => d.IdMenuPadre)
                    .HasConstraintName("FK__Menu__idMenuPadr__48CFD27E");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.ToTable("noticias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Noticia1).HasColumnName("noticia");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F76F6651E98");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            });

            modelBuilder.Entity<RolMenu>(entity =>
            {
                entity.HasKey(e => e.IdRolMenu)
                    .HasName("PK__RolMenu__CD2045D848E396EB");

                entity.ToTable("RolMenu");

                entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK__RolMenu__idMenu__49C3F6B7");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__RolMenu__idRol__4AB81AF0");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Usuario, "IX_usuarios")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CambioClave)
                    .HasColumnName("cambio_clave")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.TipoUsuario).HasColumnName("tipo_usuario");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<UsuarioNo>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__UsuarioN__645723A62EB1BE84");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CambioClave).HasColumnName("cambio_clave");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puntaje).HasColumnName("puntaje");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuarioNos)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__UsuarioNo__idRol__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
