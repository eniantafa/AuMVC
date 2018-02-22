using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data.ViewModels
{
    public class SiteViewModel
    {


        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string SiteNumber { get; set; }
        public string HomeOwner { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string HouseType { get; set; }
        public int ContractValueExGST { get; set; }
        public int ContractValueIncGST { get; set; }
        public DateTime ContractDate { get; set; }
        public int PreContactEOT { get; set; }
        public DateTime DOPCDate { get; set; }
        public string Note { get; set; }
    }
}
