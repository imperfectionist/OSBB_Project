using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class VerifyCodeModel
    {
        [Required]
        [Display(Name = "Код підтвердження")]
        public string Code { get; set; }

        public string Provider { get; set; }
    }
}