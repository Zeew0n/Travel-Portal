using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PendingBookingProvider
    {
        EntityModel ent = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();

        public List<PendingBookingModel> ListPendingBookintReport(int? AgentId, DateTime? fromdate, DateTime? todate)
        {
            var data = ent.Air_GetPendingTicket(AgentId, fromdate, todate);

            List<PendingBookingModel> model = new List<PendingBookingModel>();

            foreach (var item in data.Select(x => x))
            {
                var PendingBookingModel = new PendingBookingModel
                {
                    PNRId = item.PNRId,
                    AgentName = item.AgentName,
                    GDSReferenceNumber = item.GDSRefrenceNumber,
                    PassegerName = item.PassengerName,
                    Sector = item.Sector,
                    BookedOn = (DateTime) item.BookedOn,
                    BookedBy = item.BookedBy,
                    ServiceProviderName = item.ServiceProviderName,
                    FlightDate = item.FlightDate,
                    // ServiceProviderReferenceNumber = item.ServiceProviderName == "TBO" ? "/IndianLCC/LccPNRDetail" : "/Airline/PNRDetail",
                    AgentId=item.AgentId,
                    BrachOfficeId=item.BranchOfficeId,
                    DistributorId=item.DistributorId,
                    AgentCode = new ATLTravelPortal.Areas.Airline.Repository.BookedTicketReportProvider().GetAgentCodeById(item.AgentId)
                    
                };
                var distributor = distributorManagementProvider.GetDistributorByDistributorId(item.DistributorId);
                if (distributor != null)
                {
                    PendingBookingModel.DistributorName = distributor.DistributorName + "(" + distributor.DistributorCode + ")";
                }
                var branchOffice = branchOfficeManagementProvider.GetBranchOfficeInfo(item.BranchOfficeId);
                if (branchOffice != null)
                {
                    PendingBookingModel.BranchOfficeName = branchOffice.BranchOfficeName + "(" + branchOffice.BranchOfficeCode + ")";
                }

                model.Add(PendingBookingModel);
            }
            return model.ToList();
        }

        public List<Agents> GetAgentsList()
        {
            return ent.Agents.ToList();
        }
    }
}