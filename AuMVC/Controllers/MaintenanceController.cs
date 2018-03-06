using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data;
using AuMVC.Data.Models;
using AuMVC.Data.Services;
using AuMVC.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuMVC.Controllers
{
    public class MaintenanceController : Controller
    {


        private IMaintenanceService _maintenanceService;
        private ISiteService _siteService;
        public MaintenanceController(IMaintenanceService maintenanceService, ISiteService siteService)
        {
            _maintenanceService = maintenanceService;
            _siteService = siteService;
        }



        //all maintenances--
        
        public ActionResult IndexMaintenance()
        {
            List<Maintenance> maintenances = _maintenanceService.allMaintenances();
            return View(maintenances);
        }





        // GET: Maintenance
        public ActionResult CreateMaintenance()
        {
            MaintenanceViewModel maintenanceVM = new MaintenanceViewModel()
            {
                Sites = _siteService.allSites()
            };
            return View(maintenanceVM);
        }

        [HttpPost]
        public ActionResult CreateMaintenance(MaintenanceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "MaintenanceProblem");

                return View();
                //Redirect tek nje error page
            }
            

            _maintenanceService.CreateMaintenance(viewModel);
            return View(new MaintenanceViewModel() { Sites = _siteService.allSites() });
        }






        //editmaintenance
        public ActionResult EditMaintenance(int id)
        {
            Maintenance myMaintenance = _maintenanceService.GetMaintenanceById(id);
                return View(myMaintenance);
        }

        public ActionResult EditConfirm(Maintenance maintenance)
        {

            _maintenanceService.UpdateMaintenance(maintenance);
            return View();
        }






        //delete maintenance
        public ActionResult DeleteMaintenance(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            
            if (!_maintenanceService.Exists(id))
            {
                return RedirectToAction("Index");
            }
            return View(_maintenanceService.GetMaintenanceById(id));
        }



        // POST: Maintenance/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmMaintenance(int id)
        {
            _maintenanceService.Delete(id);
            return RedirectToAction("IndexMaintenance");
        }
    }
}