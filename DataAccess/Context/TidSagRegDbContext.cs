using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Mappers;
using DataAccess.Model;
using DataAccess.Repositories;
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
            // Laptop
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-ANE2D06V\\SQLEXPRESS;Initial Catalog=TidSagOgRegDB;Integrated Security=SSPI;TrustServerCertificate=true");
            
            // Desktop
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JJOHN\\SQLEXPRESS;Initial Catalog=TidSagOgRegDB;Integrated Security=SSPI;TrustServerCertificate=true");

            optionsBuilder.LogTo(message  => Debug.WriteLine(message));
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data for Afdeling
            modelBuilder.Entity<Afdeling>().HasData(
                new Afdeling(-1,"IT"),
                new Afdeling(-2,"HR"),
                new Afdeling(-3,"Finans")
            );

            // Seed data for Medarbejder
            modelBuilder.Entity<Medarbejder>().HasData(
                new Medarbejder(1234567890, "AA", "Alice Andersen", -1) { Id = -1 },
                new Medarbejder(2345678901, "BB", "Benny Bentsen", -2) { Id = -2 },
                new Medarbejder(3456789012, "CC", "Carla Christensen", -3) { Id = -3 }
            );

            // Seed data for Sag
            modelBuilder.Entity<Sag>().HasData(
                new Sag("Opgradering af servere", "Opgradering af servere i IT-afdelingen", -1) { Id = -1 },
                new Sag("Rekruttering", "Rekruttering af nye medarbejdere til HR-afdelingen", -2) { Id = -2 },
                new Sag("Budgetplanlægning", "Planlægning af næste års budget for finansafdelingen", -3) { Id = -3 }
            );

            // Seed data for Tidsregistrering
            modelBuilder.Entity<Tidsregistrering>().HasData(
                new Tidsregistrering(-1, -1, DateTime.Now, DateTime.Now.AddHours(9)) { Id = -1 },
                new Tidsregistrering(-2, -2, DateTime.Now, DateTime.Now.AddHours(5)) { Id = -2 },
                new Tidsregistrering(-3, -3, DateTime.Now, DateTime.Now.AddHours(2)) { Id = -3 }
            );
        }


        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Afdeling> Afdelinger { get; set; }
        public DbSet<Sag> Sager { get; set; }
        public DbSet<Tidsregistrering> Tidsregistreringer { get; set; }
    }
}
