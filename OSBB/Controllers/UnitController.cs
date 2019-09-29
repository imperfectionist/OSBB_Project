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
    public class UnitController : Controller
    {
        IGenericService<UnitDTO> unitService;

        public UnitController(IGenericService<UnitDTO> unitService)
        {
            this.unitService = unitService;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(unitService.GetAll());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UnitDTO unit = (id == 0) ? new UnitDTO() : unitService.Get(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult Edit(UnitDTO unit)
        {
            if (ModelState.IsValid)
            {
                unitService.AddOrUpdate(unit);
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                UnitDTO unit = unitService.Get(id);
                unitService.Delete(unit);
                return Json("OK");
            }
            catch { return Json("Error"); }
        }
    }
}