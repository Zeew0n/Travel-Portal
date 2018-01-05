using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class TicketStatusHistoryController : Controller
    {
        TicketStatusHistoryRepository TicketStatusHistoryRepository = new TicketStatusHistoryRepository();

        public ActionResult Index()
        {
            TicketStatusHistoryModel model = new TicketStatusHistoryModel();
            //model.TicketStatusHistoryList = TicketStatusHistoryRepository.GetTicketStatusHistory(FromDate,ToDate);
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ATLTravelPortal.Areas.Airline.Models.ExportModel Expmodel, DateTime FromDate, DateTime ToDate,FormCollection frm)
        {
           TicketStatusHistoryModel model = new TicketStatusHistoryModel();
           BookedTicketReportController crtBKT = new BookedTicketReportController();
           model.TicketStatusHistoryList = TicketStatusHistoryRepository.GetTicketStatusHistory(FromDate,ToDate);
          
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

                   var exportData = model.TicketStatusHistoryList.Select(m => new
                   {
                      Branch = m.Branch,
                      Distributor = m.Distributor,
                      Agent = m.Agent,
                      Airline = m.Airline,
                      Sector = m.Sector,
                      Status = m.Status,
                      ServiceProvider = m.ServiceProviderName
                   });
                   App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
               }
               catch
               {
               }
           }
            return View(model);
        }

       
        
    }
}
