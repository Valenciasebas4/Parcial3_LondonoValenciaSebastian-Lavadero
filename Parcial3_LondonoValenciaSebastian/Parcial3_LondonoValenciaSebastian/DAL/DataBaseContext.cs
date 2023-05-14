using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial3_LondonoValenciaSebastian.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial3_LondonoValenciaSebastian.DAL
{
    public class DataBaseContext : IdentityDbContext<User>
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex("Id", "ServiceId").IsUnique(); // Para estos casos, debo crear un índice Compuesto
            modelBuilder.Entity<VehicleDetails>().HasIndex("Id", "VehicleId").IsUnique(); // Para estos casos, debo crear un índice Compuesto

    

        }







    }
}
