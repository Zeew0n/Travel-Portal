using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order=1)]
    [PermissionDetails(View = "Index", Details = "Details", Order = 2)]
    public class CancelRequestController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        PNRsModel _modPNR = new PNRsModel();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();
        FareModel _modFare = new FareModel();

        CancelRequestProvider ser = new CancelRequestProvider();


        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            CancelRequestModel model = new CancelRequestModel();
            model.CancelRequestList = ser.CancelListRequestList().ToPagedList(currentPageIndex,defaultPageSize);

            return View(model);
        }


        [HttpGet]
        public ActionResult Details(CancelRequestModel model,Int64 id)
        {
            model.PNRId = id;
            model.CommentList = ser.GetCommemtList(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(long Id, int serid, CancelRequestModel model, string CancelledTicket)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = ts.AppUserId;



            if (CancelledTicket == "Approve Cancel")
            {
                ser.Confirm(Id, 0, model.ArihantCancellationCharge, true, 1, ts.AppUserId, serid);
            }
            else
            {
                ser.RevertCancel(Id);
            }


         
            model.PNRId = Id;
            ser.CancelledTicketRemarks(model, CancelledTicket);

            model.CancelRequestList = ser.CancelListRequestList().ToPagedList(1,int.MaxValue);
            return View("Index", model);

        }

        
        public ActionResult PNR(int id)
        {
            _modPNR = _provider.GetPNRDetail(id);
            return PartialView("VUC_PNR", _modPNR);
        }

        
        public ActionResult PNRSegment(int id)
        {
            _modPNRSeg.PNRSegmentsList = _provider.GetPNRSegmentList(id);
            return PartialView("VUC_PNRSegment", _modPNRSeg);
        }

        
        public ActionResult PNRPassenger(int id)
        {
            _modPassenger.PassengersList = _provider.GetPassengersList(id);
            return PartialView("VUC_PNRPassenger", _modPassenger);
        }
    }
}
