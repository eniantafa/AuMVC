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
    public class IssueController : Controller
    {
        private IIssueService _issueService;
        private ISiteService _siteService;

        public IssueController(IIssueService issueService, ISiteService siteService)
        {
            _issueService = issueService;
            _siteService = siteService;
        }


        //all issues--
        public ActionResult IndexIssue()
        {
            List<Issue> issues = _issueService.allIssues();
            return View(issues);
        }







        // GET: Issue
        
        public ActionResult CreateIssue()
        {
            IssueViewModel issueVM = new IssueViewModel()
            {
                Sites = _siteService.allSites()
            };

            return View(issueVM);
        }

        [HttpPost]
        public ActionResult CreateIssue(IssueViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "IssueProblem");

                return View();
                //Redirect tek nje error page
            }


            _issueService.CreateIssue(viewModel);

            return View();
        }








        //edit issue

        public ActionResult EditIssue(int id)
        {
            Issue myIssue = _issueService.GetIssueById(id);
            return View(myIssue);
        }

        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(Issue issue)
        {
            _issueService.UpdateIssue(issue);
            return View();

        }



        //deleteissue

        ActionResult DeleteIssue(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }


            if (_issueService.Exists(id))
            {
                return RedirectToAction("Index");
            }
            return View(_issueService.GetIssueById(id));
        }


        // POST: Issue/Delete
        [HttpPost, ActionName("DeleteIssue")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmIssue(int id)
        {
            _issueService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


