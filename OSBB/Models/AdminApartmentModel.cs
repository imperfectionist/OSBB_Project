using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class AdminApartmentModel
    {
        public int ApartmentId { get; set; }

        [Display(Name = "Номер квартири")]
        public int ApartmentNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "ПІБ власника")]
        public string OwnerName { get; set; }

        [StringLength(100)]
        [Display(Name = "Користувач")]
        public string Username { get; set; }

        public bool HasCurrentUtil { get; set; }
    }
}