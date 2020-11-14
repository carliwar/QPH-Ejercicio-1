using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace QPH.Eval.Ej1.Core.Models
{
    public partial class QPHContext : DbContext
    {
        private readonly string DbConnectionString;
        public virtual DbSet<Libro> Libro { get; set; }

        public QPHContext(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(l => l.LibroId);

                entity.Property(l => l.LibroId)
                .ValueGeneratedNever();

                entity.Property(l => l.Nombre)
                .IsRequired()
                .HasMaxLength(150);

                entity.Property(l => l.Descripcion)
                .IsRequired()
                .HasMaxLength(300);

                entity.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(150);

                entity.Property(l => l.FechaDePublicacion)
                .IsRequired();

                entity.Property(l => l.NumeroDeEjemplares)
                .IsRequired();

                entity.Property(l => l.Costo)
                .IsRequired();
            });
        }
    }
}
