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
    public class ProgressStageController : Controller
    {

        private IProgressStageService _progressStageService;

        public ProgressStageController(IProgressStageService progressStageService)
        {
            _progressStageService = progressStageService;
        }


        //all prog stages--
        public ActionResult IndexProgressStage()
        {
            List<ProgressStage> progressStage = _progressStageService.allProgressStages();
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



            _progressStageService.CreateProgressStage(viewModel);

            return View();
        }




        //edit


        public ActionResult EditProgressStage(int id)
        {

            ProgressStage myProgressStage = _progressStageService.GetProgressStageById(id);
            return View(myProgressStage);

        }

        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(ProgressStage progressStage)
        {
            _progressStageService.UpdateProgressStage(progressStage);
            return View();

        }








        //delete progstage
        public ActionResult DeleteProgressStage(int id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexProgressStage");
            }

            if (_progressStageService.Exists(id))
            {
                return RedirectToAction("IndexProgressStage");
            }
            return View(_progressStageService.GetProgressStageById(id));
        }



        // POST: Progstage/Delete
        [HttpPost, ActionName("DeleteProgressStage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
             _progressStageService.Delete(id);
            return RedirectToAction("IndexProgressStage");
        }

    } }
