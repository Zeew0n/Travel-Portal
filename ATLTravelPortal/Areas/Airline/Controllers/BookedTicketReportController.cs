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
   [PermissionDetails(View = "Index",Delete="Cancel", Order = 2)]

    public class BookedTicketReportController : Controller
    {
        //
        // GET: /BookedTicketReport/

        PNRDetailProvider _provider = new PNRDetailProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        BookedTicketReportProvider ser = new BookedTicketReportProvider();

        public ActionResult Index(int? pageNo, int? flag, DateTime? FromDate, DateTime? ToDate, int? id)
        {
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            BookedTicketModels model = new BookedTicketModels();
            if (FromDate == null && ToDate == null)
            {

                model.FromDate = DateTime.Now.AddDays(-15);
                model.ToDate = DateTime.Now;
                model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            }
            else
            {
                model.FromDate = FromDate;
                model.ToDate = ToDate;
                model.BookedTicketList = ser.ListBookedReport(id, model.FromDate, model.ToDate);
            }



           

            //int currentPageNo = 0; int numberOfPage = 0;
            //if (pageNo == null)
            //    pageNo = 1;

            //model.BookedTicketList = ser.GetBookedTicketReportByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            //ViewData["TotalPages"] = numberOfPage;
            //ViewData["CurrentPage"] = currentPageNo;

          
            return View(model);
        }

      

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, BookedTicketModels model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);

           // model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);

            //int currentPageNo = 0; int numberOfPage = 0;
            //if (pageNo == null)
            //    pageNo = 1;

            //model.BookedTicketList = ser.GetBookedTicketReportByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            //ViewData["TotalPages"] = numberOfPage;
            //ViewData["CurrentPage"] = currentPageNo;

            //export
            GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.BookedTicketList.Select(m => new
                    {
                        Brach_Office=m.BranchOfficeName,
                        Distributor=m.DistributorName,
                        Agent_Name = m.AgentName,
                        GDSReferenceNumber = m.GDSRefrenceNumber,
                        PassengerName = m.PassengerName,
                        Sector = m.Sector,
                        Flight_Date = m.FlightDate,
                        BookedOn = m.BookedOn,
                        BookedBy = m.BookedBy
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Booked Ticket");
                }
                catch
                {
                }
            }

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return View(model);
        }

        
        public ActionResult Issue(long Id, int AgentId, DateTime FromDate, DateTime ToDate, int AType)
        {
            BookedTicketModels model = new BookedTicketModels();

          

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ser.Issue(Id,ts.AppUserId);
          
            model.AgentId = AgentId;
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            model.AirlineTypesId = AType;

            model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            return View("Index",model);
        }

        //public ActionResult Cancel(long Id, int AgentId, DateTime FromDate, DateTime ToDate, int AType)
        //{
        //    BookedTicketModels model = new BookedTicketModels();
                       

        //    ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
        //    ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

        //    var ts = (TravelSession)Session["TravelPortalSessionInfo"];
        //    ser.Cancel(Id, ts.AppUserId);
        //    model.AgentId = AgentId;
        //    model.FromDate = FromDate;
        //    model.ToDate = ToDate;
        //    model.AirlineTypesId = AType;

        //    model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate, model.AirlineTypesId);
        //    return View("Index", model);
        //}



        [HttpGet]
        public ActionResult Cancel(int id)
        {
            PNRsDetailsModel pnrdetails = new PNRsDetailsModel();
            pnrdetails.pnrmodel = _provider.GetPNRDetail(id);
            pnrdetails.pnrsegemnetmodel = _provider.GetPNRSegmentList(id);
            pnrdetails.pnrpassengermodel = _provider.GetPassengersList(id);

           // ViewData["isAlreadyCancelled"] = _provider.isAlreadyCanceledPNR(id);

            return View(pnrdetails);

        }

        [HttpPost]
        public ActionResult Cancel(long id, string PNR, string PassName, string AgentName, string City, DateTime BookedDate, DateTime FromDate, DateTime ToDate, int AgentId)
        {

            var ts = SessionStore.GetTravelSession();


            BookedTicketModels model = new BookedTicketModels();

            PNRsDetailsModel pnrdetails = new PNRsDetailsModel();
            pnrdetails.pnrmodel = _provider.GetPNRDetail((int)id);
            pnrdetails.pnrsegemnetmodel = _provider.GetPNRSegmentList((int)id);
            pnrdetails.pnrpassengermodel = _provider.GetPassengersList((int)id);
           
             _provider.CancelPNR(id, ts.AppUserId);

             ser.SendCanceledEmail(id, PNR, PassName, AgentName, City, BookedDate);

             model.PNRId = id;
             model.GDSRefrenceNumber = PNR;
             model.PassengerName = PassName;
             model.AgentName = AgentName;
             model.Sector = City;
             model.BookedOn = BookedDate;
             model.FromDate = FromDate;
             model.ToDate = ToDate;
             model.AgentId = AgentId;

             model.BookedTicketList = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);

             ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
             ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

            // return View("Index", model);
             return RedirectToAction("Index", new { FromDate = model.FromDate, ToDate = model.ToDate, id = model.AgentId });

           // return RedirectToAction("Index");
        }


        public ExportModel GetExportTypeClicked(ExportModel Expmodel, FormCollection frm)
        {
            if (frm["ExportTypeExcel.x"] != null && frm["ExportTypeExcel.y"] != null)
                Expmodel.ExportTypeExcel = "true";

            if (frm["ExportTypeWord.x"] != null && frm["ExportTypeWord.y"] != null)
                Expmodel.ExportTypeWord = "true";

            if (frm["ExportTypePdf.x"] != null && frm["ExportTypePdf.y"] != null)
                Expmodel.ExportTypePdf = "true";

            return Expmodel;
        }

        

    }
}
