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
        IGenericService<UtilityDTO> utilityService;
        IGenericService<BenefitDTO> benefitService;

        public PersonalAccountController(IGenericService<MonthPaymentDTO> paymentService,
        IGenericService<MonthPaymentsDetailDTO> paymentDetailService, IGenericService<ApartmentDTO> apartmentService, 
        IGenericService<UtilityDTO> utilityService, IGenericService<BenefitDTO> benefitService)
        {
            this.paymentService = paymentService;
            this.paymentDetailService = paymentDetailService;
            this.apartmentService = apartmentService;
            this.utilityService = utilityService;
            this.benefitService = benefitService;
            account = new UserPrivateAccount();
        }
        
        [HttpGet]
        public ActionResult Index (int monthId = 0)
        {
            account.ApartmentId = apartmentService.FindBy(ap => ap.Username == User.Identity.Name).FirstOrDefault().ApartmentId;
            ViewBag.ApartmentNumber = apartmentService.Get(account.ApartmentId).ApartmentNumber;
            ViewBag.AccountNumber = apartmentService.Get(account.ApartmentId).AccountNumber;

            account.AvailableMonths = new SelectList(paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).Select(m => new SelectListItem
            {
                Value = m.MonthPaymentsNum.ToString(),
                Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m.MonthPaymentsNum)
            }), "Value", "Text");

            account.SelectedMonth = (monthId == 0) ? GetPreviousMonth(DateTime.Now.Month) : monthId;
            account.HasBenefit = (apartmentService.Get(account.ApartmentId).BenefitId == null) ? false : true;

            if (account.HasBenefit)
            {
                ViewBag.Benefit = benefitService.Get((int)apartmentService.Get(account.ApartmentId).BenefitId).BenefitName;
            }
            
            account.HasCurrent = paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).Any(m => m.IsCurrent == 1);
            if (account.HasCurrent)
            {
                account.CurrentMonth = paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).FirstOrDefault(m => m.IsCurrent == 1).MonthPaymentsNum;
            }

            if (paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).Any(m => m.MonthPaymentsNum == account.SelectedMonth))
            {
                account.MonthPaymentsId = paymentService.FindBy(p => p.ApartmentId == account.ApartmentId).FirstOrDefault(m => m.MonthPaymentsNum == account.SelectedMonth).MonthPaymentsId;
                account.Utilities = paymentDetailService.FindBy(d => d.MonthPaymentsId == account.MonthPaymentsId).ToList();
            }

            Session["account"] = account;

            return View(account);
        }

        [HttpGet]
        public ActionResult AddCurrentUtilities()
        {
            List<UtilityCheckListModel> checklist = new List<UtilityCheckListModel>();
            IEnumerable<UtilityDTO> utilities = utilityService.GetAll().Where(u => u.UnitId != null);

            foreach (var util in utilities)
            {
                checklist.Add(new UtilityCheckListModel
                {
                    UtilityId = util.UtilityId,
                    UtilityName = util.UtilityName + " (" + util.UnitName + ")",
                    UtilityPrice = util.UtilityPrice,
                    IsChecked = false
                });
            }

            return PartialView(checklist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCurrentUtilities(List<UtilityCheckListModel> checklist)
        {
            if(checklist.Any(util => util.IsChecked) == false)
            {
                return RedirectToAction("Index");
            }

            account = (UserPrivateAccount)Session["account"];

            MonthPaymentDTO currentMonth = paymentService.AddOrUpdate(new MonthPaymentDTO
            {
                MonthPaymentsNum = GetPreviousMonth(DateTime.Now.Month),
                ApartmentId = account.ApartmentId,
                IsCurrent = 1
            });

            int previousMonthNum = GetPreviousMonth(currentMonth.MonthPaymentsNum);
            MonthPaymentDTO previousMonth = paymentService.FindBy(m => m.MonthPaymentsNum == previousMonthNum).FirstOrDefault(a => a.ApartmentId == account.ApartmentId);

            if (previousMonth != null)
            {
                foreach (var util in checklist)
                {
                    if (util.IsChecked)
                    {
                        MonthPaymentsDetailDTO paymentsDetail = paymentDetailService.AddOrUpdate(new MonthPaymentsDetailDTO
                        {
                            MonthPaymentsId = currentMonth.MonthPaymentsId,
                            UtilityId = util.UtilityId,
                            MeterIndexStart = CheckPreviousMonthMeter(previousMonth.MonthPaymentsId, util.UtilityId),
                            PaymentSum = 0
                        });
                    }
                }
            }
            else
            {
                foreach (var util in checklist)
                {
                    if (util.IsChecked)
                    {
                        MonthPaymentsDetailDTO paymentsDetail = paymentDetailService.AddOrUpdate(new MonthPaymentsDetailDTO
                        {
                            MonthPaymentsId = currentMonth.MonthPaymentsId,
                            UtilityId = util.UtilityId,
                            MeterIndexStart = 0,
                            PaymentSum = 0
                        });
                    }
                }
            }

            Session["account"] = account;

            return RedirectToAction("Edit", new { id = currentMonth.MonthPaymentsId });
        }

        private int CheckPreviousMonthMeter(int monthPaymentsId, int utilityId)
        {
            MonthPaymentsDetailDTO previousUtilityDetail = paymentDetailService.FindBy(p => p.MonthPaymentsId == monthPaymentsId).FirstOrDefault(u => u.UtilityId == utilityId);

            if (previousUtilityDetail != null && previousUtilityDetail.MeterIndexEnd != null)
                return (int)previousUtilityDetail.MeterIndexEnd;

            return 0;
        }

        private int GetPreviousMonth (int month)
        {
            if (month == 1)
                return 12;
            else
                return month - 1;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MonthPaymentDTO monthPayment = paymentService.Get(id);
            List<MonthPaymentsDetailDTO> paymentDetails = paymentDetailService.FindBy(d => d.MonthPaymentsId == monthPayment.MonthPaymentsId).ToList();
            ViewBag.MonthNum = monthPayment.MonthPaymentsNum;

            return View(paymentDetails);
        }

        [HttpPost]
        public ActionResult Edit(List<MonthPaymentsDetailDTO> payments)
        {
            int month = 0;
            account = (UserPrivateAccount)Session["account"];

            if (ModelState.IsValid)
            {
                foreach (var payment in payments)
                {
                    if(payment.MeterIndexEnd < payment.MeterIndexStart)
                    {
                        ModelState.AddModelError("", "Показник на кінець періоду не може бути меншим за показник на початок!");
                        return View(payments);
                    }

                    decimal discount = 0;

                    if (account.HasBenefit)
                    {
                        int benefit = benefitService.Get((int)apartmentService.Get(account.ApartmentId).BenefitId).BenefitPercent;
                        decimal utilNorm = utilityService.Get(payment.UtilityId).UtilityNorm;
                        discount = (decimal)apartmentService.Get(account.ApartmentId).Tenants * utilNorm * ((decimal)benefit / 100);
                    }

                    account.CheckPaymentSum(payment, discount);
                    paymentDetailService.AddOrUpdate(payment);
                    month = paymentService.FindBy(p => p.MonthPaymentsId == payment.MonthPaymentsId).FirstOrDefault().MonthPaymentsNum;
                }

                return RedirectToAction("Index", new { monthId = month });
            }

            Session["account"] = account;

            return View(payments);
        }

    }
}