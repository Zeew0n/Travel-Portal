using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    //  [PermissionDetails(View = "Index", Order = 2)]
    public class DistributorCancelledVoidTicketController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        CancelledVoidTicketProvider ser = new CancelledVoidTicketProvider();
        BookedTicketReportController bktctrl = new BookedTicketReportController();
        ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();

        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();
            //var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = defaultProvider.GetAgentList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            CancelledVoidTicketModel model = new CancelledVoidTicketModel();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;
            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            //var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());

            var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);
            model.CancelledVoidTicketList = result;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, CancelledVoidTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();
            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            //var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            var details = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);

            model.CancelledVoidTicketList = result;

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
            //var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = defaultProvider.GetAgentList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            return View(model);
        }
    }
}
