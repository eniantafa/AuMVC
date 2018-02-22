using AuMVC.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Models
{
    public class Maintenance
    {

        [Key]
        public int Id { get; set; }
        public string IssueCode { get; set; }
        public DateTime DateRaised { get; set; }
        public MaintenanceCategory Category { get; set; }
        public string Item { get; set; }
        public MaintenancePriority Priority { get; set; }
        public MaintenanceStatus Status { get; set; }
        public string Note { get; set; }


        public virtual Site Site { get; set; }
        public int SiteId { get; set; }

    }
}
