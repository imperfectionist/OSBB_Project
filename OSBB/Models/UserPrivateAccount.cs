using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSBB.Models
{
    public class UserPrivateAccount
    {
        private List<UserMonthUtility> _utilities;
        private SelectList _availableMonths;
        private int _selectedMonth;
        private int _apartmentId;

        public List<UserMonthUtility> Utilities { get => _utilities; set => _utilities = value; }
        public SelectList AvailableMonths { get => _availableMonths; set => _availableMonths = value; }
        public int SelectedMonth { get => _selectedMonth; set => _selectedMonth = value; }
        public int ApartmentId{ get => _apartmentId; set => _apartmentId = value; }

        public UserPrivateAccount()
        {
            _utilities = new List<UserMonthUtility>();
        }

        [Display(Name = "Загальна сума")]
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach(var u in _utilities)
                {
                    total += (decimal)u.PaymentSum;
                }
                return total;
            }
        }


    }
}