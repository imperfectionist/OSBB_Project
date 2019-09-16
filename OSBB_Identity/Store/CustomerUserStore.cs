using Microsoft.AspNet.Identity.EntityFramework;
using OSBB_Identity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_Identity.Store
{
    public class CustomerUserStore : UserStore<AppUser, AppRole, int, CustomerUserLogin, CustomerUserRole, CustomerUserClaim>
    {
        public CustomerUserStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}
