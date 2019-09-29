using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class UtilityCheckListModel
    {
        public int UtilityId { get; set; }
        public string UtilityName { get; set; }
        public bool IsChecked { get; set; }
        public decimal UtilityPrice { get; set; }
    }
}