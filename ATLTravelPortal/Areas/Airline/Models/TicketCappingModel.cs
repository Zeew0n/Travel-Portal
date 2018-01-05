using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class TicketCappingModel
    {
        public string AirlineCode { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public string RemainValue { get; set; }

        IEnumerable<TicketCappingModel> ticketCappingList { get; set; }
    }
}