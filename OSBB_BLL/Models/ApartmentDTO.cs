using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class ApartmentDTO
    {
        public int ApartmentId { get; set; }

        [Display(Name = "Номер квартири")]
        public int ApartmentNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Номер рахунку")]
        public string AccountNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "ПІБ власника")]
        public string OwnerName { get; set; }

        [StringLength(100)]
        [Display(Name = "Користувач")]
        public string Username { get; set; }

        [Display(Name = "Загальна площа")]
        public decimal TotalSquare { get; set; }

        [Display(Name = "Житлова площа")]
        public decimal LivingSquare { get; set; }

        [Display(Name = "Кількість мешканців")]
        public int? Tenants { get; set; }

        [Display(Name = "Пільга")]
        public int? BenefitId { get; set; }

        [Display(Name = "Пільга")]
        public string BenefitName { get; set; }
    }
}
