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
    public class BranchOfficeIssuedTicketController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        IssuedTicketProvider ser = new IssuedTicketProvider();
        ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();
            // var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.AgentId);
            IssuedTicketModel model = new IssuedTicketModel();


            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            //var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            //model.IssuedTicketList = result;


            var details = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.BracnOfficeId == ts.LoginTypeId);

            model.IssuedTicketList = result;

            return View(model);
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, IssuedTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();

            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagentProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            var details = ser.ListIssuedTicketReport(null, model.FromDate, model.ToDate);
            if (model.AgentId != null)
            {
                //int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(model.AgentId.Value);
                //var agentsByDistributor = distributorManagentProvider.GetAllAgentsByDistributorId(appUserId);
                //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.IssuedTicketList = result;

                var result = details.Where(x => x.DistributorId == model.AgentId);
                model.IssuedTicketList = result;
            }
            else
            {
                //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.IssuedTicketList = result;

                var result = details.Where(x => x.BracnOfficeId == ts.LoginTypeId);
                model.IssuedTicketList = result;
            }


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
                        No_Of_Pax= m.NoOfPax,
                        Airline_Code = m.AirlineCode,
                        Sector = m.Sector,
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
            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(model);
        }
    }
}
