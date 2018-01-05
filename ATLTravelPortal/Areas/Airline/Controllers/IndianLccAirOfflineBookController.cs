using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "BookOption", Delete = "Delete", Order = 2)]

    public class IndianLccAirOfflineBookController : Controller
    {        
        IndianLccAirOfflineBookProvider bookProvider = new IndianLccAirOfflineBookProvider();

        public ActionResult Index()
        {
            OfflineBookViewModel model = new OfflineBookViewModel();         
            model.OfflineBookTicketList = bookProvider.ListOfflineBook(null, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OfflineBookInputModel input)
        {         
            OfflineBookViewModel model = new OfflineBookViewModel();
            model.OfflineBookTicketList = bookProvider.ListOfflineBook(input.FromDate, input.ToDate);
            return View(model);
        }

        public ActionResult BookOption()
        {
            return PartialView("BookingOptionPartial");
        }

        [HttpPost]
        public ActionResult BookOption(OfflineBookInputModel input)
        {
            OfflineBookViewModel model = new OfflineBookViewModel();
            model.input = input;
            //model.BookingBourceList = new SelectList(EnumHelper.GetEnumDescription(typeof(IndianLccBookingSourceEnum)), "Name", "Description");
            model.BookingBourceList = new SelectList(bookProvider.GetOfflineBookingServiceSource(), "OfflineBookingServiceProviderId", "ServiceProvider");

            if (model.input.BookingType == "International")
            {
                model.SelectListCollection.CityList = bookProvider.GetCitiesByCityTypeId(1);
                model.PNRDetails.Add(new OfflineBookPNRDetailsModel());
                model.PNRDetails[0] = new OfflineBookPNRDetailsModel();
                model.PNRDetails[0].SegmentDetail.Add(new OfflineBookSegmentModel());
                model.PNRDetails[0].PassengerDetail.Add(new OfflineBookPassengerModel());
            }

            if (model.input.BookingType == "Domestic")
            {
                model.SelectListCollection.CityList = bookProvider.GetCitiesByCityTypeId(3);
                if (model.input.JourneyType == "OneWay")
                {
                    model.PNRDetails.Add(new OfflineBookPNRDetailsModel());
                    model.PNRDetails[0] = new OfflineBookPNRDetailsModel();
                    model.PNRDetails[0].SegmentDetail.Add(new OfflineBookSegmentModel());
                    model.PNRDetails[0].PassengerDetail.Add(new OfflineBookPassengerModel());
                }
                else
                {
                    model.PNRDetails.Add(new OfflineBookPNRDetailsModel());
                    model.PNRDetails.Add(new OfflineBookPNRDetailsModel());

                    model.PNRDetails[0] = new OfflineBookPNRDetailsModel();
                    model.PNRDetails[0].SegmentDetail.Add(new OfflineBookSegmentModel());
                    model.PNRDetails[0].PassengerDetail.Add(new OfflineBookPassengerModel());

                    model.PNRDetails[1] = new OfflineBookPNRDetailsModel();
                    model.PNRDetails[1].SegmentDetail.Add(new OfflineBookSegmentModel());
                    model.PNRDetails[1].PassengerDetail.Add(new OfflineBookPassengerModel());
                }
            }
            return View("VUC_Create", model);
        }

        public ActionResult Create(OfflineBookInputModel input)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OfflineBookViewModel model, string a)
        {
            var sessionDetail = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                model.UserDetail.AppUserId = sessionDetail.AppUserId;
                model.UserDetail.SessionId = sessionDetail.Id;

                var response = bookProvider.ActionSaveUpdate(model, "N");

                var message = new List<string>
                                  {
                                      response.ResponseMessage
                                  };
                return PartialView("~/Views/Shared/Menu/PVC_ResponseMessage.ascx", message);
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, Error Occurred While Booking!", e);               
            }
        }

        public ActionResult Edit(long id)
        {
            var model = bookProvider.GetBookedPNRList(id, null, null);
            //model.BookingBourceList = new SelectList(EnumHelper.GetEnumDescription(typeof(IndianLccBookingSourceEnum)), "Name", "Description");
            model.BookingBourceList = new SelectList(bookProvider.GetOfflineBookingServiceSource(), "OfflineBookingServiceProviderId", "ServiceProvider");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OfflineBookViewModel model)
        {
            //model.BookingBourceList = new SelectList(EnumHelper.GetEnumDescription(typeof(IndianLccBookingSourceEnum)), "Name", "Description");
            model.BookingBourceList = new SelectList(bookProvider.GetOfflineBookingServiceSource(), "OfflineBookingServiceProviderId", "ServiceProvider");
            model.TicketStatusId = bookProvider.GetTicketStatusId(model.PNRBookedList.FirstOrDefault().MPNRId);

            try
            {
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                var result = bookProvider.Edit(model);

                bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                EntityModel ent = new EntityModel();
                ent.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false,ts.AppUserId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(OfflineBookViewModel model)
        {
            var sessionDetail = (TravelSession)Session["TravelPortalSessionInfo"];
            bool checkId = bookProvider.CheckMPNRIdExist(model.PNRBookedList[0].MPNRId);
            if (checkId == true)

                bookProvider.Delete(model.PNRBookedList[0].MPNRId, sessionDetail.AppUserId);
            return RedirectToAction("Index");
           
        }
        public ActionResult List()
        {            
            return new EmptyResult();
        }

        public ActionResult Detail(long? id)
        {
            var model = bookProvider.GetBookedPNRList(id, null, null);
            return View(model);
        }
    }
}
