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
    public class BranchOfficePendingBookingController : Controller
    {
        //
        // GET: /Airline/PendingBooking/
        
        PendingBookingProvider ser = new PendingBookingProvider();
        BookedTicketReportController bkt = new BookedTicketReportController();
        ATLTravelPortal.Areas.Airline.Repository.GeneralProvider defaultProvider = new ATLTravelPortal.Areas.Airline.Repository.GeneralProvider();
        ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();

        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {
            var ts = SessionStore.GetTravelSession();

           // var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.AgentId);

            ViewData["Agents"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");

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

            //var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);
            //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            //model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);


            var details = ser.ListPendingBookintReport(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);
            var result = details.Where(x => x.BrachOfficeId == ts.LoginTypeId);
            model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, PendingBookingModel model, FormCollection frm, int? page)
        {
            var ts = SessionStore.GetTravelSession();
            int defaultPageSize = 30;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagentProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            var details = ser.ListPendingBookintReport(null, model.FromDate, model.ToDate);
            if (model.AgentId != null)
            {
                //int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(model.AgentId.Value);
                //var agentsByDistributor = distributorManagentProvider.GetAllAgentsByDistributorId(appUserId);
                //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize); 


                var result = details.Where(x => x.DistributorId == model.AgentId);
                model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize); 
            }
            else
            {
                //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);

                var result = details.Where(x => x.BrachOfficeId == ts.LoginTypeId);
                model.PendingBookingList = result.ToPagedList(currentPageIndex, defaultPageSize);
            }
         
           

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
            ViewData["Agents"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(model);
        }

    }
}
