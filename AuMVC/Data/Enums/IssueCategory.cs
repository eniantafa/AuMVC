using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Enums
{
    public enum IssueCategory
    {
        [Display(Name = "Category1")]
        Category1,

        [Display(Name = "Category 2")]
        Category2,

        [Display(Name = "Category 3")]
        Category3
    }
}
