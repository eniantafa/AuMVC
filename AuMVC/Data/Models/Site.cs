using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Models
{
    public class Site
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string SiteNumber { get; set; }
        public string HomeOwner { get; set; }
        public string ContactNumber { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
        public string HouseType { get; set; }
        public double ContractValueExGST { get; set; }
        public double ContractValueIncGST { get; set; }
        public DateTime ContractDate { get; set; }
        public int PreContactEOT { get; set; }
        public DateTime DOPCDate { get; set; }
        public DateTime TwelveMonthMaintenance { get; set; }
        public string Note { get; set; }


        //Relations
        public List<Issue> Issues { get; set; }
        public List<Maintenance> Maintenances { get; set; }
        public List<ProgressStage> ProgressStages { get; set; }
        public List<Variation> Variations { get; set; }

    }
}
