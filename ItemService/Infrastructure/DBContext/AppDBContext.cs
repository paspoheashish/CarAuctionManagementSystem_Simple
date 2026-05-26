using ItemService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ItemService.Infrastructure.DBContext
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual SQL Server connection string
            string connectionString = "Data Source=YAKSH;Initial Catalog=AuctionDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Hatchback> Hatchbacks { get; set; }
        //public DbSet<Sedan> Sedans { get; set; }
        //public DbSet<SUV> SUVs { get; set; }
        //public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Hatchback>().ToTable("Hatchbacks");
            //modelBuilder.Entity<Sedan>().ToTable("Sedans");
            //modelBuilder.Entity<SUV>().ToTable("SUVs");
            //modelBuilder.Entity<Truck>().ToTable("Trucks");

        }
    }
}
