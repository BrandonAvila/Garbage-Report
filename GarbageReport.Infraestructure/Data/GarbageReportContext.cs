using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GarbageReport.Domain.Entities;

#nullable disable

namespace GarbageReport.Infraestructure.Data
{
    public partial class GarbageReportContext : DbContext
    {
        public GarbageReportContext()
        {
        }

        public GarbageReportContext(DbContextOptions<GarbageReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudadano> Ciudadania { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ciudadano>(entity =>
            {
                entity.HasKey(e => e.IdCiudadania)
                    .HasName("pk_Ciudadania");

                entity.Property(e => e.IdCiudadania).HasColumnName("idCiudadania");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.IdDenuncia)
                    .HasName("PK_Denuncias");

                entity.Property(e => e.FechadeDenuncia)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.FotografiadelLugar)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.MotivodeDenuncia)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.TitulodeDenuncia)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.UbicaciondeDenuncia)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEventos)
                    .HasName("PK__Eventos");

                entity.ToTable("Evento");

                entity.Property(e => e.ConsideracionesEspeciales)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripciondelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.FechadelEvento)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NdpersonasRequeridas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombredelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.HasKey(e => e.IdPois)
                    .HasName("PK__Pois");

                entity.ToTable("Poi");

                entity.Property(e => e.Caracteristicas)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Hora)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
