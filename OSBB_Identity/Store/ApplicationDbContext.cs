using Microsoft.AspNet.Identity.EntityFramework;
using OSBB_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_Identity.Store
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, CustomerUserLogin, CustomerUserRole, CustomerUserClaim>
    {
        public ApplicationDbContext() : base()
        {
            if (!Database.Exists())
            {
                System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(new DbInitialize());
            }
        }

        public static ApplicationDbContext Create()
        {
                return new ApplicationDbContext();
        }   
    }
}
