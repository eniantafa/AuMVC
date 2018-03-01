using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private AppDbContext _context;

        public MaintenanceController(AppDbContext context)
        {
            _context = context;
        }


        //all maintenances--
        
        public ActionResult IndexMaintenance()
        {
            List<Maintenance> maintenances = _context.Maintenances.ToList();
            return View(maintenances);
        }



        // GET: Maintenance
        public ActionResult CreateMaintenance()
        {
            return View(new MaintenanceViewModel());
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



            Maintenance maintenance = new Maintenance()
            {
                IssueCode = viewModel.IssueCode, 
                DateRaised = DateTime.Now,
                Category = viewModel.Category,
                Item = viewModel.Item,
                Priority = viewModel.Priority,
                Status = viewModel.Status,
                Note = viewModel.Note

            };

            _context.Maintenances.Add(maintenance);
            _context.SaveChanges();

            return View();
        }
        public ActionResult EditMaintenance(int id)
        {
                Maintenance myMaintenance = _context.Maintenances.Where(n => n.Id == id).FirstOrDefault();
                return View(myMaintenance);
        }

        public ActionResult EditConfirm(Maintenance maintenance)
        {
            Maintenance oldMaintenance = _context.Maintenances.Where(n => n.Id == maintenance.Id).FirstOrDefault();
            oldMaintenance.IssueCode = maintenance.IssueCode;
            oldMaintenance.DateRaised = maintenance.DateRaised;
            oldMaintenance.Item = maintenance.Item;
            oldMaintenance.Priority = maintenance.Priority;
            oldMaintenance.Status = maintenance.Status;
            oldMaintenance.Note = maintenance.Note;
            

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();

            return View();
        }


        //delete maintenance
        public ActionResult DeleteMaintenance(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Maintenance myMaintenance = _context.Maintenances.Find(id);
            if (myMaintenance == null)
            {
                return RedirectToAction("Index");
            }
            return View(myMaintenance);
        }



        // POST: Maintenance/Delete
        [HttpPost, ActionName("DeleteMaintenance")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Maintenance maintenance = _context.Maintenances.Find(id);
            _context.Maintenances.Remove(maintenance);
            _context.SaveChanges();
            return RedirectToAction("IndexMaintenance");
        }
    }
}