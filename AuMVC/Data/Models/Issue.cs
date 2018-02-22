using AuMVC.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }
        public DateTime Date { get; set; }
        public IssueCategory Category { get; set; }
        public string Item { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public string Note { get; set; }


        public virtual Site Site { get; set; }
        public int SiteId { get; set; }

    }
}
