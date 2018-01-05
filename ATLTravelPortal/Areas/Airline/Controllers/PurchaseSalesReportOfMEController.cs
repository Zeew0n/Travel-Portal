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
    [PermissionDetails(View = "Index", Order = 2)]

    public class PurchaseSalesReportOfMEController : Controller
    {
        PurchaseSalesReportOfMERepository PurchaseSalesReportOfMERepository = new PurchaseSalesReportOfMERepository();
        BookedTicketReportController ctrlBKT = new BookedTicketReportController();
        public ActionResult Index()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            PurchaseSalesReportOfMEModel model = new PurchaseSalesReportOfMEModel();
            model.AppUserId = obj.AppUserId;
            model.UserTypeId = obj.UserTypeId;
            if (obj.UserTypeId == 4)
            {
                model.MENameList = PurchaseSalesReportOfMERepository.GetMENameOnly(model.AppUserId, model.UserTypeId);
            }
            else
            {
                model.MENameList = PurchaseSalesReportOfMERepository.GetMEName();
            }
            model.CurrencyList = PurchaseSalesReportOfMERepository.GetCurrency();
            return View(model);
        }

       
        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, FormCollection frm,PurchaseSalesReportOfMEModel model)
        {
            model.PurchaseSalesReportOfMElist = PurchaseSalesReportOfMERepository.GetPurchaseSalesReportOfME(model);
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
                    var count = 1;
                    var exportData = model.PurchaseSalesReportOfMElist.Select(m => new
                    {

                        SNo = count++,
                       Agent_Name = m.AgentName,
                       Purchase = m.Purchase,
                       Sales = m.Sales,
                       Receipt = m.Receipt
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Purchase Sales Report Of ME's");

                }
                catch (Exception ex)
                {
                    TempData["ActionResponse"] = ex.Message;
                }
            }
            model.MENameList = PurchaseSalesReportOfMERepository.GetMEName();
            model.CurrencyList = PurchaseSalesReportOfMERepository.GetCurrency();
            return View(model);
        }
        
       
    }
}
