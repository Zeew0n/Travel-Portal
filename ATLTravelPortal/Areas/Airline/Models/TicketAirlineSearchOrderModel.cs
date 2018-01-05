using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class TicketAirlineSearchOrderModel
    {
        public long AirlineSearchOrderId { get; set; }
        public int?SerialNo { get; set; }
        public int?AirlineId { get; set; }
        public string AirlineName { get; set; }
        public List<int> NumberOfId { get; set; }
        public List<int> SerialOrder { get; set; }
        public int AirlineTypeId { get; set; }
        public IEnumerable<TicketAirlineSearchOrderModel> GetTicketAirlineSearchList { get; set; }
    }
}