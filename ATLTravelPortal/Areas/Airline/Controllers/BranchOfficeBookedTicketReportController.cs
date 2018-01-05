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


    public class BranchOfficeBookedTicketReportController : Controller
    {

        PNRDetailProvider _provider = new PNRDetailProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        BookedTicketReportProvider ser = new BookedTicketReportProvider();
        ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider branchOfficeManagementProvider = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();

            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);

            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            BookedTicketModels model = new BookedTicketModels();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            //var details = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
            //model.BookedTicketList = result;

            var details = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.BranchOfficeId == ts.LoginTypeId);
            model.BookedTicketList = result;

            return View(model);
        }



        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, BookedTicketModels model, FormCollection frm, int? pageNo, int? flag)
        {
            var ts = SessionStore.GetTravelSession();

            var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.LoginTypeId);
            ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider distributorManagentProvider = new ATLTravelPortal.Areas.Administrator.Repository.DistributorManagementProvider();
            var details = ser.ListBookedReport(null, model.FromDate, model.ToDate);
            if (model.AgentId != null)
            {
                //int appUserId = branchOfficeManagementProvider.GetAppUserIdByDistributorId(model.AgentId.Value);
                //var agentsByDistributor = distributorManagentProvider.GetAllAgentsByDistributorId(appUserId);
                //var result = agentsByDistributor.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.BookedTicketList = result;


                var result = details.Where(x => x.DistributorId == model.AgentId);
                model.BookedTicketList = result;
            }
            else
            {
                //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());
                //model.BookedTicketList = result;

                
                var result = details.Where(x => x.BranchOfficeId == ts.LoginTypeId);
                model.BookedTicketList = result;

            }

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
            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(model);
        }


        public ActionResult Issue(long Id, int AgentId, DateTime FromDate, DateTime ToDate, int AType)
        {
            var ts = SessionStore.GetTravelSession();
            BookedTicketModels model = new BookedTicketModels();

            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");
            ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");

            ser.Issue(Id, ts.AppUserId);

            model.AgentId = AgentId;
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            model.AirlineTypesId = AType;

            //var agentsByBranchOffice = branchOfficeManagementProvider.GetAllAgentsByBranchOfficeId(ts.AgentId);
            //var details = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            //var result = agentsByBranchOffice.SelectMany(b => details.Where(x => x.AgentId == b.AgentId).ToList());

            
            var details = ser.ListBookedReport(model.AgentId, model.FromDate, model.ToDate);
            var result = details.Where(x => x.BranchOfficeId == ts.LoginTypeId);

            model.BookedTicketList = result;

            return View("Index", model);
        }




        [HttpGet]
        public ActionResult Cancel(int id)
        {
            PNRsDetailsModel pnrdetails = new PNRsDetailsModel();
            pnrdetails.pnrmodel = _provider.GetPNRDetail(id);
            pnrdetails.pnrsegemnetmodel = _provider.GetPNRSegmentList(id);
            pnrdetails.pnrpassengermodel = _provider.GetPassengersList(id);

            return View(pnrdetails);

        }

        [HttpPost]
        public ActionResult Cancel(long id, string PNR, string PassName, string AgentName, string City, DateTime BookedDate)
        {

            var ts = SessionStore.GetTravelSession();

            PNRsDetailsModel pnrdetails = new PNRsDetailsModel();
            pnrdetails.pnrmodel = _provider.GetPNRDetail((int)id);
            pnrdetails.pnrsegemnetmodel = _provider.GetPNRSegmentList((int)id);
            pnrdetails.pnrpassengermodel = _provider.GetPassengersList((int)id);

            _provider.CancelPNR(id, ts.AppUserId);

            ser.SendCanceledEmail(id, PNR, PassName, AgentName, City, BookedDate);



            return RedirectToAction("Index");
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
