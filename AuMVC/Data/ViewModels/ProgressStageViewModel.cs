using AuMVC.Data.Enums;
using AuMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.ViewModels
{
    public class ProgressStageViewModel
    {
        public ProgressStageStage Stage { get; set; }
        public double Value { get; set; }
        public DateTime DateCompleted { get; set; }
        public string CompletedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public string ApprovedBy { get; set; }
        public ProgressStagePaymentStatus PaymentStatus { get; set; }
        public DateTime DatePaid { get; set; }
        
        //site dropdown
        public int SiteId { get; set; }
        public List<Site> Sites { get; set; }
    }
}
