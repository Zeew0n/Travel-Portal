using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PurchaseSalesReportModel
    {
        [Required]
        [DisplayName("Currency")]
        public int? CurrencyID { get; set;}
        public IEnumerable<SelectListItem> CurrencyList { get; set;}
        [Required]
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set;}
        [Required]
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set;}
       

        public string Ariline { get; set;}
        public string ServiceProvider { get; set;}
        public string Sector { get; set;}
        public string BranchName { get; set;}
        public string DistributorName { get; set; }
        public string AgentName { get; set; }
        public double AdminPurchase { get; set; }
        public double? AdminSales { get; set; }
        public double? BranchPurchase { get; set; }
        public double? BranchSales { get; set; }
        public double? DistributorPurchase { get; set; }
        public double? DistributorSales { get; set; }
        public double? AgentPurchase { get; set; }
        public double? AgentSales { get; set; }



        public IEnumerable<PurchaseSalesReportModel> PurchaseList { get; set;}

    }
}