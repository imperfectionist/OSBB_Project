using OSBB_Identity.Manager;
using OSBB_Identity.Models;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OSBB_Identity.Store
{
    public class DbInitialize : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        private async Task SeedAsync(ApplicationDbContext context)
        {
            if(!context.Roles.Any(r => r.Name == "OSBB_Admin"))
            {
                var store = new CustomerRoleStore(context);
                var manager = new ApplicationRoleManager(store);
                var role = new AppRole { Name = "OSBB_Admin" };

                await manager.CreateAsync(role);
            }

            if (!context.Roles.Any(r => r.Name == "OSBB_User"))
            {
                var store = new CustomerRoleStore(context);
                var manager = new ApplicationRoleManager(store);
                var role = new AppRole { Name = "OSBB_User" };

                await manager.CreateAsync(role);
            }

            if (!context.Users.Any(u => u.UserName == "berkutplus.osbb@gmail.com"))
            {
                var store = new CustomerUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    UserName = "berkutplus.osbb@gmail.com",
                    Email = "berkutplus.osbb@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+380974141759",
                    PhoneNumberConfirmed = true,
                    ApartmentNumber = 0
                };

                await manager.CreateAsync(user, "pa$$w0rd");
                await manager.AddToRoleAsync(user.Id, "OSBB_Admin");
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Name, "Admin"));
            }

            if (!context.Users.Any(u => u.UserName == "test@ukr.net"))
            {
                var store = new CustomerUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    UserName = "lenasmiyan@rambler.ru",
                    Email = "lenasmiyan@rambler.ru",
                    EmailConfirmed = true,
                    PhoneNumber = "+380974141759",
                    PhoneNumberConfirmed = true,
                    ApartmentNumber = 1000
                };

                await manager.CreateAsync(user, "1qazwsx");
                await manager.AddToRoleAsync(user.Id, "OSBB_User");
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Name, "User"));
            }
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Task.Run(async () =>
            {
                await SeedAsync(context);
            }).Wait();

            base.Seed(context);
        }
    }
}