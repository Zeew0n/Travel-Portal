using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class VoidRequestProvider
    {
        EntityModel ent = new EntityModel();
        public List<VoidRequestModel> VoidListRequestList()
        {
            var data = ent.Air_GetVoidListRequest(null);

            List<VoidRequestModel> model = new List<VoidRequestModel>();

            foreach (var item in data.Select(x => x))
            {
                var VoidtRequestModel = new VoidRequestModel
                {
                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    BookedOn = item.BookedOn.Value,
                    BookedBy = item.BookedBy,
                    GDSRefrenceNumber = item.GDSRefrenceNumber,
                    TicketStatusName = item.ticketStatusName,
                    TicketStatusID =(int) item.TicketStatusId,
                    AgentName=item.AgentName,
                    ServiceProviderId = item.ServiceProviderId,
                    ServiceProviderVoidUrl = item.ServiceProviderId == 4 ? "/Airline/VoidRequest/DomesticDetails" : "/Airline/VoidRequest/Details",
                };
                model.Add(VoidtRequestModel);

            }
            return model.OrderByDescending(x => x.BookedBy).ToList();
        }



        public void Confirm(long PnrId, double AirlineCancellationCharge, double ArihantCancellationCharge,bool isAgentPayCharge, int currencyid, int userid, int serid)
        {
          //  ent.Air_CancelTickets(PnrId, AirlineCancellationCharge, ArihantCancellationCharge, isAgentPayCharge, currencyid, userid);
            ent.Air_CancelTickets(PnrId, AirlineCancellationCharge, ArihantCancellationCharge, isAgentPayCharge, currencyid, userid, serid);
        }

        public void Reject(long MPnrId, int AppUserId)
        {
            ent.Air_RejectVoidRequest(MPnrId, AppUserId);
        }

    }
}