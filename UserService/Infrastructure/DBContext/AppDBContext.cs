using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.DBContext
{
    public class AppDBContext : DbContext
    {
        // The DbSet represents the table
        public DbSet<User> Users { get; set; }

        // Configuring the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual SQL Server connection string
            string connectionString = "Data Source=YAKSH;Initial Catalog=AuctionDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
