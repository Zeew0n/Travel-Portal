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
    public class WaitListRequestController : Controller
    {
        WaitListRequestProvider ser = new WaitListRequestProvider();
        BookedTicketReportController crtBKT = new BookedTicketReportController();

        [HttpGet]
        public ActionResult Index(int? pageNo, int? flag)
        {
            WaitListRequestModel model = new WaitListRequestModel();
            model.WaitListRequestList = ser.WaitListRequestList();

            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;

            model.WaitListRequestList = ser.GetWaitListRequestByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, WaitListRequestModel model, FormCollection frm, int? pageNo, int? flag)
        {
            model.WaitListRequestList = ser.WaitListRequestList();

            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;

            model.WaitListRequestList = ser.GetWaitListRequestByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;



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

                    var exportData = model.WaitListRequestList.Select(m => new
                    {
                        GDSReferenceNumber = m.GDSRefrenceNumber,
                        PassengerName = m.PassengerName,
                        Sector = m.Sector,
                        BookedOn = m.BookedOn,
                        BookedBy = m.BookedBy
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "WaitListRequest");
                }
                catch
                {
                }
            }

           
            return View();
        }
             

        public ActionResult Confirm(long Id)
        {
            WaitListRequestModel model = new WaitListRequestModel();

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ser.Confirm(Id, ts.AppUserId);

            model.WaitListRequestList = ser.WaitListRequestList();
            return View("Index", model);
        }

        public ActionResult Cancel(long Id)
        {
            WaitListRequestModel model = new WaitListRequestModel();

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ser.Cancel(Id, ts.AppUserId);

            model.WaitListRequestList = ser.WaitListRequestList();
            return View("Index", model);
        }

        public ActionResult Close(long Id)
        {
            WaitListRequestModel model = new WaitListRequestModel();

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ser.Close(Id, ts.AppUserId);
           
            model.WaitListRequestList = ser.WaitListRequestList();
            return View("Index", model);
        }  

    }
}
