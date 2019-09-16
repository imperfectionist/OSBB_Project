using OSBB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.Repositories.CustomRepository
{
    public class MonthPaymentRepository : GenericRepository<MonthPayment>
    {
        public MonthPaymentRepository(DbContext context) : base(context)
        {
        }
    }
}
