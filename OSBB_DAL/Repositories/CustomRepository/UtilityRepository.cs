using OSBB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.Repositories.CustomRepository
{
    public class UtilityRepository : GenericRepository<Utility>
    {
        public UtilityRepository(DbContext context) : base(context)
        {
        }
    }
}
