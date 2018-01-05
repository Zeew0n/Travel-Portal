using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class CancelledVoidTicketProvider
    {
        EntityModel ent = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();


        public List<CancelledVoidTicketModel> ListCancelledVoidTicketReport(int? AgentId, DateTime? fromdate, DateTime? todate, int? AirlineTypeId)
        {
            var data = ent.Air_GetCancelledVoidTicket(AgentId, fromdate, todate, AirlineTypeId);

            List<CancelledVoidTicketModel> model = new List<CancelledVoidTicketModel>();

            foreach (var item in data.Select(x => x))
            {
                var CancelledVoidTicketModel = new CancelledVoidTicketModel();

                CancelledVoidTicketModel.PNRId = item.PNRId;
                CancelledVoidTicketModel.AgentName = item.AgentName;
                CancelledVoidTicketModel.GDSReferenceNumber = item.GDSRefrenceNumber;
                CancelledVoidTicketModel.PassengerName = item.PassengerName;
                CancelledVoidTicketModel.Sector = item.Sector;
                CancelledVoidTicketModel.CancelledOn = item.CancelledOn;
                CancelledVoidTicketModel.ServiceProviderId = item.ServiceProviderId;
                CancelledVoidTicketModel.Info = item.Info;
                CancelledVoidTicketModel.FlightDate = item.FlightDate;
                CancelledVoidTicketModel.AgentId = item.AgentId;
                CancelledVoidTicketModel.BranchOfficeId = item.BranchOfficeId;
                CancelledVoidTicketModel.DistributorId = item.DistributorId;
                CancelledVoidTicketModel.AgentCode = new ATLTravelPortal.Areas.Airline.Repository.BookedTicketReportProvider().GetAgentCodeById(item.AgentId);


                var distributor = distributorManagementProvider.GetDistributorByDistributorId(item.DistributorId);
                if (distributor != null)
                {
                    CancelledVoidTicketModel.DistributorName = distributor.DistributorName + "(" + distributor.DistributorCode + ")";
                }
                var branchOffice = branchOfficeManagementProvider.GetBranchOfficeInfo(item.BranchOfficeId);
                if (branchOffice != null)
                {
                    CancelledVoidTicketModel.BranchOfficeName = branchOffice.BranchOfficeName + "(" + branchOffice.BranchOfficeCode + ")";
                }
                
                model.Add(CancelledVoidTicketModel);
            }
            return model.OrderByDescending(x=>x.CancelledOn).ToList();
        }

        public List<AirlineTypes> GetAirlineTypesList()
        {
            return ent.AirlineTypes.Where(x => x.isActive == true).ToList();
        }
    }
}