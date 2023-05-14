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
            await PopulateUserAsync("Sebastian", "Londoño", "sebas@yopmail.com", "3142393101", "Barbosa", "1035234145", UserType.Admin);
            await PopulateUserAsync("Jessica", "Gomez", "jess@yopmail.com", "3017585232", "Barbosa", "1035232261", UserType.Client);

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


        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string address, string document,UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                 

                user = new User
                {
                    CreatedDate = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,
 
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.User.ToString());
            await _userHelper.AddRoleAsync(UserType.Client.ToString());
        }
    }
}
