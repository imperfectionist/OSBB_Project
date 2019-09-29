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
    public class BenefitController : Controller
    {
        IGenericService<BenefitDTO> benefitService;

        public BenefitController(IGenericService<BenefitDTO> benefitService)
        {
            this.benefitService = benefitService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(benefitService.GetAll());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BenefitDTO benefit = (id == 0) ? new BenefitDTO() : benefitService.Get(id);
            return View(benefit);
        }

        [HttpPost]
        public ActionResult Edit(BenefitDTO benefit)
        {
            if (ModelState.IsValid)
            {
                benefitService.AddOrUpdate(benefit);
                return RedirectToAction("Index");
            }
            return View(benefit);
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            try
            {
                BenefitDTO benefit = benefitService.Get(id);
                benefitService.Delete(benefit);
                return Json("OK");
            }
            catch { return Json("Error"); }
        }
    }
}