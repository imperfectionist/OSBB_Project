using Microsoft.AspNet.Identity.EntityFramework;
using OSBB_Identity.Models;

namespace OSBB_Identity.Store
{
    public class CustomerRoleStore : RoleStore<AppRole, int, CustomerUserRole>
    {
        public CustomerRoleStore(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}