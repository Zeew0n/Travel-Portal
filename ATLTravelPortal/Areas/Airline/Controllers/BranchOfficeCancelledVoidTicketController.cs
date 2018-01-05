using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
  
    public class BranchOfficeCancelledVoidTicketController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        CancelledVoidTicketProvider ser = new CancelledVoidTicketProvider();
        BookedTicketReportController bktctrl = new BookedTicketReportController();
        ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();
        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();

           // var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.AgentId);

            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            CancelledVoidTicketModel model = new CancelledVoidTicketModel();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            //var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, 1);
            //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            //model.CancelledVoidTicketList = result;


            var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, 1);
            var result = details.Where(x => x.BranchOfficeId == ts.LoginTypeId);
            model.CancelledVoidTicketList = result;

            return View(model);

           
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, CancelledVoidTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();

            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagentProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            var details = ser.ListCancelledVoidTicketReport(null, model.FromDate, model.ToDate, 1);
            if (model.AgentId != null)
            {
                //int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(model.AgentId.Value);
                //var agentsByDistributor = distributorManagentProvider.GetAllAgentsByDistributorId(appUserId);
                //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.CancelledVoidTicketList = result;


                var result = details.Where(x => x.DistributorId ==model.AgentId);
                model.CancelledVoidTicketList = result;
            }
            else
            {
                //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.CancelledVoidTicketList = result;

                var result = details.Where(x => x.BranchOfficeId == ts.LoginTypeId);
                model.CancelledVoidTicketList = result;
            }


           

            //export
           bktctrl.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.CancelledVoidTicketList.Select(m => new
                    {
                        Agent_Name = m.AgentName,
                        GDS_PNR = m.GDSReferenceNumber,
                        Passenger_Name = m.PassengerName,
                        Sector = m.Sector,
                        Flight_Date = m.FlightDate,
                        Cancelled_On = m.CancelledOn
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "CancelledVoid_Report");
                }
                catch
                {
                }
            }

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(model);
        }

    }
}
