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

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]


    public class SectorSalesController : Controller
    {
        //
        // GET: /SectorSales/
        BookedTicketReportController crtBKT = new BookedTicketReportController();
     
       
        SectorSalesProvider ser = new SectorSalesProvider();
        [HttpGet]
        public ActionResult Index(int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ViewData["Currencies"] = new SelectList(ser.GetCurrenciesList(), "CurrencyId", "CurrencyCode");

            SectorSalesModel model = new SectorSalesModel();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;
           
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, SectorSalesModel model, FormCollection frm, int? pageNo, int? flag)
        {

            model.SectorSalesList = ser.SectorSalesList(model.FromDate, model.ToDate, model.CurrencyId);

            //export

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

                    var exportData = model.SectorSalesList.Select(m => new
                    {
                        MPNRId = m.MPNRId,
                        GDS_Ref = m.GDSReferenceNumber,
                        Service_Provider = m.ServiceProviderName,
                        Airline = m.AirlineCode,
                        Sector = m.Sector,
                        Class = m.Class,
                        Ticket_Number = m.TicketNumber,
                        Admin_Amount = m.AdminAmount,
                        Agent_Amount = m.AgentAmount,
                        Branch_Amount = m.BranchAmount,
                        Distributor_Amount = m.DistributorAmount,
                        Booked_Date = TimeFormat.DateFormat(m.CreatedDate.ToString()),
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "SectorSales ");

                }
                catch
                {
                }
            }

            ViewData["Currencies"] = new SelectList(ser.GetCurrenciesList(), "CurrencyId", "CurrencyCode");

            return View(model);
        }

        [HttpPost]
        public JsonResult FindAirline(string searchText, int maxResult)
        {
            var result = ser.GetAirline(searchText, maxResult);
            return Json(result);
        }
    }
}
