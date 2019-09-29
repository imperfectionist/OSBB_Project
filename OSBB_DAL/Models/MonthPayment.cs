using OSBB_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.Models
{
    public partial class MonthPayment : Entity<int>
    {
        [NotMapped]
        public override int Id
        {
            get { return MonthPaymentsId; }
            set { MonthPaymentsId = value; }
        }
    }
}
