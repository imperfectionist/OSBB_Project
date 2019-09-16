using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_BLL.Models
{
    public class UnitDTO
    {
        public int UnitId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Назва")]
        public string UnitName { get; set; }

    }
}
