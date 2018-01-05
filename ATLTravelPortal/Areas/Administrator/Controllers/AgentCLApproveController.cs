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

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Index", Order = 2)]
    public class AgentCLApproveController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        AgentCLApprovedProvider agentCLApprovedProvider = new AgentCLApprovedProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            AgentCLApprovedModel model = new AgentCLApprovedModel();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;
            if (ts.UserTypeId == 6)
                model.DistributorID = ts.LoginTypeId;
           

            model.AgentCLApprovedListExport = agentCLApprovedProvider.GetAgentCLApprovedList(model.FromDate, model.ToDate, model.UserID, model.DistributorID, model.AgentId);
            model.UsersOption = new SelectList(agentCLApprovedProvider.GetDistributorUsers(model.DistributorID), "AppUserId", "FullName");
            model.AgentOption = new SelectList(agentCLApprovedProvider.GetAgentsByDistributorId(model.DistributorID ?? 0), "AgentId", "AgentName", model.AgentId);
            return View(model);
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, AgentCLApprovedModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            if (ts.UserTypeId == 6)
                model.DistributorID = ts.LoginTypeId;
            model.AgentCLApprovedListExport = agentCLApprovedProvider.GetAgentCLApprovedList(model.FromDate, model.ToDate, model.UserID, model.DistributorID, model.AgentId);


            //export
            BookedTicketReportController crtBKT = new BookedTicketReportController();
            crtBKT.GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null && (Expmodel.ExportTypeExcel != null || Expmodel.ExportTypeWord != null || Expmodel.ExportTypeCSV != null || Expmodel.ExportTypePdf != null))
            {
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
                        Brach_Office = m.BranchOfficeName,
                        Distributor = m.DistributorName,
                        Agent_Name = m.AgentName,
                        Agent_Code = m.AgentCode,
                        Currency = m.Currency,
                        Amount = m.Amount,
                        Type = m.Type,
                        Requestion = m.Requestion,
                        Checker_Date = m.CheckerDate,
                        CheckerBy = m.CheckedBy
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "Issued Ticket");
                }
                catch
                {
                }
            }


            model.UsersOption = new SelectList(agentCLApprovedProvider.GetDistributorUsers(model.DistributorID), "AppUserId", "FullName");
            model.AgentOption = new SelectList(agentCLApprovedProvider.GetAgentsByDistributorId(model.DistributorID ?? 0), "AgentId", "AgentName", model.AgentId);
            return View(model);
        }
    }
}
