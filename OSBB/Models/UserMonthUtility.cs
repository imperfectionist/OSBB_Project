using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class UserMonthUtility
    {
        [Display(Name = "Назва послуги")]
        public string UtilityName { get; set; }

        [Display(Name = "Показник лічильника на початок періоду")]
        public int? MeterIndexStart { get; set; }

        [Display(Name = "Показник лічильника на кінець періоду")]
        public int? MeterIndexEnd { get; set; }

        [Display(Name = "Сума до сплати")]
        public decimal? PaymentSum { get; set; }
    }
}