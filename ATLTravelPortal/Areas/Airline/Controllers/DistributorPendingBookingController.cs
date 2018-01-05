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
    public class DistributorPendingBookingController : Controller
    {
        PendingBookingProvider ser = new PendingBookingProvider();
        BookedTicketReportController bkt = new BookedTicketReportController();
        ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();

        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {
            var ts = SessionStore.GetTravelSession();
            //var agents = ser.GetAgentsList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = ser.GetAgentsList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["Agents"] = new SelectList(agents, "AgentId", "AgentName");

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

            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            //var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());

            var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);
            model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, PendingBookingModel model, FormCollection frm, int? page)
        {
            int defaultPageSize = 30;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var ts = SessionStore.GetTravelSession();

            //var agentsByDistributor = distributorManagementProvider.GetAllAgentsByDistributorId(ts.AppUserId);
            //var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());

            var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.DistributorId == ts.LoginTypeId);

            model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);

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
            //var agents = ser.GetAgentsList().Where(x => x.CreatedBy == ts.AppUserId);
            var agents = ser.GetAgentsList().Where(x => x.DistributorId == ts.LoginTypeId);

            ViewData["Agents"] = new SelectList(agents, "AgentId", "AgentName");
            return View(model);
        }
    }
}
