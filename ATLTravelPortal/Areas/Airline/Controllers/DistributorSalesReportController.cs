using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Index", Custom1 = "Index1", Order = 2)]
    public class DistributorSalesReportController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        SalesReportProvider ser = new SalesReportProvider();
        BookedTicketReportController ctrlBKT = new BookedTicketReportController();
        ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();
            var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);

            SalesReportModel model = new SalesReportModel();
            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            ViewData["Currency"] = defaultProvider.GetCurrencyList();

            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            
            var detailsSummary = ser.GetSalesReportSummary(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
            model.salesReportSummary = detailsSummary;

            var details = ser.GetSalesReportSummaryDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
            

            model.salesReportDetails = details;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, SalesReportModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();
            
            var detailsSummary = ser.GetSalesReportSummary(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
            

            model.salesReportSummary = detailsSummary;



            
            var details = ser.GetSalesReportSummaryDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
            model.salesReportDetails = details;
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
            var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            ViewData["Currency"] = defaultProvider.GetCurrencyList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index1(ExportModel Expmodel, SalesReportModel model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();

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

           
            var detailsSummary = ser.GetSalesReportSummary(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
           

            model.salesReportSummary = detailsSummary;


           
            var details = ser.GetSalesReportSummaryDetails(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId, model.Currency);
            model.salesReportDetails = details;

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
                        Agent_Name = m.AgentName,
                        Ticket_No = m.TicketNumber,
                        Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                        Cash = m.Cash,
                        Tax = m.Tax,
                        Comm = m.Commission,
                        Payable = m.Payable,
                        Service_Provider = m.serviceProviderName,
                        Issued_From = m.issueFrom

                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "SalesReport");

                }
                catch (Exception ex)
                {
                    TempData["ActionResponse"] = ex.Message;
                }
            }
            var agents = defaultProvider.GetAgentList().Where(x => x.CreatedBy == ts.AppUserId);

            ViewData["AgentList"] = new SelectList(agents, "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            return View(model);
        }
    }
}
