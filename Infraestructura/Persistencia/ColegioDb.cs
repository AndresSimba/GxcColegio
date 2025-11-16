using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;




namespace Infraestructura.Persistencia
{
    public class ColegioDb : DbContext
    {
        public ColegioDb(DbContextOptions<ColegioDb> options) : base(options) { }

        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colegio>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            modelBuilder.Entity<Materia>()
                .HasIndex(m => m.Nombre)
                .IsUnique();

            // Materia → Colegio
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Colegio)
                .WithMany(c => c.Materias)
                .HasForeignKey(m => m.IdColegio)
                .OnDelete(DeleteBehavior.Restrict);

            // Calificaciones → Colegio
            modelBuilder.Entity<Calificaciones>()
                .HasOne(c => c.Colegio)
                .WithMany(cg => cg.Calificaciones)
                .HasForeignKey(c => c.IdColegio)
                .OnDelete(DeleteBehavior.Restrict);

            // Calificaciones → Materia
            modelBuilder.Entity<Calificaciones>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Calificaciones)
                .HasForeignKey(c => c.IdMateria)
                .OnDelete(DeleteBehavior.Restrict);

            // Calificaciones → Usuario
            modelBuilder.Entity<Calificaciones>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Calificaciones)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
