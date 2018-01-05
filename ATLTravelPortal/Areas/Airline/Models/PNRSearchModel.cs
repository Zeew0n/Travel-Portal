using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PNRSearchModel
    {
       
        

        [DisplayName ("Agent ID")]
        public int AgentId { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName ("PNR ID")]
        public Int64 PNRId { get; set; }

        [DisplayName("Passenger Name")]
        public string PassengerName { get; set; }

        
        [DisplayName("Ticket No")]
        public string TicketNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("From Date")]
        public string fromdatestring { get; set; }
        public DateTime fromdate { get; set; }
       
        [Required(ErrorMessage="*")]
        [DisplayName("To Date")]
        public DateTime todate { get; set; }
        public string todatestring { get; set; }


        [DisplayName("Departure City")]
        public string deptcity { get; set; }

        [DisplayName("Destination City")]
        public string destncity { get; set; }


        [DisplayName("Departure Time")]
        public TimeSpan depttime { get; set; }

        [DisplayName("Arrival Time")]
        public TimeSpan arrivaltime { get; set; }


         [DisplayName("Select Agent")]
        public IEnumerable<SelectListItem> AgentList { get; set; }
       
    }

   
}