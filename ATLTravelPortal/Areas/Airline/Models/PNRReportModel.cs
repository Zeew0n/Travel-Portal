using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PNRReportModel
    {
       
        public string AgentName { get; set; }
        [DisplayName("Passenger:")]
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        [DisplayName("GDS Refrence Number:")]
        public string GDSRefrenceNumber { get; set; }
        public string ServiceProviderName { get; set; }
        public string AirlineCode { get; set; }
        public string Sector { get; set; }
        public string Class { get; set; }
        public double? BaseFare { get; set; }
        public double? SurCharge { get; set; }
        public double? CommissionOnBF { get; set; }
        public double? ServiceCharge { get; set; }
        public double? TotalTax { get; set; }
        public double? TotalFare { get; set; }
        public string ticketStatusName { get; set; }
        
        [DisplayName("PNR:")]
        public int? PNRId { get; set; }
        [DisplayName("Agent:")]
        public int? AgentId { get; set; }

        public IEnumerable<SelectListItem> ddlAgentIdList { get; set; }
        public IEnumerable<PNRReportModel> PNRReportList { get; set; }
       
    }

   
}