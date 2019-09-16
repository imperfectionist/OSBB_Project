using OSBB.Models;
using OSBB_BLL.Models;
using OSBB_BLL.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSBB.Controllers
{
    [Authorize]
    public class PersonalAccountController : Controller
    {
        UserPrivateAccount account;
        IGenericService<MonthPaymentDTO> paymentService;
        IGenericService<MonthPaymentsDetailDTO> paymentDetailService;
        IGenericService<ApartmentDTO> apartmentService;

        public PersonalAccountController(IGenericService<MonthPaymentDTO> paymentService,
        IGenericService<MonthPaymentsDetailDTO> paymentDetailService, IGenericService<ApartmentDTO> apartmentService)
        {
            this.paymentService = paymentService;
            this.paymentDetailService = paymentDetailService;
            this.apartmentService = apartmentService;
            account = new UserPrivateAccount();
        }
        
        [HttpGet]
        public ActionResult Index (int monthId = 0)
        {
            account.ApartmentId = apartmentService.FindBy(ap => ap.Username == User.Identity.Name).FirstOrDefault().ApartmentId;
            ViewBag.ApartmentNumber = apartmentService.FindBy(ap => ap.Username == User.Identity.Name).FirstOrDefault().ApartmentNumber;
            ViewBag.AccountNumber = apartmentService.FindBy(ap => ap.Username == User.Identity.Name).FirstOrDefault().AccountNumber;
            
            account.AvailableMonths = new SelectList(paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).Select(m => new SelectListItem
            {
                Value = m.MonthPaymentsNum.ToString(),
                Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m.MonthPaymentsNum)
            }), "Value", "Text");

            account.SelectedMonth = (monthId == 0) ? DateTime.Now.Month : monthId;

            MonthPaymentDTO monthPayment = paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).FirstOrDefault(m => m.MonthPaymentsNum == account.SelectedMonth);

            IEnumerable<MonthPaymentsDetailDTO> paymentDetails = paymentDetailService.FindBy(d => d.MonthPaymentsId == monthPayment.MonthPaymentsId);
            foreach (var payment in paymentDetails)
            {
                account.Utilities.Add(new UserMonthUtility
                {
                    UtilityName = payment.UtilityName,
                    MeterIndexStart = payment.MeterIndexStart,
                    MeterIndexEnd = payment.MeterIndexEnd,
                    PaymentSum = payment.PaymentSum
                });
            }

            return View(account);
        }
    }
}