using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.Models
{
    public partial class GuardiansContext : DbContext
    {
        public GuardiansContext()
        {
        }

        public GuardiansContext(DbContextOptions<GuardiansContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Enfrentamiento> Enfrentamientos { get; set; } = null!;
        public virtual DbSet<Heroe> Heroes { get; set; } = null!;
        public virtual DbSet<Patrocina> Patrocinas { get; set; } = null!;
        public virtual DbSet<Patrocinador> Patrocinadors { get; set; } = null!;
        public virtual DbSet<Relacione> Relaciones { get; set; } = null!;
        public virtual DbSet<Villano> Villanos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IB90627\\SQLEXPRESS; DataBase=Guardians;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enfrentamiento>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__enfrenta__B803EB1161965693");

                entity.ToTable("enfrentamientos");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_registro");

                entity.Property(e => e.IdHero).HasColumnName("Id_hero");

                entity.Property(e => e.IdVillain).HasColumnName("Id_villain");

                entity.Property(e => e.Resultado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("resultado");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Enfrentamientos)
                    .HasForeignKey(d => d.IdHero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfrentam__Id_he__3F466844");

                entity.HasOne(d => d.IdVillainNavigation)
                    .WithMany(p => p.Enfrentamientos)
                    .HasForeignKey(d => d.IdVillain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfrentam__Id_vi__403A8C7D");
            });

            modelBuilder.Entity<Heroe>(entity =>
            {
                entity.HasKey(e => e.IdHero)
                    .HasName("PK__HEROE__81DF444D44B1441E");

                entity.ToTable("HEROE");

                entity.Property(e => e.IdHero).HasColumnName("Id_hero");

                entity.Property(e => e.Debilidades)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Disponibilidad)
                    .HasColumnType("date")
                    .HasColumnName("disponibilidad");

                entity.Property(e => e.HabilidadesPoderes)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Habilidades_Poderes");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Completo");
            });

            modelBuilder.Entity<Patrocina>(entity =>
            {
                entity.HasKey(e => e.IdPatrocinio)
                    .HasName("PK__Patrocin__BED3D14CC7EAB8AA");

                entity.ToTable("Patrocina");

                entity.Property(e => e.IdPatrocinio).HasColumnName("Id_patrocinio");

                entity.Property(e => e.IdHero).HasColumnName("id_hero");

                entity.Property(e => e.IdPatrocinador).HasColumnName("Id_patrocinador");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Patrocinas)
                    .HasForeignKey(d => d.IdHero)
                    .HasConstraintName("FK__Patrocina__id_he__656C112C");

                entity.HasOne(d => d.IdPatrocinadorNavigation)
                    .WithMany(p => p.Patrocinas)
                    .HasForeignKey(d => d.IdPatrocinador)
                    .HasConstraintName("FK__Patrocina__Id_pa__66603565");
            });

            modelBuilder.Entity<Patrocinador>(entity =>
            {
                entity.HasKey(e => e.IdPatrocinador)
                    .HasName("PK__Patrocin__16A94644C490EB6D");

                entity.ToTable("Patrocinador");

                entity.Property(e => e.IdPatrocinador).HasColumnName("Id_patrocinador");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.OrigenDinero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("origen_dinero");
            });

            modelBuilder.Entity<Relacione>(entity =>
            {
                entity.HasKey(e => e.IdRelacion)
                    .HasName("PK__Relacion__51F3AF4C5AF205E0");

                entity.Property(e => e.IdRelacion).HasColumnName("id_relacion");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contacto");

                entity.Property(e => e.IdHero).HasColumnName("id_hero");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Relaciones)
                    .HasForeignKey(d => d.IdHero)
                    .HasConstraintName("FK__Relacione__id_he__693CA210");
            });

            modelBuilder.Entity<Villano>(entity =>
            {
                entity.HasKey(e => e.IdVillain)
                    .HasName("PK__villano__CCE5B2E64FCFE50D");

                entity.ToTable("villano");

                entity.Property(e => e.IdVillain).HasColumnName("Id_villain");

                entity.Property(e => e.Debilidades)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HabilidadesPoderes)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Habilidades_Poderes");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Completo");

                entity.Property(e => e.Origen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("origen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
