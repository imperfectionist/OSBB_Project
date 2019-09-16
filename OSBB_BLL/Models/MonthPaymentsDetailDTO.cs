using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class MonthPaymentsDetailDTO
    {
        public int MonthPaymentsDetailId { get; set; }

        public int MonthPaymentsId { get; set; }

        public int UtilityId { get; set; }

        public string UtilityName { get; set; }

        public int? MeterIndexStart { get; set; }

        public int? MeterIndexEnd { get; set; }

        public decimal PaymentSum { get; set; }
    }
}
