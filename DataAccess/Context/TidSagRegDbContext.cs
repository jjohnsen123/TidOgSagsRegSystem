using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    internal class TidSagRegDbContext : DbContext
    {
        public TidSagRegDbContext()
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-ANE2D06V\\SQLEXPRESS;Initial Catalog=TidSagOgRegDB;Integrated Security=SSPI;TrustServerCertificate=true");
            optionsBuilder.LogTo(message  => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afdeling>()
                .HasKey(a => a.AfdNr);

            modelBuilder.Entity<Afdeling>()
                .HasData(new Afdeling[]
                {
                    new Afdeling(1, "Test Afd1"),
                    new Afdeling(2, "Afslapnings afdeling"),
                    new Afdeling(3, "Hallo det her virker")
                });

            modelBuilder.Entity<Medarbejder>()
                .HasKey(m => m.Initialer);

            modelBuilder.Entity<Sag>()
                .HasKey(s => s.SagsNr);

            modelBuilder.Entity<Tidsregistrering>()
                .HasKey(t => t.TidregId);

            modelBuilder.Entity<Medarbejder>()
                .HasMany(m => m.TidsregList)
                .WithOne(t => t.Medarbejder);

            //modelBuilder.Entity<Sag>()
            //    .HasMany(s => s.TidsregList)
            //    .WithOne(t => t.Sag)
            //    .IsRequired(false);

            //modelBuilder.Entity<Afdeling>()
            //    .HasMany(a => a.MedarbList)
            //    .WithOne(m => m.Afdeling);
        }


        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Afdeling> Afdelinger { get; set; }
        public DbSet<Sag> Sager { get; set; }
        public DbSet<Tidsregistrering> Tidsregistreringer { get; set; }
    }
}
