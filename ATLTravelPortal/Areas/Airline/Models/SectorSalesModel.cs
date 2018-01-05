using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class SectorSalesModel
    {
        [Required]
        [DisplayName("Agent")]
        public string AgentName { get; set; }
        public int? AgentId { get; set; }

        [Required]
        [DisplayName("Currency")]
        public string CurrencyName { get; set; }
        public int? CurrencyId { get; set; }

        [Required]
        [DisplayName("Type")]
        public string TypeName { get; set; }
        public int? TypeId { get; set; }


        [DisplayName("Airline")]
        public string AirlineTypeName { get; set; }
        public int? AirlineTypeId { get; set; }

        [DisplayName("Airline")]
        public string AirlinesName { get; set; }

        public int hdfAirlineName { get; set; }
       

        [Required]
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string GDSReferenceNumber { get; set; }
        public string ServiceProviderName { get; set; }
        public string AirlineCode { get; set; }
        public string Class { get; set; }
        public Double? BaseFare { get; set; }
        public Double? ServiceCharge { get; set; }
        public Double? CommissionOnBF { get; set; }
        public Double? SurCharge { get; set; }
        public Double? TotalTax { get; set; }
        public Double? TotalFare { get; set; }
        public string TicketStatusName { get; set; }
        public string Sector { get; set; }

        public int? MPNRId { get; set; }
        public int? BranchOfficeId { get; set; }
        public int? DistributorId { get; set; }
        public string TicketNumber { get; set; }
        public double? AdminAmount { get; set; }
        public double? AgentAmount { get; set; }
        public double? BranchAmount { get; set; }
        public double? DistributorAmount { get; set; }


        public IEnumerable<SectorSalesModel> SectorSalesList { get; set; }





    }
}