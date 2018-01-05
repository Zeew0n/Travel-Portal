using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class VoidRequestModel
    {
        [DisplayName("Agent")]
        public string AgentName { get; set; }

        [DisplayName("Type")]
        public string AirlineTypeName { get; set; }

        public long PNRId { get; set; }
        public string GDSRefrenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string TicketStatusName { get; set; }
        public int TicketStatusID { get; set; }

        [HiddenInput]
        public int ServiceProviderId { get; set; }
        public string ServiceProviderVoidUrl { get; set; }
        public IPagedList<VoidRequestModel> VoidRequestList { get; set; }

        [Required]
        [DisplayName("Airline Cancellation Charge")]
        public double AirlineCancellationCharge { get; set; }

        [Required]
        [DisplayName("Airhant Cancellation Charge")]
        public double ArihantCancellationCharge { get; set; }

        [Required]
        [DisplayName("Agent will pay charge")]
        public bool isAgentWillPaycharge { get; set; }
        
        
        //Export
        //public string ExportTypeExcel { get; set; }
        //public string ExportTypeWord { get; set; }
        //public string ExportTypeCSV { get; set; }
        //public string ExportTypePdf { get; set; }
        //public IEnumerable<VoidRequestModel> VoidRequestModel { get; set; }
    }
}