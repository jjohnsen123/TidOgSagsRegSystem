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
            modelBuilder.Entity<Afdeling>()
                .HasKey(a => a.AfdelingId);

            //Seed afdelinger
            modelBuilder.Entity<Afdeling>().HasData(
                new Afdeling(-1,"IT"),
                new Afdeling(-2,"HR"),
                new Afdeling(-3,"Finans")
            );

            modelBuilder.Entity<Sag>()
                .HasKey(s => s.SagsNr);
        }


        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Afdeling> Afdelinger { get; set; }
        public DbSet<Sag> Sager { get; set; }
        public DbSet<Tidsregistrering> Tidsregistreringer { get; set; }
    }
}
