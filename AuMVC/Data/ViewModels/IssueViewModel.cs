using AuMVC.Data.Enums;
using System;
using AuMVC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuMVC.Data.Models;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AuMVC.Data.ViewModels
{
    public class IssueViewModel
    {
        
        [Required(ErrorMessage = "This field is required")]
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public IssueCategory Category { get; set; }
        public string Item { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public string Note { get; set; }

        //site dropdown
        public int SiteId { get; set; }
        public List<Site> Sites { get; set; }

    }

    
}
