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
    }
}