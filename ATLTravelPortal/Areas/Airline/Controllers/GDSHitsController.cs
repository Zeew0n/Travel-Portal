using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class GDSHitsController : Controller
    {
        //
        // GET: /GDSHits/
        GDSHitsProvider pro = new GDSHitsProvider();
        public ActionResult Index()
        {
           GDSHitsModel model = new GDSHitsModel();

           model.FromDate = DateTime.Now.AddDays(-30);
           model.ToDate = DateTime.Now;

           model.GDSHitLists = pro.GetGDSHitCount(model.FromDate, model.ToDate, model.hdfAgentId);
           return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, GDSHitsModel model, FormCollection frm)
        {
            model.GDSHitLists = pro.GetGDSHitCount(model.FromDate, model.ToDate, model.hdfAgentId);

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

                    var exportData = new List<TransactionHitsExportModel>();

                    foreach (var item in model.GDSHitLists)
                    {
                        var rpt = new TransactionHitsExportModel();
                        rpt.GDSHitsCount = item.GDSHitCount;
                        rpt.TransactionName = item.TransactionName;
                        exportData.Add(rpt);
                    }
                    App_Class.AppCollection.Export(Expmodel, exportData, "Transaction_Hits");
                }
                catch
                {
                }
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            GDSHitsModel model = new GDSHitsModel();
            model.AgentName = pro.GetAgentName(id);
            model.GDSHitLists = pro.GetGDSHitCountDetails(id);
            return View(model);
        }

    }
}
