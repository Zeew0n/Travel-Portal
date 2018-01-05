using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Controllers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
   // [PermissionDetails(View = "Index", Order = 2)]
    public class DistributorIssuedTicketController : Controller
    {       
        GeneralProvider defaultProvider = new GeneralProvider();
        IssuedTicketProvider ser = new IssuedTicketProvider();
        ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            IssuedTicketModel model = new IssuedTicketModel();
            var ts = SessionStore.GetTravelSession();

            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);

            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;          

            //var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = defaultProvider.GetAgentList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");        


            //var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            //model.IssuedTicketList = result;

            var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);
            model.IssuedTicketList = result;

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, IssuedTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();        


            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            //var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());

            var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);
            model.IssuedTicketList = result;

            model.IssuedTicketList = result;


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

                    var exportData = model.IssuedTicketList.Select(m => new
                    {
                        Agent_Name = m.AgentName,
                        Passenger_Name = m.PassengerName,
                        No_Of_Pax = m.NoOfPax,
                        Airline_Code = m.AirlineCode,
                        Sector = m.Sector,
                       // Status = m.TicketStatusName,
                        GDS_PNR = m.GDSReferenceNumber,
                        Flight_Date = m.FlightDate,
                        Issued_On = m.IssuedOn,
                        Issued_By = m.IssuedBy,
                        Service_Provider = m.ServiceProviderName,
                        Created_By = m.CreatedBy,
                       
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Issued Ticket");
                }
                catch
                {
                }
            }

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
           // var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = defaultProvider.GetAgentList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            return View(model);
        }
    }
}
