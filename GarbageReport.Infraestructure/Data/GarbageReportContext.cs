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

        public virtual DbSet<Denuncia> Denuncias { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GarbageReport.mssql.somee.com;Initial Catalog=GarbageReport;Persist Security Info=False;User ID=Brandon218_SQLLogin_2;Password=xd1tuyof7x");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ColoniadelEvento)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.DescripciondeSituacion)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.FechadeDenuncia).HasColumnType("date");

                entity.Property(e => e.FotografiadelLugar)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.IdDenuncia).ValueGeneratedOnAdd();

                entity.Property(e => e.MotivodeDenuncia)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.UbicaciondeDenuncia)
                    .HasMaxLength(600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEventos)
                    .HasName("PK__Eventos__E1DD9410B1E6F145");

                entity.Property(e => e.CaracteristicasdelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.ConsideracionesEspeciales)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.DescripciondelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.FechadelEvento).HasColumnType("datetime");

                entity.Property(e => e.NdpersonasRequeridas).HasColumnName("NDPersonasRequeridas");

                entity.Property(e => e.NombredelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.Patrocinadores)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.UbicaciondelEvento)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.HasKey(e => e.IdPois)
                    .HasName("PK__POIS__F8DD6C322523C378");

                entity.ToTable("Poi");

                entity.Property(e => e.Caracteristicas)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
