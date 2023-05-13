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
        // Se mapea la identidad para convertirla en una tabla
        public DbSet<Service> Services { get; set; }

        //Vamos a crear un índice para la tabla Countries
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(c => c.Name).IsUnique();

        }







    }
}
