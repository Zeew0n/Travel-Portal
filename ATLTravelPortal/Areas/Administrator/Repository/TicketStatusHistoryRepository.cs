using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class TicketStatusHistoryRepository
    {
        EntityModel Entity = new EntityModel();

        public IEnumerable<TicketStatusHistoryModel> GetTicketStatusHistory(DateTime FromDate,DateTime ToDate)
        {
            var Data = Entity.Air_GetTicketStatusHistory(FromDate, ToDate);

            List<TicketStatusHistoryModel> collection = new List<TicketStatusHistoryModel>();

            foreach (var item in Data)
            {
                TicketStatusHistoryModel singleone = new TicketStatusHistoryModel()
                {
                    MPNRId= item.MPNRId,
                    Branch= item.Branch,
                    Distributor = item.Distributor,
                    Agent = item.Agent,
                    Airline = item.Airline,
                    Sector = item.Sector,
                    Status = item.Status,
                    ServiceProviderName=item.ServiceProviderName
                };
                collection.Add(singleone);
            }
            return collection;


                
            }
 
        
    }
}