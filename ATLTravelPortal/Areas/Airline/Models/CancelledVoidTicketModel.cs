using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class CancelledVoidTicketModel
    {
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
       
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        private int m_id = 1;
        [DisplayName("Airline Type:")]
        public int AirlineTypesId
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        public string AirlineTypes { get; set; }
        public IEnumerable<SelectListItem> AirlineTypesList { get; set; }

        public Int64 PNRId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        public string GDSReferenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }
        public DateTime? CancelledOn { get; set; }
        public string Info { get; set; }
        public int ServiceProviderId { get; set; }

        public DateTime? FlightDate { get; set; }

        public IEnumerable<CancelledVoidTicketModel> CancelledVoidTicketList { get; set; }

        public int BranchOfficeId { get; set; }
        public int DistributorId { get; set; }
        public string BranchOfficeName { get; set; }
        public string DistributorName { get; set; }
    }
}