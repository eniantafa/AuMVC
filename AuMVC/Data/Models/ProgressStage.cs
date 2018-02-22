using AuMVC.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.Models
{
    public class ProgressStage
    {


        [Key]
        public int Id { get; set; }
        public ProgressStageStage Stage { get; set; }
        public double Value { get; set; }
        public DateTime DateCompleted { get; set; }
        public string CompletedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public string ApprovedBy { get; set; }
        public ProgressStagePaymentStatus PaymentStatus { get; set; }
        public DateTime DatePaid { get; set; }



        public virtual Site Site { get; set; }
        public int SiteId { get; set; }
    }
}
