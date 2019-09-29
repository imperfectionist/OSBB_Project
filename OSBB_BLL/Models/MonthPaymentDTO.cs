using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class MonthPaymentDTO
    {
        public int MonthPaymentsId { get; set; }

        [Required]
        public int MonthPaymentsNum { get; set; }

        public int ApartmentId { get; set; }

        [Required]
        public int IsCurrent { get; set; }

    }
}
