using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using Abacus.XmlSelect;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class TicketCappingProvider
    {

        public IEnumerable<TicketCappingModel> GetList()
        {
            List<TicketCappingModel> data = new List<TicketCappingModel>();
            Abacus.Ticketing.TicketIssueManager manager = new Abacus.Ticketing.TicketIssueManager();

            var collection = manager.GetTLMTable(null);

            foreach (var item in collection)
            {
                TicketCappingModel temp=new TicketCappingModel();
                temp.AirlineCode = item.Carrier;
                temp.MaxValue = item.MaximumLimit;
                temp.MinValue = item.MinimumLimit;
                temp.RemainValue = item.Remaining;
                data.Add(temp);
            }
            return data.AsEnumerable();
        }
    }
}