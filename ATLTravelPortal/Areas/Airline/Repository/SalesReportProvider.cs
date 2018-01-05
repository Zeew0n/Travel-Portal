using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class SalesReportProvider
    {
        EntityModel ent = new EntityModel();
        AgencyProvider agencyProvider = new AgencyProvider();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();

        public decimal TotalAgentBillingStatement_Cash = 0;
        public decimal TotalAgentBillingStatement_Tax = 0;
        public decimal TotalAgentBillingStatement_Commission = 0;
        public decimal TotalAgentBillingStatement_Payable = 0;


        public decimal TotalAgentBillingStatementDetails_Cash = 0;
        public decimal TotalAgentBillingStatementDetails_Tax = 0;
        public decimal TotalAgentBillingStatementDetails_Commission = 0;
        public decimal TotalAgentBillingStatementDetails_Payable = 0;


        public List<SalesReportModel> GetSalesReport(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {
            //var data = ent.Air_GetAgentBillingStatement(AgentId, fromdate, todate, AirlinesTypeId);
            var data = ent.Air_GetAgentBillingStatement(AgentId, fromdate, todate, currencyId);

            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in data.Select(x => x))
            {

                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineId = item.AirlineId;
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash + (Decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash;


                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable;
                SalesReportModel.AgentId = item.Agentid;
                model.Add(SalesReportModel);

            }
            return model;
        }



        public List<SalesReportModel> GetSalesReportDetails(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {           
            var data = ent.Air_GetAgentBillingStatementDetails(AgentId, fromdate, todate, currencyId);

            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in data.Select(x => x))
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;
                SalesReportModel.TicketNumber = item.TicketNumber;
                SalesReportModel.IssuedDate = item.IssueDate;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash + (decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable;

                SalesReportModel.AgentName = item.Agent;
                SalesReportModel.serviceProviderName = item.ServiceProviderName;
                SalesReportModel.issueFrom = item.IssueFrom;
                SalesReportModel.AgentId = item.AgentId;
                
                var agentinfo = agencyProvider.GetAgentInfo(item.AgentId);
                SalesReportModel.AgentCode = agentinfo.AgentCode;

                var distributor = distributorManagementProvider.GetDistributorByDistributorId(agentinfo.DistributorId);
                if (distributor != null)
                {
                    SalesReportModel.DistributorName = distributor.DistributorName + "(" + distributor.DistributorCode + ")";
                }
                var branchOffice = branchOfficeManagementProvider.GetBranchOfficeInfo(agentinfo.BranchOfficeId);
                if (branchOffice != null)
                {
                    SalesReportModel.BranchOfficeName = branchOffice.BranchOfficeName + "(" + branchOffice.BranchOfficeCode + ")";
                }

                model.Add(SalesReportModel);

            }
            return model;
        }

        //for pagination//
        public IQueryable<SalesReportModel> GetSalesReportByPagination(SalesReportModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.salesReportDetails.Count();
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
            IQueryable<SalesReportModel> pagingdata = m.salesReportDetails.Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }

        public List<AirlineTypes> GetAirlineTypesList()
        {
            return ent.AirlineTypes.Where(x => x.isActive == true).ToList();
        }

        public List<Currencies> GetCurrienciesList()
        {
            return ent.Currencies.ToList();
        }



        //////////////////////////For IndianLcc Report/////////////////////////////////
        public List<SalesReportModel> GetIndianLccSalesReport(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {

            var data = ent.TBO_Air_GetAgentBillingStatement(AgentId, fromdate, todate, currencyId).ToList();

            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in data)
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineId = item.AirlineId;
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash + (Decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash;


                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable;
                model.Add(SalesReportModel);

            }
            return model;
        }


        public List<SalesReportModel> GetIndianLccSalesReportDetails(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {

            var data = ent.Air_GetAgentBillingStatementDetails(AgentId, fromdate, todate, currencyId).Where(x => x.ServiceProviderName == "TBO");

            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in data.Select(x => x))
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;
                SalesReportModel.TicketNumber = item.TicketNumber;
                SalesReportModel.IssuedDate = item.IssueDate;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash + (decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable;

                SalesReportModel.AgentName = item.Agent;
                SalesReportModel.serviceProviderName = item.ServiceProviderName;
                SalesReportModel.issueFrom = item.IssueFrom;

                model.Add(SalesReportModel);

            }
            return model;
        }



        public List<SalesReportModel> GetSalesReportSummary(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            List<Air_GetAgentBillingStatement_Result> data = ent.Air_GetAgentBillingStatement(AgentId, fromdate, todate, currencyId).ToList();
            var ts = SessionStore.GetTravelSession();
            var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            var resultSummary = agentsByDistributor.SelectMany(b => data.Where(x => x.Agentid == b.AgentId));
            List<SalesReportModel> model = new List<SalesReportModel>();
            foreach (var item in resultSummary)
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineId = item.AirlineId;
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash + (Decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable;
                SalesReportModel.AgentId = item.Agentid;
                model.Add(SalesReportModel);
            }
            return model;
        }



        public List<SalesReportModel> GetDistributorSalesReportSummary(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {
           

            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();

            List<Air_GetAgentBillingStatement_Result> data = ent.Air_GetAgentBillingStatement(null, fromdate, todate, currencyId).ToList();

            var ts = SessionStore.GetTravelSession();
            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);

            List<Air_GetAgentBillingStatement_Result> result = new List<Air_GetAgentBillingStatement_Result>();


            if (AgentId != null)
            {
                int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(AgentId.Value);
                var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(appUserId);

                result = agentsByDistributor.SelectMany(b => data.Where(x => x.Agentid == b.AgentId)).ToList();

            }
            else
            {
                result = agentsByBranchOffice.SelectMany(b => data.Where(x => x.Agentid == b.AgentId)).ToList();

            }






            List<SalesReportModel> model = new List<SalesReportModel>();




            foreach (var item in result)
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineId = item.AirlineId;
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash + (Decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatement_Cash = TotalAgentBillingStatement_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatement_Tax = TotalAgentBillingStatement_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatement_Commission = TotalAgentBillingStatement_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatement_Payable = TotalAgentBillingStatement_Payable;
                SalesReportModel.AgentId = item.Agentid;
                model.Add(SalesReportModel);
            }
            return model;
        }

        public List<SalesReportModel> GetDistributorSalesReportSummaryDetails(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();

            List<Air_GetAgentBillingStatementDetails_Result> data = ent.Air_GetAgentBillingStatementDetails(null, fromdate, todate, currencyId).ToList();

            var ts = SessionStore.GetTravelSession();
            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);
          
            List<Air_GetAgentBillingStatementDetails_Result> result = new List<Air_GetAgentBillingStatementDetails_Result>();


            if (AgentId != null)
            {
                int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(AgentId.Value);
                var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(appUserId);

                result = agentsByDistributor.SelectMany(b => data.Where(x => x.AgentId == b.AgentId)).ToList();

            }
            else
            {
                result = agentsByBranchOffice.SelectMany(b => data.Where(x => x.AgentId == b.AgentId)).ToList();

            }






            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in result)
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;
                SalesReportModel.TicketNumber = item.TicketNumber;
                SalesReportModel.IssuedDate = item.IssueDate;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash + (decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable;

                SalesReportModel.AgentName = item.Agent;
                SalesReportModel.serviceProviderName = item.ServiceProviderName;
                SalesReportModel.issueFrom = item.IssueFrom;
                SalesReportModel.AgentId = item.AgentId;
                SalesReportModel.AgentCode = new ATLTravelPortal.Areas.Airline.Repository.BookedTicketReportProvider().GetAgentCodeById(item.AgentId);

                model.Add(SalesReportModel);

            }
            return model;
        }










        public List<SalesReportModel> GetSalesReportSummaryDetails(int? AgentId, DateTime? fromdate, DateTime? todate, int AirlinesTypeId, int? currencyId)
        {
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();

            List<Air_GetAgentBillingStatementDetails_Result> data = ent.Air_GetAgentBillingStatementDetails(AgentId, fromdate, todate, currencyId).ToList();

            var ts = SessionStore.GetTravelSession();

            var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            var resultSummary = agentsByDistributor.SelectMany(b => data.Where(x => x.AgentId == b.AgentId));


            List<SalesReportModel> model = new List<SalesReportModel>();

            foreach (var item in resultSummary)
            {
                var SalesReportModel = new SalesReportModel();
                SalesReportModel.AirlineCode = item.Code;
                SalesReportModel.AirlineName = item.Name;
                SalesReportModel.TicketNumber = item.TicketNumber;
                SalesReportModel.IssuedDate = item.IssueDate;

                SalesReportModel.Cash = item.Cash;
                TotalAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash + (decimal)item.Cash;
                SalesReportModel.SumAgentBillingStatementDetails_Cash = TotalAgentBillingStatementDetails_Cash;

                SalesReportModel.Tax = (decimal)item.Tax;
                TotalAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax + (decimal)item.Tax;
                SalesReportModel.SumAgentBillingStatementDetails_Tax = TotalAgentBillingStatementDetails_Tax;

                SalesReportModel.Commission = (decimal)item.Commission;
                TotalAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission + (decimal)item.Commission;
                SalesReportModel.SumAgentBillingStatementDetails_Commission = TotalAgentBillingStatementDetails_Commission;

                SalesReportModel.Payable = (decimal)item.Payable;
                TotalAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable + (decimal)item.Payable;
                SalesReportModel.SumAgentBillingStatementDetails_Payable = TotalAgentBillingStatementDetails_Payable;

                SalesReportModel.AgentName = item.Agent;
                SalesReportModel.serviceProviderName = item.ServiceProviderName;
                SalesReportModel.issueFrom = item.IssueFrom;
                SalesReportModel.AgentId = item.AgentId;
                SalesReportModel.AgentCode = new ATLTravelPortal.Areas.Airline.Repository.BookedTicketReportProvider().GetAgentCodeById(item.AgentId);
                model.Add(SalesReportModel);

            }
            return model;
        }


    }
}