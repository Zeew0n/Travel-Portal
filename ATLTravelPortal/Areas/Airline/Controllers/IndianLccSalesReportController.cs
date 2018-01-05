using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]

    public class IndianLccSalesReportController : Controller
    {
        //
        // GET: /Airline/IndianLccSalesReport/

        GeneralProvider defaultProvider = new GeneralProvider();
        SalesReportProvider ser = new SalesReportProvider();
        BookedTicketReportController ctrlBKT = new BookedTicketReportController();

        public ActionResult Index(int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            SalesReportModel model = new SalesReportModel();
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            model.salesReportSummary = ser.GetIndianLccSalesReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 1);

            model.salesReportDetails = ser.GetIndianLccSalesReportDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 1);

            return View(model);
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, SalesReportModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];



            model.salesReportSummary = ser.GetIndianLccSalesReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 1);
            model.salesReportDetails = ser.GetIndianLccSalesReportDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 1);


            //export
            ctrlBKT.GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {

                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = model.salesReportSummary.Select(m => new
                    {
                        Code = m.AirlineCode,
                        Cash = m.Cash,
                        Tax = m.Tax,
                        Comm = m.Commission,
                        Payable = m.Payable
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "SalesReport");

                }
                catch (Exception ex)
                {
                    TempData["ActionResponse"] = ex.Message;
                }
            }


            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            
            return View(model);

        }


        [HttpPost]
        public ActionResult Index1(ExportModel Expmodel, SalesReportModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            var agentId = frm["SalesAgentId"];
            if (agentId != "")
                model.AgentId = int.Parse(frm["SalesAgentId"]);
            else
                model.AgentId = null;


            var fromdate = frm["SalesFromDate"];
            if (fromdate != "")
                model.FromDate = DateTime.Parse(frm["SalesFromDate"]);
            else
                model.FromDate = null;

            var todate = frm["SalesToDate"];
            if (todate != "")
                model.ToDate = DateTime.Parse(frm["SalesToDate"]);
            else
                model.ToDate = null;

            var currency = frm["SalesCurrency"];
            if (currency != "")
                model.Currency = int.Parse(frm["SalesCurrency"]);
            else
                model.Currency = null;





            model.salesReportSummary = ser.GetIndianLccSalesReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 3);
            model.salesReportDetails = ser.GetIndianLccSalesReportDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, 3);


            //export
            ctrlBKT.GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {

                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = model.salesReportDetails.Select(m => new
                    {
                        Code = m.AirlineCode,
                        Name = m.AgentName,
                        Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                        Cash = m.Cash,
                        Tax = m.Tax,
                        Comm = m.Commission,
                        Payable = m.Payable,
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "SalesReport");

                }
                catch (Exception ex)
                {
                    TempData["ActionResponse"] = ex.Message;
                }
            }


            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            return View(model);

        }


    }
}
