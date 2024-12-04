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
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-ANE2D06V\\SQLEXPRESS;Initial Catalog=TidSagOgRegDB;Integrated Security=SSPI;TrustServerCertificate=true");
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

            modelBuilder.Entity<Medarbejder>()
                .HasKey(m => m.Id);
                
            modelBuilder.Entity<Sag>()
                .HasKey(s => s.SagsNr);

            modelBuilder.Entity<Tidsregistrering>()
                .HasKey(t => t.TidregId);

            modelBuilder.Entity<Medarbejder>()
                .HasMany(m => m.TidsregList)
                .WithOne(t => t.Medarbejder);

            //modelBuilder.Entity<Medarbejder>()
            //    .HasOne(a => a.Afdeling)
            //    .WithOne()
            //    .HasForeignKey("Afdeling");

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
