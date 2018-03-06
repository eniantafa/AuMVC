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
        private ISiteService _siteService;

        public ProgressStageController(IProgressStageService progressStageService, ISiteService siteService)
        {
            _progressStageService = progressStageService;
            _siteService = siteService;

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
            ProgressStageViewModel progressStageVM = new ProgressStageViewModel()
            {
                Sites = _siteService.allSites()
            };

            return View(progressStageVM);
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

            return View(new ProgressStageViewModel() { Sites = _siteService.allSites() });
        }




        //edit


        public ActionResult EditProgressStage(int id)
        {

            ProgressStage myProgressStage = _progressStageService.GetProgressStageById(id);
            return View(myProgressStage);

        }

       
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

            if (!_progressStageService.Exists(id))
            {
                return RedirectToAction("IndexProgressStage");
            }
             return View(_progressStageService.GetProgressStageById(id));
        }



        // POST: Progstage/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmProgressStage(int id)
        {
             _progressStageService.Delete(id);
            return RedirectToAction("IndexProgressStage");
        }

    } }
