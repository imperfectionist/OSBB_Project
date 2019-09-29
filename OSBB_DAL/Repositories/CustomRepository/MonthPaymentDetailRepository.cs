using OSBB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.Repositories.CustomRepository
{
    public class MonthPaymentsDetailRepository : GenericRepository<MonthPaymentsDetail>
    {
        public MonthPaymentsDetailRepository(DbContext context) : base(context)
        {
        }
    }
}
