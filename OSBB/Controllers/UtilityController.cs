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
    public class UtilityController : Controller
    {
        IGenericService<UtilityDTO> utilityService;
        IGenericService<UnitDTO> unitService;

        public UtilityController(IGenericService<UtilityDTO> utilityService, IGenericService<UnitDTO> unitService)
        {
            this.utilityService = utilityService;
            this.unitService = unitService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(utilityService.GetAll());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UtilityDTO utility = (id == 0) ? new UtilityDTO() : utilityService.Get(id);
            ViewBag.Units = new SelectList(unitService.GetAll().Select(u => new SelectListItem { Value = u.UnitId.ToString(), Text = u.UnitName }), "Value", "Text", 
                new SelectListItem { Value = utility.UnitId.ToString(), Text = utility.UnitName });
            return View(utility);
        }

        [HttpPost]
        public ActionResult Edit (UtilityDTO utility)
        {
            if (ModelState.IsValid)
            {
                utilityService.AddOrUpdate(utility);
                return RedirectToAction("Index");
            }
            return View(utility);
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            try
            {
                UtilityDTO utility = utilityService.Get(id);
                utilityService.Delete(utility);
                return Json("OK");
            }
            catch { return Json("Error"); }
        }
    }
}