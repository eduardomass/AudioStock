using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Models
{
    public partial class AudioStockContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<TipoEquipo> TipoEquipos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AudioStockBaseDatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public AudioStockContext()
        {

        }
        public AudioStockContext(DbContextOptions<AudioStockContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasIndex(e => e.MarcaId);

                entity.HasIndex(e => e.TipoEquipoId);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.MarcaId);

                entity.HasOne(d => d.TipoEquipo)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.TipoEquipoId);
            });

            modelBuilder.Entity<TipoEquipo>(entity =>
            {
                entity.Property(e => e.Descripcion).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
