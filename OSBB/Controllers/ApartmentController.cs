using OSBB_BLL.Models;
using OSBB_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OSBB.Models;

namespace OSBB.Controllers
{
    [Authorize(Roles = "OSBB_Admin")]
    public class ApartmentController : Controller
    {
        IGenericService<ApartmentDTO> apartmentService;
        IGenericService<BenefitDTO> benefitService;
        IGenericService<MonthPaymentDTO> paymentService;
        IGenericService<MonthPaymentsDetailDTO> paymentDetailService;
        IGenericService<UtilityDTO> utilityService;
        IEnumerable<AdminApartmentModel> viewApartment;

        public ApartmentController(IGenericService<ApartmentDTO> apartmentService, IGenericService<BenefitDTO> benefitService, 
            IGenericService<MonthPaymentDTO> paymentService, IGenericService<MonthPaymentsDetailDTO> paymentDetailService, IGenericService<UtilityDTO> utilityService)
        {
            this.apartmentService = apartmentService;
            this.benefitService = benefitService;
            this.paymentService = paymentService;
            this.paymentDetailService = paymentDetailService;
            this.utilityService = utilityService;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            TempData["ApartmentId"] = null;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NumSortParam = String.IsNullOrEmpty(sortOrder) ? "num_desc" : "";
            ViewBag.OwnerSortParam = sortOrder == "Owner" ? "owner_desc" : "Owner";
            ViewBag.UsernameSortParam = sortOrder == "Username" ? "username_desc" : "Username";
            ViewBag.CurrentUtilSortParam = sortOrder == "CurrentUtil" ? "currentUtil_desc" : "CurrentUtil";

            if(searchString != null)
            {
                page = 1; 
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            viewApartment = new List<AdminApartmentModel>(apartmentService.GetAll().Select(a =>
            new AdminApartmentModel
            {
                ApartmentId = a.ApartmentId,
                ApartmentNumber = a.ApartmentNumber,
                OwnerName = a.OwnerName,
                Username = a.Username,
                HasCurrentUtil = paymentService.FindBy(p => p.ApartmentId == a.ApartmentId).Any(p => p.IsCurrent == 1)
            }));

            if (!String.IsNullOrEmpty(searchString))
            {
                viewApartment = viewApartment.Where(a => a.OwnerName.ToUpper().Contains(searchString.ToUpper())
                                            || a.ApartmentNumber.ToString().Equals(searchString));
            }

            switch(sortOrder)
            {
                case "num_desc":
                    viewApartment = viewApartment.OrderByDescending(a => a.ApartmentNumber);
                    break;
                case "Owner":
                    viewApartment = viewApartment.OrderBy(a => a.OwnerName);
                    break;
                case "owner_desc":
                    viewApartment = viewApartment.OrderByDescending(a => a.OwnerName);
                    break;
                case "Username":
                    viewApartment = viewApartment.OrderBy(a => a.Username);
                    break;
                case "username_desc":
                    viewApartment = viewApartment.OrderByDescending(a => a.Username);
                    break;
                case "CurrentUtil":
                    viewApartment = viewApartment.OrderBy(a => a.HasCurrentUtil);
                    break;
                case "currentUtil_desc":
                    viewApartment = viewApartment.OrderByDescending(a => a.HasCurrentUtil);
                    break;
                default:
                    viewApartment = viewApartment.OrderBy(a => a.ApartmentNumber);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            return View(viewApartment.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            ApartmentDTO apartment = (id == 0) ? new ApartmentDTO() : apartmentService.Get(id);
            ViewBag.Benefits = new SelectList(benefitService.GetAll().Select(b => new SelectListItem { Value = b.BenefitId.ToString(), Text = b.BenefitName }), "Value", "Text",
                new SelectListItem { Value = apartment.BenefitId.ToString(), Text = apartment.BenefitName });
            return View(apartment);
        }

        [HttpPost]
        public ActionResult Edit (ApartmentDTO apartment)
        {
            if (ModelState.IsValid)
            {
                apartmentService.AddOrUpdate(apartment);
                return RedirectToAction("Index");
            }
            return View(apartment);
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            try
            {
                ApartmentDTO apartment = apartmentService.Get(id);
                apartmentService.Delete(apartment);
                return Json("OK");
            }
            catch { return Json("Error"); }
        }

        [HttpGet]
        public ActionResult Details (int id)
        {
            return View(apartmentService.Get(id));
        }

        [HttpPost]
        public ActionResult ChangeMonth()
        {
            try
            {
                List<MonthPaymentDTO> apartments = paymentService.GetAll().Where(p => p.IsCurrent == 1).ToList();
                for(int i = 0; i < apartments.Count(); i++)
                {
                    apartments[i].IsCurrent = 0;
                    paymentService.AddOrUpdate(apartments[i]);
                }
                return Json("OK");
            }
            catch
            {
                return Json("Error");
            }

        }

        [HttpGet]
        public ActionResult CurrentUtil(int id)
        {
            TempData["ApartmentId"] = id;
            int curMonthId = paymentService.FindBy(p => p.ApartmentId == id).FirstOrDefault(p => p.IsCurrent == 1).MonthPaymentsId;
            ViewBag.Apartment = apartmentService.FindBy(ap => ap.ApartmentId == id).FirstOrDefault().ApartmentNumber;
            List<MonthPaymentsDetailDTO> payments = paymentDetailService.FindBy(d => d.MonthPaymentsId == curMonthId).ToList();

            return View(payments);
        }

        [HttpGet]
        public ActionResult AddRemoveUtilities (string action)
        {
            List<UtilityCheckListModel> checklist = new List<UtilityCheckListModel>();
            IEnumerable<UtilityDTO> utilities = utilityService.GetAll();
            ViewBag.Action = action;

            if(action == "add_all" || action == "del_all")
            {
                foreach (var util in utilities)
                {
                    if (util.UnitId == null)
                    {
                        checklist.Add(new UtilityCheckListModel
                        {
                            UtilityId = util.UtilityId,
                            UtilityName = util.UtilityName,
                            UtilityPrice = util.UtilityPrice,
                            IsChecked = false
                        });
                    }
                }

                return PartialView(checklist);
            }

            int apartmentId = (int)TempData["ApartmentId"];
            MonthPaymentDTO curMonth = paymentService.FindBy(p => p.ApartmentId == apartmentId).FirstOrDefault(p => p.IsCurrent == 1);
            IEnumerable<MonthPaymentsDetailDTO> curUtilities = paymentDetailService.FindBy(u => u.MonthPaymentsId == curMonth.MonthPaymentsId);

            if (action == "add")
            {
                foreach (var util in utilities)
                {
                    if (curUtilities.Any(u => u.UtilityId == util.UtilityId))
                        continue;
                    else
                    {
                        checklist.Add(new UtilityCheckListModel
                        {
                            UtilityId = util.UtilityId,
                            UtilityName = (util.UnitId == null) ? util.UtilityName : util.UtilityName + " (" + util.UnitName + ")",
                            UtilityPrice = util.UtilityPrice,
                            IsChecked = false
                        });
                    }
                }
            }
            else if (action == "del")
            {
                foreach (var util in utilities)
                {
                    if (curUtilities.Any(u => u.UtilityId == util.UtilityId))
                    {
                        checklist.Add(new UtilityCheckListModel
                        {
                            UtilityId = util.UtilityId,
                            UtilityName = (util.UnitId == null) ? util.UtilityName : util.UtilityName + " (" + util.UnitName + ")",
                            UtilityPrice = util.UtilityPrice,
                            IsChecked = false
                        });
                    }
                }
            }

            TempData["ApartmentId"] = apartmentId;
            return PartialView(checklist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRemoveUtilities(string action, List<UtilityCheckListModel> checklist)
        {
            if (checklist.Any(util => util.IsChecked) == false)
            {
                return View("Error");
            }

            if(action == "add")
            {
                int apartmentId = (int)TempData["ApartmentId"];
                MonthPaymentDTO curMonth = paymentService.FindBy(p => p.ApartmentId == apartmentId).FirstOrDefault(p => p.IsCurrent == 1);
                int previousMonthNum = GetPreviousMonth(curMonth.MonthPaymentsNum);
                MonthPaymentDTO previousMonth = paymentService.FindBy(m => m.MonthPaymentsNum == previousMonthNum).FirstOrDefault();

                foreach (var util in checklist)
                {
                    if (util.IsChecked)
                    {
                        MonthPaymentsDetailDTO paymentsDetail = paymentDetailService.AddOrUpdate(new MonthPaymentsDetailDTO
                        {
                            MonthPaymentsId = curMonth.MonthPaymentsId,
                            UtilityId = util.UtilityId,
                            MeterIndexStart = (utilityService.Get(util.UtilityId).UnitId == null) ? null : CheckPreviousMonthMeter(previousMonth.MonthPaymentsId, util.UtilityId),
                            PaymentSum = (utilityService.Get(util.UtilityId).UnitId == null) ? util.UtilityPrice : 0
                        });
                    }
                }

                return RedirectToAction("CurrentUtil", new { id = apartmentId });
            }
            else if(action == "del")
            {
                int apartmentId = (int)TempData["ApartmentId"];
                MonthPaymentDTO curMonth = paymentService.FindBy(p => p.ApartmentId == apartmentId).First(p => p.IsCurrent == 1);

                foreach (var util in checklist)
                {
                    if (util.IsChecked)
                    {
                        MonthPaymentsDetailDTO paymentsDetail = paymentDetailService.FindBy(d => d.MonthPaymentsId == curMonth.MonthPaymentsId).FirstOrDefault(d => d.UtilityId == util.UtilityId);
                        paymentDetailService.Delete(paymentsDetail);
                    }
                }

                if(paymentDetailService.FindBy(d => d.MonthPaymentsId == curMonth.MonthPaymentsId).Any() == false)
                {
                    paymentService.Delete(curMonth);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("CurrentUtil", new { id = apartmentId });
            }
            else if(action == "add_all")
            {
                List<ApartmentDTO> apartments = apartmentService.GetAll().ToList();
                List<MonthPaymentDTO> payments = paymentService.FindBy(p => p.IsCurrent == 1).ToList();

                foreach(var apartment in apartments)
                {
                    if (payments.Any(p => p.ApartmentId == apartment.ApartmentId) == false)
                    {
                        paymentService.AddOrUpdate(new MonthPaymentDTO
                        {
                            ApartmentId = apartment.ApartmentId,
                            MonthPaymentsNum = GetPreviousMonth(DateTime.Now.Month),
                            IsCurrent = 1
                        });
                    }

                    MonthPaymentDTO curMonth = paymentService.FindBy(p => p.ApartmentId == apartment.ApartmentId).First(m => m.IsCurrent == 1);

                    foreach(var util in checklist)
                    {
                        if (paymentDetailService.FindBy(p => p.MonthPaymentsId == curMonth.MonthPaymentsId).Any(u => u.UtilityId == util.UtilityId))
                            continue;

                        paymentDetailService.AddOrUpdate(new MonthPaymentsDetailDTO
                        {
                            MonthPaymentsId = curMonth.MonthPaymentsId,
                            UtilityId = util.UtilityId,
                            PaymentSum = util.UtilityPrice
                        });
                    }
                }

                return RedirectToAction("Index");
            }
            else if (action == "del_all")
            {
                List<ApartmentDTO> apartments = apartmentService.GetAll().ToList();
                List<MonthPaymentDTO> payments = paymentService.FindBy(p => p.IsCurrent == 1).ToList();

                foreach (var apartment in apartments)
                {
                    if (payments.Any(p => p.ApartmentId == apartment.ApartmentId) == true)
                    {
                        MonthPaymentDTO curMonth = paymentService.FindBy(p => p.ApartmentId == apartment.ApartmentId).First(m => m.IsCurrent == 1);

                        foreach (var util in checklist)
                        {
                            if (paymentDetailService.FindBy(p => p.MonthPaymentsId == curMonth.MonthPaymentsId).Any(u => u.UtilityId == util.UtilityId))
                            {
                                paymentDetailService.Delete(paymentDetailService.FindBy(p => p.MonthPaymentsId == curMonth.MonthPaymentsId).First(u => u.UtilityId == util.UtilityId));

                                if (paymentDetailService.FindBy(d => d.MonthPaymentsId == curMonth.MonthPaymentsId).Any() == false)
                                {
                                    paymentService.Delete(curMonth);
                                }
                            }
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            return View();
        }


        private int? CheckPreviousMonthMeter(int monthPaymentsId, int utilityId)
        {
            MonthPaymentsDetailDTO previousUtilityDetail = paymentDetailService.FindBy(p => p.MonthPaymentsId == monthPaymentsId).FirstOrDefault(u => u.UtilityId == utilityId);

            if (previousUtilityDetail != null && previousUtilityDetail.MeterIndexEnd != null)
                return previousUtilityDetail.MeterIndexEnd;

            return 0;
        }

        private int GetPreviousMonth(int month)
        {
            if (month == 1)
                return 12;
            else
                return month - 1;
        }
    }
}