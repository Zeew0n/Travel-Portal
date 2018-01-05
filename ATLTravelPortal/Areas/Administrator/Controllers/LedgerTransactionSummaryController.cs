using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Airline;
using ATLTravelPortal.Areas.Airline.Controllers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class LedgerTransactionSummaryController : Controller
    {
        LedgerTransactionSummaryProvider ledgerTransactionSummaryProvider = new LedgerTransactionSummaryProvider();
        public ActionResult Index()
        {
            LedgerTransactionSummaryModel model = new LedgerTransactionSummaryModel();
            var ts = SessionStore.GetTravelSession();
            model.DateFrom = DateTime.Now.AddDays(-15);
            model.DateTo = DateTime.Now;

            model.ProductsOption = ledgerTransactionSummaryProvider.GetProductOption();
            model.CurrencyOption = ledgerTransactionSummaryProvider.GetCurrencyOption();
            model.LedgerOfOption = ledgerTransactionSummaryProvider.GetLedgerOfOption();
            model.FilterTypeOption = ledgerTransactionSummaryProvider.GerFilterTypeoption();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ATLTravelPortal.Areas.Airline.Models.ExportModel Expmodel, LedgerTransactionSummaryModel model, FormCollection frm)
        {
            model.LedgerTransactionList = ledgerTransactionSummaryProvider.GetSummeryOfLedgerTransactionList(model.ProductId , model.CurrencyId, model.LedgerOf, model.DateFrom, model.DateTo, model.FilterType , model.FilterValue);

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
                    int counter = 1;
                    var exportData = model.LedgerTransactionList.Select(m => new
                    {
                        SN = counter++,
                        Ledger_Id = m.LedgerId,
                        Ledger_Name = m.LedgerName,
                        Opening_Balance = m.OpeningBalance,
                        Dr = m.Dr,
                        Cr = m.Cr,
                        Closing_Balance = m.ClosingBalance

                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Ledger Transaction");
                }
                catch
                {
                }
            }
            model.ProductsOption = ledgerTransactionSummaryProvider.GetProductOption();
            model.CurrencyOption = ledgerTransactionSummaryProvider.GetCurrencyOption();
            model.LedgerOfOption = ledgerTransactionSummaryProvider.GetLedgerOfOption();
            model.FilterTypeOption = ledgerTransactionSummaryProvider.GerFilterTypeoption();

            return View(model);

        }
    }
}
