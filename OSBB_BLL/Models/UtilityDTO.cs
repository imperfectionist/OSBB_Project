using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class UtilityDTO
    {
        public int UtilityId { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Назва послуги")]
        public string UtilityName { get; set; }

        [Display(Name = "Одиниця виміру")]
        public int? UnitId { get; set; }

        [Display(Name = "Одиниця виміру")]
        public string UnitName { get; set; }

        [Display(Name = "Ціна")]
        public decimal UtilityPrice { get; set; }

        [Display(Name = "Норматив на особу")]
        public decimal UtilityNorm { get; set; }
    }
}
