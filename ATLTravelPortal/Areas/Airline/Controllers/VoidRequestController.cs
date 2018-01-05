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
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Details = "Details", Order = 2)]

    public class VoidRequestController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        PNRsModel _modPNR = new PNRsModel();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();
        FareModel _modFare = new FareModel();

        VoidRequestProvider ser = new VoidRequestProvider();


        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            VoidRequestModel model = new VoidRequestModel();
            model.VoidRequestList = ser.VoidListRequestList().ToPagedList(currentPageIndex,defaultPageSize);

            return View(model);
        }


        [HttpGet]
        public ActionResult Details(VoidRequestModel model, int? serid, Int64 id)
        {
            model.PNRId = id;
            model.isAgentWillPaycharge = true;
            model.ServiceProviderId = serid ?? 0;
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(long Id, VoidRequestModel model, FormCollection fs)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                if (fs.AllKeys.Contains("Confirm"))
                {
                    ser.Confirm(Id, model.AirlineCancellationCharge, model.ArihantCancellationCharge, model.isAgentWillPaycharge, 1, ts.AppUserId, model.ServiceProviderId);
                }
                else if (fs.AllKeys.Contains("Reject"))
                {
                    ser.Reject(Id, ts.AppUserId);
                }
            }
            catch
            {
                TempData["InfoMessage"] = "Cannot process your request.";
            }
            model.VoidRequestList = ser.VoidListRequestList().ToPagedList(1, int.MaxValue); ;
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

        public ActionResult Fare(int id)
        {
            _modFare = _provider.GetFare(id);
            return PartialView("VUC_Fare", _modFare);
        }


        [HttpGet]
        public ActionResult DomesticDetails(VoidRequestModel model, int? serid)
        {
            model.isAgentWillPaycharge = true;
            model.ServiceProviderId = serid ?? 0;
            return View(model);
        }

        [HttpPost]
        public ActionResult DomesticDetails(long Id, VoidRequestModel model, FormCollection fs)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            try
            {
                if (fs.AllKeys.Contains("Confirm"))
                {
                    ser.Confirm(Id, model.AirlineCancellationCharge, model.ArihantCancellationCharge, model.isAgentWillPaycharge, 1, ts.AppUserId, model.ServiceProviderId);
                }
                else if (fs.AllKeys.Contains("Reject"))
                {
                    ser.Reject(Id, ts.AppUserId);
                }
            }
            catch
            {
                TempData["InfoMessage"] = "Cannot process your request.";
            }
            model.VoidRequestList = ser.VoidListRequestList().ToPagedList(1,int.MaxValue);
            return View("Index", model);

        }

        public ActionResult DomesticPNR(int id)
        {
            _modPNR = _provider.GetIndianLccPNRDetail(id);
            return PartialView("VUC_PNR", _modPNR);
        }

        public ActionResult DomesticPNRSegment(int id)
        {
            _modPNRSeg.PNRSegmentsList = _provider.GetIndianLccPNRSegmentList(id);
            return PartialView("VUC_PNRSegment", _modPNRSeg);
        }

        public ActionResult DomesticPNRPassenger(int id)
        {
            _modPassenger.PassengersList = _provider.GetIndianLccPassengersList(id);
            return PartialView("VUC_PNRPassenger", _modPassenger);
        }
        public ActionResult DomesticFare(int id)
        {
            _modFare = _provider.GetIndianLccFare(id);
            return PartialView("VUC_Fare", _modFare);
        }





    }
}
