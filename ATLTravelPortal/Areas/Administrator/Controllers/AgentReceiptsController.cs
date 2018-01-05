using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class AgentReceiptsController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        AgentReceiptsProvider agentReceiptsProvider = new AgentReceiptsProvider();
        AgentCLApprovedProvider agentclaapprovedprovider = new AgentCLApprovedProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();

        [HttpGet]
        public ActionResult Index(int? page, int? pageNo, int? flag, DateTime? FromDate, DateTime? ToDate, int? UserID, int? DistributorID, int? AgentId)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 50;
            AgentCLApprovedModel model = new AgentCLApprovedModel();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            if (FromDate == null)
                model.FromDate = DateTime.Now.AddDays(-15);
            else
                model.FromDate = FromDate.Value;
            if (ToDate == null)
                model.ToDate = DateTime.Now;
            else
                model.ToDate = ToDate.Value;



            model.UsersOption = new SelectList(defaultProvider.GetUserList(), "AppUserId", "FullName");
            model.BranchOfficeOption = new SelectList(branchOfficeManagementProvider.GetAll(), "BranchOfficeId", "BranchOfficeName", model.BranchOfficeId);
            model.DistributorOption = new SelectList(agentclaapprovedprovider.GetAllDistributorsByBranchOfficeId(model.BranchOfficeId ?? 0), "DistributorId", "DistributorName");
            model.AgentOption = new SelectList(agentclaapprovedprovider.GetAgentsByDistributorId(model.DistributorID ?? 0), "AgentId", "AgentName", model.AgentId);
            model.AgentReceiptList = agentReceiptsProvider.GetAgentCLApprovedList(FromDate != null ? FromDate.Value : model.FromDate, ToDate != null ? ToDate.Value : model.ToDate, model.UserID, model.DistributorID, model.AgentId).ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, AgentCLApprovedModel model, FormCollection frm, int? pageNo, int? flag, int? page)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 50;

            //export
            BookedTicketReportController crtBKT = new BookedTicketReportController();
            crtBKT.GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null && (Expmodel.ExportTypeExcel != null || Expmodel.ExportTypeWord != null || Expmodel.ExportTypeCSV != null || Expmodel.ExportTypePdf != null))
            {
                model.AgentCLApprovedListExport = agentReceiptsProvider.GetAgentCLApprovedList(model.FromDate, model.ToDate, model.UserID, model.DistributorID,model.AgentId);
                try
                {

                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = model.AgentCLApprovedListExport.Select(m => new
                    {
                        BranchOffice_Name = m.BranchOfficeName,
                        Distributor_Name = m.DistributorName,
                        Agent_Name = m.AgentName,
                        Agent_Code = m.AgentCode,
                        Currency = m.Currency,
                        Amount = m.Amount,
                        Narration = m.Comments,
                        VoucherNo = m.VoucherNo,
                        CreatedBy = m.CheckedBy,
                        CreatedDate = m.CheckerDate
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "Agent Receipts");
                }
                catch
                {
                }
            }
            model.AgentReceiptList = agentReceiptsProvider.GetAgentCLApprovedList(model.FromDate, model.ToDate, model.UserID, model.DistributorID, model.AgentId).ToPagedList(currentPageIndex, defaultPageSize);
            model.UsersOption = new SelectList(defaultProvider.GetUserList(), "AppUserId", "FullName");
            model.BranchOfficeOption = new SelectList(branchOfficeManagementProvider.GetAll(), "BranchOfficeId", "BranchOfficeName", model.BranchOfficeId);
            model.DistributorOption = new SelectList(agentclaapprovedprovider.GetAllDistributorsByBranchOfficeId(model.BranchOfficeId ?? 0), "DistributorId", "DistributorName");
            model.AgentOption = new SelectList(agentclaapprovedprovider.GetAgentsByDistributorId(model.DistributorID ?? 0), "AgentId", "AgentName", model.AgentId);

            return View(model);
        }
    }
}
