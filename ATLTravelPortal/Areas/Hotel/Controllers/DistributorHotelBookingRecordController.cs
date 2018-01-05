using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Repository;
using System.IO;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.PdfConverter;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class DistributorHotelBookingRecordController : Controller
    {
        public ActionResult Index(int? page)
        {
            HotelBookingRecordModel _model = new HotelBookingRecordModel();
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelMessageModel msg = new HotelMessageModel();
            HotelGeneralRepository.SetRequestPageRow();
            _model.Message = msg;
            _model.TabularList = _rep.GetDistributorPagedList(page);

            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, HotelBookingRecordModel model, FormCollection frm, int? page)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelMessageModel msg = new HotelMessageModel();
            HotelGeneralRepository.SetRequestPageRow();

            model.TabularList = _rep.GetDistributorPagedList(page);
            GetExportTypeClicked(Expmodel, frm);

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

                    var exportData = _rep.DistributorList().Select(m => new
                    {
                        SNo = m.SNo,
                        GuestName = m.GuestName,
                        Location = m.CityName + "" + m.CountryName,
                        HotelDetails = m.HotelName,
                        Rooms = m.NoOfRoom,
                        CheckIn = m.CheckInDate.ToString("MM/dd/yyyy"),
                        CheckOut = m.CheckOutDate.ToString("MM/dd/yyyy"),
                        BookingDate = m.CreatedDate.ToString("MM/dd/yyyy"),
                        Status = m.TicketStatus
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "HotelBookingRecord");

                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);


        }

        public ActionResult Detail(long id)
        {
            HotelBookDetailRepository _rep = new HotelBookDetailRepository();
            HotelBookingDetailModel _model = new HotelBookingDetailModel();
            _model = _rep.GetHotelBooking(id);
            return View(_model);
        }

        public ActionResult CancellationList(int? page)
        {
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelGeneralRepository.SetRequestPageRow();
            _model.TabularList = _rep.GetDistributorPagedList(page);
            return View(_model);
        }


        [HttpPost]
        public ActionResult CancellationList(ExportModel Expmodel, HotelBookingRecordModel model, FormCollection frm, int? page)
        {
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();

            _model.TabularList = _rep.GetPagedList(page);
            GetExportTypeClicked(Expmodel, frm);

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

                    var exportData = _rep.DistributorList().Select(m => new
                    {
                        SNo = m.SNo,
                        GuestName = (m.BookingDetail.Guests[0].Title) + " " + (m.BookingDetail.Guests[0].FirstName) + " " + m.BookingDetail.Guests[0].MiddleName + " " + m.BookingDetail.Guests[0].LastName,
                        HotelName = m.BookingDetail.HotelName,
                        RequestDate = m.CreatedOn.ToShortDateString(),
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "HotelBookingRecord");
                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);
        }

        public ActionResult Cancel(long? id)
        {
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            _model = _rep.FillForCancel(id);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Cancel(HotelBookingCancelModel model)
        {
            HotelBookingCancelRepository _Rep = new HotelBookingCancelRepository();
            model = _Rep.Cancel(model);
            return View("CancelDetail", model);
        }
        public ActionResult CancelDetail(long? id)
        {
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            _model = _rep.FillCanceledDetail(id);
            return View(_model);
        }


        public ActionResult PrintCancel(long? id)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            _model = _rep.CancelEmailFormat(id);
            return View(_model);
        }
        public ActionResult Itinerary(long? id)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            _model = _rep.Itineary(id);
            return View(_model);
        }
        public ActionResult PrintItineary(long? id)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            _model = _rep.Itineary(id);
            return View(_model);
        }
        public ActionResult EmailItinerary(long? id, string emal)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();

            if (ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.ValidateEmail(emal) == false)
            {
                _msg.ActionMessage = "Invalid Email address.";
                _msg.MsgNumber = 1001;
                _msg.MsgStatus = true;
                _msg.MsgType = 3;
                _model.Message = _msg;
            }
            else
            {
                _model = _rep.Itineary(id);
                if (_model.Message.MsgNumber == 1)
                {
                    List<string> emailList = new List<string>();
                    emailList.Add(emal);
                    if (_model.Itineary.GuestEmail != emal)
                    {
                        emailList.Add(_model.Itineary.GuestEmail);
                    }
                    string body = RenderPartialViewToString("Common/VUC_Itinerary", _model);
                    //use ohter way to send email.
                    string subject = "Hotel Booking Itinerary Ref No : " + _model.BookingRecordId + "#" + _model.Itineary.BookingId + "#" + _model.Itineary.ConfirmationNo + "# " + _model.Itineary.HotelName + ", " + _model.Itineary.CityName + ", " + _model.Itineary.CountryName;
                    HotelGeneralRepository.sendEmial(emal, "", "", subject, body, "HTML", "");
                    _msg.ActionMessage = "Itinerary has been sent.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 0;
                    _model.Message = _msg;
                }
            }
            return PartialView("Utility/VUC_Message", _model.Message);
        }
        public ActionResult EmailCancel(long? id, string emal)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            if (ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.ValidateEmail(emal) == false)
            {
                _msg.ActionMessage = "Invalid Email address.";
                _msg.MsgNumber = 1001;
                _msg.MsgStatus = true;
                _msg.MsgType = 3;
                _model.Message = _msg;
            }
            else
            {
                _model = _rep.CancelEmailFormat(id);
                if (_model.Message.MsgNumber == 1)
                {
                    List<string> emailList = new List<string>();
                    emailList.Add(emal);
                    if (_model.Itineary.GuestEmail != emal)
                    {
                        emailList.Add(_model.Itineary.GuestEmail);
                    }
                    string body = RenderPartialViewToString("VUC_CancellationEmail", _model);
                    GeneralRepository gProvider = new GeneralRepository();
                    //use ohter way to send email.
                    var agent = gProvider.GetAgentInfo(GeneralRepository.LoggedAgentId());
                    string emailId = agent.Email + "," + emal;
                    string subject = "Hotel Booking Cancellation #: " + _model.Itineary.HotelName + ", " + _model.Itineary.CityName + ", " + _model.Itineary.CountryName;
                    string HTML = HotelGeneralRepository.sendQuotation(emailId, subject, body, "", false);
                    _msg.ActionMessage = "Booking Cancellation Email has been sent.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 0;
                    _model.Message = _msg;
                }
            }
            return PartialView("Utility/VUC_Message", _model.Message);
        }
        public ActionResult CancellationEmail(long? BookingRecordId)
        {
            HotelBookingRecordRepository _rep = new HotelBookingRecordRepository();
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            _model = _rep.CancelEmailFormat(BookingRecordId);
            return View(_model);
        }
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
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
