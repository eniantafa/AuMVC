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
    public class VariationController : Controller
    {

        private AppDbContext _context;

        public VariationController(AppDbContext context)
        {
            _context = context;
        }



        //all variations--
        public ActionResult IndexVariation()
        {
            List<Variation> variation = _context.Variations.ToList();
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


            Variation variation = new Variation()
            {

                VariationCode = viewModel.VariationCode,
                DateReleased = DateTime.Now,
                Contract = viewModel.Contract,
                Location = viewModel.Location,
                Description = viewModel.Description,
                Comment = viewModel.Comment,
                Price = viewModel.Price,
                EOT = viewModel.EOT,
                Status = viewModel.Status,
                Claimed = viewModel.Claimed,
                Paid = viewModel.Paid,
                PaymentDate = DateTime.Now


            };

            _context.Variations.Add(variation);
            _context.SaveChanges();

            return View();

        }

        public ActionResult EditVariation(int id)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                Variation myVariation = ctx.Variations.Where(n => n.Id == id).FirstOrDefault();
                return View(myVariation);
            }
        }

        public ActionResult EditConfirm(Variation variation)
        {
            Variation oldVariation = _context.Variations.Where(n => n.Id == variation.Id).FirstOrDefault();
            oldVariation.VariationCode = variation.VariationCode;
            oldVariation.DateReleased = variation.DateReleased;
            oldVariation.Contract = variation.Contract;
            oldVariation.Location = variation.Location;
            oldVariation.Description = variation.Description;
            oldVariation.Comment = variation.Comment;
            oldVariation.Price = variation.Price;
            oldVariation.EOT = variation.EOT;
            oldVariation.Status = variation.Status;
            oldVariation.Claimed = variation.Claimed;
            oldVariation.Paid = variation.Paid;
            oldVariation.PaymentDate = variation.PaymentDate;
            //futen vlerat e tjera

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();

            return View();
        }


        //delete variation
        public ActionResult DeleteVariation(int id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexVariation");
            }
            Variation myvariation = _context.Variations.Find(id);
            if (myvariation == null)
            {
                return RedirectToAction("IndexVariation");
            }
            return View(myvariation);
        }



        // POST: variation/Delete
        [HttpPost, ActionName("DeleteVariation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Variation variation = _context.Variations.Find(id);
            _context.Variations.Remove(variation);
            _context.SaveChanges();
            return RedirectToAction("IndexVariation");
        }

    }
}
    
