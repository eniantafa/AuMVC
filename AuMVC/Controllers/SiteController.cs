using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AuMVC.Data;
using AuMVC.Data.Models;
using AuMVC.Data.Services;
using AuMVC.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuMVC.Controllers
{
    public class SiteController : Controller
    {
        private ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: All Sites
        public ActionResult Index()
        {
            List<Site> sites = _siteService.allSites();
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
            }

            _siteService.CreateSite(viewModel);
            return View();
        }

        public ActionResult Edit(int id)
        {
            Site mySite = _siteService.GetSiteById(id);
            return View(mySite);
        }

        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(Site site)
        {
            _siteService.UpdateSite(site);
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            if (_siteService.Exists(id))
            {
                return RedirectToAction("Index");
            }
            return View(_siteService.GetSiteById(id));
        }



        // POST: Site/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _siteService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}