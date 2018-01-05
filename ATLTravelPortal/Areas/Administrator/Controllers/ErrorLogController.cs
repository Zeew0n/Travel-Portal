using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 1)]
    public class ErrorLogController : Controller
    {
        //
        // GET: /Administrator/ErrorLog/
        ErrorLogProvider ser = new ErrorLogProvider();
        BookedTicketReportController bktController = new BookedTicketReportController();

        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {
            ErrorLogModel model = new ErrorLogModel();
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 500;

            //model.FromDate = FromDate != null ? FromDate : null;
            //model.ToDate = ToDate != null ? ToDate : null;

            if (FromDate == null && ToDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().Date;
                model.ToDate = GeneralRepository.CurrentDateTime().Date.AddHours(23).AddMinutes(59);
            }
            else
            {
                model.FromDate = FromDate;
                model.ToDate = ToDate.Value.Date.AddHours(23).AddMinutes(59);
            }

            model.ErrorLogList = ser.ListErrorLog( model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }




        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, ErrorLogModel model, FormCollection frm, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 500;


            if (model.FromDate != null)
                model.FromDate = model.FromDate.Value.Date;

            if (model.ToDate != null)
                model.ToDate = model.ToDate.Value.Date.AddHours(23).AddMinutes(59);

            model.ErrorLogList = ser.ListErrorLog(model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);

            //export
            bktController.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.ErrorLogList.Select(m => new
                    {
                        Time_Stamp = m.time_stamp,
                        Source = m.source,
                        Message = m.message,
                        Logger = m.logger
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Error Log");
                }
                catch
                {
                }
            }
          
            return View(model);
        }
    }
}
