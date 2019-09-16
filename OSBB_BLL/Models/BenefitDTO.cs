using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class BenefitDTO
    {
        public int BenefitId { get; set; }

        [StringLength(300)]
        [Display(Name = "Категорія")]
        public string BenefitName { get; set; }

        [Display(Name = "Відсоток пільги")]
        [Range(1,100)]
        public int BenefitPercent { get; set; }
    }
}
