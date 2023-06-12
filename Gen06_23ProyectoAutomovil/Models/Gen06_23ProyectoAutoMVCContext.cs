using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Gen06_23ProyectoAutoMVCContext : DbContext
    {
        public Gen06_23ProyectoAutoMVCContext()
        {
        }

        public Gen06_23ProyectoAutoMVCContext(DbContextOptions<Gen06_23ProyectoAutoMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Automovil> Automovils { get; set; }
        public virtual DbSet<CostoAdicional> CostoAdicionals { get; set; }
        public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<EstatusAutomovil> EstatusAutomovils { get; set; }
        public virtual DbSet<EstatusPago> EstatusPagos { get; set; }
        public virtual DbSet<EstatusRentum> EstatusRenta { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Rentum> Renta { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.ToTable("Automovil");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstatusAutomovil)
                    .WithMany(p => p.Automovils)
                    .HasForeignKey(d => d.EstatusAutomovilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Automovil_EstatusAutomovil");
            });

            modelBuilder.Entity<CostoAdicional>(entity =>
            {
                entity.ToTable("CostoAdicional");
            });

            modelBuilder.Entity<DatosPersonale>(entity =>
            {
                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.ToTable("Domicilio");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cp)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CP");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoExterior)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoInterior)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusAutomovil>(entity =>
            {
                entity.ToTable("EstatusAutomovil");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusPago>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusRentum>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.FechaCargo).HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Automovil");

                entity.HasOne(d => d.CostoAdicional)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.CostoAdicionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_CostoAdicional");

                entity.HasOne(d => d.DatosPersonales)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.DatosPersonalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_DatosPersonales");

                entity.HasOne(d => d.EstatusPago)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.EstatusPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_EstatusPagos");

                entity.HasOne(d => d.Perfi)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.PerfiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Perfil");

                entity.HasOne(d => d.TipoPago)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.TipoPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_TipoPago");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rentum>(entity =>
            {
                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_Automovil");

                entity.HasOne(d => d.DatosPersonales)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.DatosPersonalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_DatosPersonales");

                entity.HasOne(d => d.EstatusRenta)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.EstatusRentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_EstatusRenta");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_Perfil");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.ToTable("TipoPago");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DatosPersonales)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DatosPersonalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_DatosPersonales");

                entity.HasOne(d => d.Domicilio)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DomicilioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Domicilio");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Perfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
