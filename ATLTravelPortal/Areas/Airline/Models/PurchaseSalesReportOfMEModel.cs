using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PurchaseSalesReportOfMEModel
    {

        [Required(ErrorMessage = "*")]
        [DisplayName("ME's Name")]
        public int? MEsNameID { get; set;}
        public IEnumerable<SelectListItem> MENameList { get; set;}
        [Required(ErrorMessage = "*")]
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set;}
        [Required(ErrorMessage = "*")]
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Currency")]
        public int? CurrencyID { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }
        
        public string AgentName { get; set;}
        public double? Purchase { get; set;}
        public double? Sales { get; set;}
        public double? Receipt { get; set;}

        public int AppUserId { get; set; }
        public int UserTypeId { get; set; }
     

        public IEnumerable<PurchaseSalesReportOfMEModel> PurchaseSalesReportOfMElist { get; set;}
    }
}