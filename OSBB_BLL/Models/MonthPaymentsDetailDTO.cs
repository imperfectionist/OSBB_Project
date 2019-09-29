using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Назва послуги")]
        public string UtilityName { get; set; }
        public decimal? UtilityPrice { get; set; }

        [Display(Name = "Показник лічильника на початок періоду")]
        public int? MeterIndexStart { get; set; }

        [Display(Name = "Показник лічильника на кінець періоду")]
        public int? MeterIndexEnd { get; set; }

        [Display(Name = "Сума до сплати")]
        public decimal PaymentSum { get; set; }
    }
}
