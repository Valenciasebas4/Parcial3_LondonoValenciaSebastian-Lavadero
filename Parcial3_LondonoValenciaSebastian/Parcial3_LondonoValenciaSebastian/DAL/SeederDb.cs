using Parcial3_LondonoValenciaSebastian.DAL.Entities;
using Parcial3_LondonoValenciaSebastian.Enum;
using Parcial3_LondonoValenciaSebastian.Helpers;
using Parcial3_LondonoValenciaSebastian.Services;

namespace Parcial3_LondonoValenciaSebastian.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        private readonly   IUserHelper _userHelper;

        public SeederDb(DataBaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("Steve", "Jobs", "steve_jobs_admin@yopmail.com", "3002323232", "Street Apple", "102030", "SteveJobs.png", UserType.Admin);
            await PopulateUserAsync("Bill", "Gates", "bill_gates_user@yopmail.com", "4005656656", "Street Microsoft", "405060", "BillGates.png", UserType.User);

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

        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.User.ToString());
        }
    }
}
