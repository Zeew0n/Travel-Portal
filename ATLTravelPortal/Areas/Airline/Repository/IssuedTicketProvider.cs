using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;


namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class IssuedTicketProvider
    {
        EntityModel ent = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();


        public List<IssuedTicketModel> ListIssuedTicketReport(int? AgentId, DateTime fromdate, DateTime todate)
        {
            var data = ent.Air_GetIssuedTicket(AgentId, fromdate, todate);

            List<IssuedTicketModel> model = new List<IssuedTicketModel>();

            foreach (var item in data.Select(x => x))
            {
                var IssuedTicketModel = new IssuedTicketModel
                {

                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    TicketStatusName = item.ticketStatusName,
                    GDSReferenceNumber = item.GDSRefrenceNumber,
                    IssuedOn = item.IssuedOn,
                    CreatedBy = item.IssuedBy,
                    AgentName = item.AgentName,
                    FlightDate = item.FlightDate,
                    ServiceProviderName = item.ServiceProviderName,
                    IssuedBy = item.IssuedBy,
                    ServiceProviderETicketUrl = (item.ServiceProviderId == 5 || item.ServiceProviderId == 4) ? "/Airline/LccTicketManagement" : "/Airline/TicketManagement",
                    //ServiceProviderETicketUrl = "/Airline/LccTicketManagement",
                    isTicketUploaded = item.isTicketUploaded,
                    AgentId=item.AgentId,
                    BracnOfficeId=item.BranchOfficeId,
                    DistributorId=item.DistributorId,
                    AgentCode = new ATLTravelPortal.Areas.Airline.Repository.BookedTicketReportProvider().GetAgentCodeById(item.AgentId),
                    NoOfPax = item.PaxCount,
                    AirlineCode = item.OperatingAirline

                };

                var distributor = distributorManagementProvider.GetDistributorByDistributorId(item.DistributorId);
                if (distributor != null)
                {
                    IssuedTicketModel.DistributorName = distributor.DistributorName + "(" + distributor.DistributorCode + ")";
                }
                var branchOffice = branchOfficeManagementProvider.GetBranchOfficeInfo(item.BranchOfficeId);
                if (branchOffice != null)
                {
                    IssuedTicketModel.BranchOfficeName = branchOffice.BranchOfficeName + "(" + branchOffice.BranchOfficeCode + ")";
                }
                model.Add(IssuedTicketModel);
            }
            return model.OrderByDescending(x => x.BookedOn).ToList();
        }



        //for pagination//
        public IQueryable<IssuedTicketModel> GetIssuedTicketReportByPagination(IssuedTicketModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.IssuedTicketList.Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<IssuedTicketModel> pagingdata = m.IssuedTicketList.Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();
        }




        public List<AirlineTypes> GetAirlineTypesList()
        {
            return ent.AirlineTypes.Where(x=>x.isActive==true).ToList();
        }





        /// <summary>
        /// //////////////////////////////For IndianLcc Report/////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="AgentId"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>



        public List<IssuedTicketModel> ListIndianLccIssuedTicketReport(int? AgentId, DateTime fromdate, DateTime todate)
        {
            var data = ent.Air_GetIssuedTicket(AgentId, fromdate, todate).Where(x=>x.ServiceProviderId==5).ToList();
            List<IssuedTicketModel> model = new List<IssuedTicketModel>();
            foreach (var item in data)
            {
                var IssuedTicketModel = new IssuedTicketModel
                {
                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    TicketStatusName = item.ticketStatusName,
                    GDSReferenceNumber = item.GDSRefrenceNumber,
                    IssuedOn = item.IssuedOn,
                    CreatedBy = item.IssuedBy,
                    AgentName = item.AgentName,
                    FlightDate = item.FlightDate,
                    ServiceProviderName = item.ServiceProviderName,
                    IssuedBy = item.IssuedBy,
                    ServiceProviderETicketUrl = "/Airline/LccTicketManagement",
                    isTicketUploaded = item.isTicketUploaded
                };
                model.Add(IssuedTicketModel);
            }
            return model.OrderByDescending(x => x.BookedOn).ToList();
        }





    }
}