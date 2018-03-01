using AuMVC.Data.Models;
using AuMVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Services
{
    public interface IIssueService
    {
        List<Issue> allIssues();
        void CreateIssue(IssueViewModel viewModel);
        Issue GetIssueById(int issueId);
        void UpdateIssue(Issue newIssue);
        bool Exists(int issueId);
        void Delete(int issueId);
    }
}
