using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PendingBookingModel
    {
        public Int64 PNRId { get; set; }
        public string GDSReferenceNumber { get; set; }
        public string PassegerName { get; set; }
        public string Sector { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string ServiceProviderName { get; set; }

        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }

        [DisplayName("From")]
        public DateTime? FromDate { get; set; }
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public DateTime? FlightDate { get; set; }

        public string ServiceProviderReferenceNumber { get; set; }

        public IPagedList<PendingBookingModel> PendingBookingList { get; set; }

        public int BrachOfficeId { get; set; }
        public int DistributorId { get; set; }

        public string BranchOfficeName { get; set; }
        public string DistributorName { get; set; }
    }
}