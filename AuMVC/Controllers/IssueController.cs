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
    public class IssueController : Controller
    {
        private AppDbContext _context;

        public IssueController(AppDbContext context)
        {
            _context = context;
        }


        //all issues--
        public ActionResult IndexIssue()
        {
            List<Issue> issues = _context.Issues.ToList();
            return View(issues);
        }

        // GET: Issue
        public ActionResult CreateIssue()
        {
            return View(new IssueViewModel());
        }


        public ActionResult CreateIssue(IssueViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "IssueProblem");

                return View();
                //Redirect tek nje error page
            }


            Issue issue = new Issue()
            {
                Code = viewModel.Code,
                Date = DateTime.Now,
                Category = viewModel.Category,
                Item = viewModel.Item,
                Priority = viewModel.Priority,
                Status = viewModel.Status,
                Note = viewModel.Note

            };

            _context.Issues.Add(issue);
            _context.SaveChanges();

            return View();
        }


        //edit issue

        public ActionResult EditIssue(int id)
        {
            Issue myIssue = _context.Issues.Where(n => n.Id == id).FirstOrDefault();
            return View(myIssue);
        }

        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(Issue issue)
        {
            Issue oldIssue = _context.Issues.Where(n => n.Id == issue.Id).FirstOrDefault();
            oldIssue.Code = issue.Code;
            oldIssue.Date = issue.Date;
            oldIssue.Category = issue.Category;
            oldIssue.Item = issue.Item;
            oldIssue.Priority = issue.Priority;
            oldIssue.Status = issue.Status;
            oldIssue.Note = issue.Note;


            //_context.Sites.AddOrUpdate(oldIssue);
            _context.SaveChanges();

            return View();


            //deleteissue

             ActionResult DeleteIssue(int id)
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                Issue myIssue = _context.Issues.Find(id);
                if (myIssue == null)
                {
                    return RedirectToAction("Index");
                }
                return View(myIssue);
            }
        }



// POST: Issue/Delete
        [HttpPost, ActionName("DeleteIssue")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmIssue(int id)
        {
            Site site = _context.Sites.Find(id);
            _context.Sites.Remove(site);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

