using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class PurchaseSalesReportController : Controller
    {
        PurchaseSalesReportRepository PurchaseSalesReportRepository = new PurchaseSalesReportRepository();

        public ActionResult Index()
        {
            PurchaseSalesReportModel model = new PurchaseSalesReportModel();
            model.CurrencyList = PurchaseSalesReportRepository.GetCurrency();

            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, PurchaseSalesReportModel model, FormCollection frm)
        {
            model.PurchaseList = PurchaseSalesReportRepository.GetPurchaseList(model.CurrencyID, model.FromDate, model.ToDate);

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
                    int count = 1;
                    var exportData = model.PurchaseList.Select(m => new
                    {
                        SN = count++,
                        Branch_Name = m.BranchName,
                        Distributor_Name = m.DistributorName,
                        Agent_Name = m.AgentName,
                        Service_Provider = m.ServiceProvider,
                        Airline = m.Ariline,
                        Sector=m.Sector,
                        Admin_Purchase = m.AdminPurchase,
                        Admin_Sales = m.AdminSales,
                        Branch_Purchase = m.BranchPurchase,
                        Branch_Sales = m.BranchSales,
                        Distributor_Purchase = m.DistributorPurchase,
                        Distributor_Sales = m.DistributorSales,
                        Agent_Purchase = m.AgentPurchase,
                        Agent_Sales = m.AgentSales
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Purchase Sales Report");
                }
                catch
                {
                }
            }
            model.CurrencyList = PurchaseSalesReportRepository.GetCurrency();
            return View(model);
        }
    }
}
