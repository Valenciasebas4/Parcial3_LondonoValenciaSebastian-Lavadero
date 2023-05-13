using Parcial3_LondonoValenciaSebastian.DAL.Entities;

namespace Parcial3_LondonoValenciaSebastian.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();

            await _context.SaveChangesAsync();

        }

        //Metodo para poblar la base de datos 
        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada simple", Price = 25000 });
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada + Aspirada de Cojinería", Price = 30000 });
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada Full", Price = 65000 });
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada en seco del Motor", Price = 80000 });
                _context.Services.Add(new Service { Id = Guid.NewGuid(), Name = "Lavada Chasis", Price = 90000 });
            }
        }
    }
}
