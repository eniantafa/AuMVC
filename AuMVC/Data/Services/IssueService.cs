using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;

namespace AuMVC.Data.Services
{
    public class IssueService : IIssueService
    {



        private AppDbContext _context;
        public IssueService(AppDbContext context)
        {
            _context = context;
        }




        public List<Issue> allIssues()
        {
            return _context.Issues.ToList();
        }




        public void CreateIssue(IssueViewModel viewModel)
        {
            Issue issue = new Issue()
            {
                Code = viewModel.Code,
                Date = DateTime.Now,
                Category = viewModel.Category,
                Item = viewModel.Item,
                Priority = viewModel.Priority,
                Status = viewModel.Status,
                Note = viewModel.Note,
                SiteId = viewModel.SiteId

            };

            _context.Issues.Add(issue);
            _context.SaveChanges();
        }





        public void Delete(int issueId)
        {
            Issue issue = _context.Issues.Where(n => n.Id == issueId).FirstOrDefault();
            _context.Issues.Remove(issue);
            _context.SaveChanges();
        }




        public bool Exists(int issueId)
        {
            return _context.Issues.Any(n => n.Id == issueId);
        }




        public Issue GetIssueById(int issueId)
        {
            return _context.Issues.Where(n => n.Id == issueId).FirstOrDefault();
        }





        public void UpdateIssue(Issue newIssue)
        {

            Issue oldIssue = _context.Issues.Where(n => n.Id == newIssue.Id).FirstOrDefault();
            oldIssue.Code = newIssue.Code;
            oldIssue.Date = newIssue.Date;
            oldIssue.Category = newIssue.Category;
            oldIssue.Item = newIssue.Item;
            oldIssue.Priority = newIssue.Priority;
            oldIssue.Status = newIssue.Status;
            oldIssue.Note = newIssue.Note;


            //_context.Sites.AddOrUpdate(oldIssue);
            _context.SaveChanges();

        }
    }
}
