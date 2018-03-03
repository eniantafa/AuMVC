using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "Issue Status 1")]
        IssueStatus1,

        [Display(Name = "Issue Status 2")]
        IssueStatus2,

        [Display(Name = "Issue Status 3")]
        IssueStatus3
    }
}
