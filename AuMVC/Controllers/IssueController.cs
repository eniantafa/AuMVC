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

        [HttpPost]
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
    }
}