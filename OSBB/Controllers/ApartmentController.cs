using OSBB_BLL.Models;
using OSBB_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSBB.Controllers
{
    [Authorize(Roles = "OSBB_Admin")]
    public class ApartmentController : Controller
    {
        IGenericService<ApartmentDTO> apartmentService;
        IGenericService<BenefitDTO> benefitService;

        public ApartmentController(IGenericService<ApartmentDTO> apartmentService,
        IGenericService<BenefitDTO> benefitService)
        {
            this.apartmentService = apartmentService;
            this.benefitService = benefitService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(apartmentService.GetAll());
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
    }
}