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
    public class VariationController : Controller
    {

        private VariationService _variationService;

        public VariationController(VariationService variationService)
        {
            _variationService = variationService;
        }



        //all variations--
        public ActionResult IndexVariation()
        {
            List<Variation> variation = _variationService.allVariations();
            return View(variation);
        }



        // GET: Variation
        public ActionResult CreateVariation()
        {
            return View(new VariationViewModel());
        }

        [HttpPost]
        public ActionResult CreateVariation(VariationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "VariationProblem");

                return View();
                //Redirect tek nje error page
            }
            _variationService.CreateVariation(viewModel);

            return View();

        }



        //editvariation
        public ActionResult EditVariation(int id)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                Variation myVariation = _variationService.GetVariationById(id);
                return View(myVariation);
            }
        }

        public ActionResult EditConfirm(Variation variation)
        {

            _variationService.UpdateVariation(variation);
            return View();
        }




        //delete variation
        public ActionResult DeleteVariation(int id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexVariation");
            }
            
            if (_variationService.Exists(id))
            {
                return RedirectToAction("IndexVariation");
            }
            return View(_variationService.GetVariationById(id));
        }



        // POST: variation/Delete
        [HttpPost, ActionName("DeleteVariation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _variationService.Delete(id);
            return RedirectToAction("IndexVariation");
        }

    }
}
    
