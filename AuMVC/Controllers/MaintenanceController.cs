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
                IssueCode = viewModel.IssueCode, //ask
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
    }
}