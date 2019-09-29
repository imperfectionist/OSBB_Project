using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_Identity.Models
{
    public class AppRole : IdentityRole<int, CustomerUserRole>
    {
        public AppRole()
        {

        }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}
