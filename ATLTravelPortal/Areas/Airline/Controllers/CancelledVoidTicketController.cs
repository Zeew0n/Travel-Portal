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
    [PermissionDetails(View = "Index", Order = 2)]
    public class CancelledVoidTicketController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        CancelledVoidTicketProvider ser = new CancelledVoidTicketProvider();
        BookedTicketReportController bktctrl = new BookedTicketReportController();
        public ActionResult Index()
        {
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            CancelledVoidTicketModel model = new CancelledVoidTicketModel();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            model.CancelledVoidTicketList = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, 1);
            return View(model);           
        }


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, CancelledVoidTicketModel model, FormCollection frm, int? pageNo, int? flag)
        {

            if (model.FromDate != null)
                model.FromDate = model.FromDate.Value.Date;

            if (model.ToDate != null)
                model.ToDate = model.ToDate.Value.Date.AddHours(23).AddMinutes(59);

            model.CancelledVoidTicketList = ser.ListCancelledVoidTicketReport(model.AgentId, model.FromDate, model.ToDate, 1);

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
                        Brach_Office=m.BranchOfficeName,
                        Distributor=m.DistributorName,
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
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return View(model);
        }
    }
}
