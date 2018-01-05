using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class IssuedTicketModel
    {
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentCode { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime ToDate { get; set; }

        public long PNRId { get; set; }
        public string PassengerName { get; set; }
        public int? NoOfPax { get; set; }
        public string AirlineCode { get; set; }
        public string Sector { get; set; }
        public string TicketStatusName { get; set; }
        public string GDSReferenceNumber { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }

        public DateTime? IssuedOn { get; set; }
        public string CreatedBy { get; set; }

        public int TicketStatusId { get; set; }

        [DisplayName("AirLine Types:")]
        public int AirlineTypesId { get; set; }
        public string AirlineTypes { get; set; }
        public IEnumerable<SelectListItem> AirlineTypesList { get; set; }

        public IEnumerable<IssuedTicketModel> IssuedTicketList { get; set; }



        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }
        public IEnumerable<IssuedTicketModel> IssuedTicketListExport { get; set; }

        public string AgentName { get; set; }

        public string ServiceProviderETicketUrl { get; set; }

        public DateTime? FlightDate { get; set; }
        public string ServiceProviderName { get; set; }
        public string IssuedBy { get; set; }

        public bool? isTicketUploaded { get; set; }

        public int BracnOfficeId { get; set; }
        public int DistributorId { get; set; }

        public string BranchOfficeName { get; set; }
        public string DistributorName { get; set; }
    }
}