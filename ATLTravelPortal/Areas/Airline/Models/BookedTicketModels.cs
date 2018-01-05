using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class BookedTicketModels
    {
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

         [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public long PNRId { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string GDSRefrenceNumber { get; set; }

        public DateTime? FlightDate { get; set; }

        //[DisplayName("AirLine Types:")]
        //public int AirlineTypesId { get; set; }
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

        public int ServiceProviderId { get; set; }


        public IEnumerable<BookedTicketModels> BookedTicketList { get; set; }

        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }

        public int DistributorId { get; set; }
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public string DistributorName { get; set; }
    }
}