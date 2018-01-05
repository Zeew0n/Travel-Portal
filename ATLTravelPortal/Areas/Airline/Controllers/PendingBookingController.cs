using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class PendingBookingController : Controller
    {
        PendingBookingProvider ser = new PendingBookingProvider();
        BookedTicketReportController bkt = new BookedTicketReportController();


        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {

            ViewData["Agents"] = new SelectList(ser.GetAgentsList(), "AgentId", "AgentName");

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            PendingBookingModel model = new PendingBookingModel();
            if (FromDate == null && ToDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-15);
                model.ToDate = GeneralRepository.CurrentDateTime();
            }
            else
            {
                model.FromDate = FromDate;
                model.ToDate = ToDate;
            }
            model.PendingBookingList = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, PendingBookingModel model, FormCollection frm, int? page)
        {
          
            int defaultPageSize = 30;
            int currentPageIndex = page.HasValue ? page.Value : 1;
          //  model.PendingBookingList
            model.PendingBookingList = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);

            //export
            bkt.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.PendingBookingList.Select(m => new
                    {
                        Brach_Office=m.BranchOfficeName,
                        Distributor=m.DistributorName,
                        Agent = m.AgentName,
                        Passenger_Name = m.PassegerName,
                        Sector = m.Sector,
                        GDS_PNR = m.GDSReferenceNumber,
                        Flight_Date = m.FlightDate,
                        Booked_On = TimeFormat.DateFormat(m.BookedOn.ToString()),
                        Booked_by = m.BookedBy
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "PendingBooking ");

                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                    TempData["ActionResponse"] = ex.Message;
                }
            }
            ViewData["Agents"] = new SelectList(ser.GetAgentsList(), "AgentId", "AgentName");
            return View(model);
        }

    }
}
