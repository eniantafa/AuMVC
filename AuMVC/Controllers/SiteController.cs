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
    public class SiteController : Controller
    {
        private AppDbContext _context;

        public SiteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: All Sites
        public ActionResult Index()
        {
            List<Site> sites = _context.Sites.ToList();
            return View(sites);
        }

        public ActionResult CreateSite()
        {
            return View("~/Views/Site/Create.cshtml", new SiteViewModel());
        }


        //[HttpPost]
        public ActionResult Create(SiteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Site Problem");

                return View();
                //Redirect tek nje error page
            }

            Site site = new Site()
            {
                SiteNumber = viewModel.SiteNumber,
                ContractDate = DateTime.Now,
                HomeOwner = viewModel.HomeOwner,
                ContactNumber = viewModel.ContactNumber,
                ContactEmail = viewModel.ContactEmail,
                HouseType = viewModel.HouseType,
                ContractValueExGST = viewModel.ContractValueExGST,
                ContractValueIncGST = viewModel.ContractValueIncGST,
                PreContactEOT = viewModel.PreContactEOT,
                DOPCDate = DateTime.Now,
                TwelveMonthMaintenance = DateTime.Now.AddYears(1),
                Note = viewModel.Note
            };

            _context.Sites.Add(site);
            _context.SaveChanges();

            return View();
        }

        public ActionResult Edit(int id)
        {
            Site mySite = _context.Sites.Where(n => n.Id == id).FirstOrDefault();
            return View(mySite);
        }

        public ActionResult EditConfirm(Site site)
        {
            Site oldSite = _context.Sites.Where(n => n.Id == site.Id).FirstOrDefault();
            oldSite.HomeOwner = site.HomeOwner;
            oldSite.SiteNumber = site.SiteNumber;
            oldSite.ContractDate = site.ContractDate;
            oldSite.ContactNumber = site.ContactNumber;
            oldSite.ContactEmail = site.ContactEmail;
            oldSite.HouseType = site.HouseType;
            oldSite.ContractValueExGST = site.ContractValueExGST;
            oldSite.ContractValueIncGST = site.ContractValueIncGST;
            oldSite.PreContactEOT = site.PreContactEOT;
            oldSite.DOPCDate = site.DOPCDate;
            oldSite.TwelveMonthMaintenance = site.TwelveMonthMaintenance;
            oldSite.Note = site.Note;

            //_context.Sites.AddOrUpdate(oldSite);
            _context.SaveChanges();

            return View();
        }
    }
}