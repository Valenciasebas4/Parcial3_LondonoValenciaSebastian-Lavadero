using Microsoft.EntityFrameworkCore;
using Parcial3_LondonoValenciaSebastian.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial3_LondonoValenciaSebastian.DAL
{
    public class DataBaseContext :DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDetails>()
                .HasOne(vd => vd.Vehicle)
                .WithMany()
                .HasForeignKey(vd => vd.VehicleId);
        }







    }
}
