using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Enums
{
    public enum IssuePriority
    {
        [Display(Name = "High Priority")]
        High,

        [Display(Name = "Medium Priority")]
        Medium,

        [Display(Name = "Low Priority")]
        Low
    }
}
