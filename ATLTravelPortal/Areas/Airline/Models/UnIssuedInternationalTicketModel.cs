using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class UnIssuedInternationalTicketModel
    {
        public int AgentId { get; set; }
        public String AgentName { get; set; }
        public Int64 PNRid { get; set; }
        public string GDSRefrenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string AirlineCode { get; set; }
        public string Sector { get; set; }
        public string BookedBy { get; set; }
        public DateTime BookedDate { get; set; }
        public int ServiceProviderId { get; set; }
        public DateTime FlightDate { get; set; }

        [DisplayName("Airline Cancellation Charge")]
        public double AirlineCancellationCharge { get; set; }

        [DisplayName("Arihant Cancellation Charge")]
        public double ArihantCancellationCharge { get; set; }

        [DisplayName("Agent will pay the charge?")]
        public bool isAgentWillPaycharge { get; set; }
        public int UserID { get; set; }

        public IEnumerable<UnIssuedInternationalTicketModel> UnIssuedInternationTicketList { get; set; }
        
    }
}