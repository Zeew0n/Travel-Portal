using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class UnIssuedDomesticTicketModel
    {
        [Required]
        [DisplayName("Agent")]
        public string AgentName { get; set; }

        
        public Int64 PNRID { get; set; }
        public string Passenger { get; set; }
        public string AirlineCode { get; set; }
        public string Sector { get; set; }
        public string TicketStatusName { get; set; }
        public string BookedBy { get; set; }
        public DateTime BookedDate { get; set; }

        public IEnumerable<UnIssuedDomesticTicketModel> UsIssuedDomesticTicketList { get; set; }
        



    }
}