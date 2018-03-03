using AuMVC.Data.Enums;
using AuMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.ViewModels
{
    public class MaintenanceViewModel
    {
        public string IssueCode { get; set; }
        public DateTime DateRaised { get; set; }
        public MaintenanceCategory Category { get; set; }
        public string Item { get; set; }
        public MaintenancePriority Priority { get; set; }
        public MaintenanceStatus Status { get; set; }
        public string Note { get; set; }

        //site dropdown
        public int SiteId { get; set; }
        public List<Site> Sites { get; set; }
    }
}
