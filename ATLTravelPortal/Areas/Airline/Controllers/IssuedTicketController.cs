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
    [PermissionDetails(View = "Index", Order = 2)]

    public class IssuedTicketController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        IssuedTicketProvider ser = new IssuedTicketProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            IssuedTicketModel model = new IssuedTicketModel();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;
          //  model.IssuedTicketList = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);

            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            model.IssuedTicketList = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);


            return View(model);
        }

       

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, IssuedTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            model.IssuedTicketList = ser.ListIssuedTicketReport(model.AgentId, model.FromDate, model.ToDate);


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
                        Brach_Office=m.BranchOfficeName,
                        Distributor=m.DistributorName,
                        Agent_Name = m.AgentName,
                        Passenger_Name = m.PassengerName,
                        No_of_Pax = m.NoOfPax,
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
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return View(model);
        }



    }
}
