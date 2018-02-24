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


        //all prog stages--
        public ActionResult IndexProgressStage()
        {
            List<ProgressStage> progressStage = _context.ProgressStages.ToList();
            return View(progressStage);
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

        public ActionResult EditProgressStage(int id)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                ProgressStage myProgressStage = ctx.ProgressStages.Where(n => n.Id == id).FirstOrDefault();
                return View(myProgressStage);
            }
        }

        public ActionResult EditConfirm(ProgressStage progressStage)
        {
            ProgressStage oldProgressStage = _context.ProgressStages.Where(n => n.Id == progressStage.Id).FirstOrDefault();
            oldProgressStage.Stage = progressStage.Stage;
            oldProgressStage.Value = progressStage.Value;
            oldProgressStage.DateCompleted = progressStage.DateCompleted;
            oldProgressStage.DateApproved = progressStage.DateApproved;
            oldProgressStage.ApprovedBy = progressStage.ApprovedBy;
            oldProgressStage.PaymentStatus = progressStage.PaymentStatus;
            oldProgressStage.DatePaid = oldProgressStage.DatePaid;

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();

            return View();
        }
    }
}