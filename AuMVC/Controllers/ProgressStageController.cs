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
    public class ProgressStageController : Controller
    {

        private AppDbContext _context;

        public ProgressStageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProgressStage
        public ActionResult CreateProgressStage()
        {
            return View(new ProgressStageViewModel());
        }


        [HttpPost]
        public ActionResult CreateProgressStage(ProgressStageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "ProgressStageProblem");

                return View();
                //Redirect tek nje error page
            }



            ProgressStage progressStage = new ProgressStage()
            {

                Stage = viewModel.Stage,
                Value = viewModel.Value,
                DateCompleted = DateTime.Now,
                CompletedBy = viewModel.CompletedBy,
                DateApproved = DateTime.Now.AddMonths(3), 
                ApprovedBy = viewModel.ApprovedBy,
                PaymentStatus = viewModel.PaymentStatus,
                DatePaid = DateTime.Now

            };

            _context.ProgressStages.Add(progressStage);
            _context.SaveChanges();

            return View();
        }
    }
}