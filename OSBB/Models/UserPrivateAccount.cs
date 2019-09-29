using OSBB_BLL.Models;
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
        private int _apartmentId { get; set; }
        private int _monthPaymentsId;
        private List<MonthPaymentsDetailDTO> _utilities;
        private SelectList _availableMonths;
        private int _selectedMonth;
        private bool _hasCurrent;
        private int? _currentMonth;
        private bool _hasBenefit;

        public int ApartmentId { get => _apartmentId; set => _apartmentId = value; }
        public int MonthPaymentsId { get => _monthPaymentsId; set => _monthPaymentsId = value; }
        public List<MonthPaymentsDetailDTO> Utilities { get => _utilities; set => _utilities = value; }
        public SelectList AvailableMonths { get => _availableMonths; set => _availableMonths = value; }
        public int SelectedMonth { get => _selectedMonth; set => _selectedMonth = value; }
        public bool HasCurrent { get => _hasCurrent; set => _hasCurrent = value; }
        public int? CurrentMonth { get => _currentMonth; set => _currentMonth = value; }
        public bool HasBenefit { get => _hasBenefit; set => _hasBenefit = value; }

        public UserPrivateAccount()
        {
            _utilities = new List<MonthPaymentsDetailDTO>();
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

        public void CheckPaymentSum (MonthPaymentsDetailDTO payment, decimal discount)
        {
                decimal totalCost = ((decimal)(payment.MeterIndexEnd - payment.MeterIndexStart) - discount) * (decimal)payment.UtilityPrice;
                if (totalCost != payment.PaymentSum && totalCost > 0)
                    payment.PaymentSum = totalCost;
        }


    }
}