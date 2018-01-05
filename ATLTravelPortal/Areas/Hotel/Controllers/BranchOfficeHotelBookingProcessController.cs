using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    public class BranchOfficeHotelBookingProcessController : Controller
    {
        public ActionResult Index(int? page)
        {
            HotelBookingProcessModel _model = new HotelBookingProcessModel();
            HotelBookingProcessRepository _rep = new HotelBookingProcessRepository();
            HotelGeneralRepository.SetRequestPageRow();
            HotelMessageModel msg = new HotelMessageModel();
            _model.Message = msg;
            _model.TabularList = _rep.GetBranchOfficeHotelBookingProcessPagedList(page);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Process(HotelBookingProcessModel model)
        {
            HotelBookingProcessModel _model = new HotelBookingProcessModel();
            HotelBookingProcessRepository _rep = new HotelBookingProcessRepository();
            _model = _rep.ProcessPendingBooking(model.BookingRecordId);
            return View(_model);
        }

        public ActionResult Process(long? id)
        {
            HotelBookingProcessModel _model = new HotelBookingProcessModel();
            HotelBookingProcessRepository _rep = new HotelBookingProcessRepository();
            _model = _rep.GetDetail(id);
            return View(_model);
        }

        public ActionResult PendingCancellationList(int? page)
        {
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelGeneralRepository.SetRequestPageRow();
            _model.TabularList = _rep.GetPagedPendingList(page);
            _model.TabularList = _rep.GetBranchOfficePagedPendingList(page);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, HotelBookingProcessModel model, FormCollection frm, int? page)
        {
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelBookingProcessRepository _rep = new HotelBookingProcessRepository();
            HotelGeneralRepository.SetRequestPageRow();
            model.TabularList = _rep.GetBranchOfficeHotelBookingProcessPagedList(page);
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

                    var exportData = _rep.GetBranchOfficeHotelBookingProcessPagedList(page).Select(m => new
                    {

                        SNo = m.SNo,
                        GuestName = m.GuestName,
                        Location = m.CityName + "" + m.CountryName,
                        HotelDetails = m.HotelName,
                        Rooms = m.NoOfRoom,
                        CheckIn = m.CheckInDate.ToShortDateString(),
                        CheckOut = m.CheckOutDate.ToShortDateString(),
                        RequestDate = m.CreatedDate.ToShortDateString(),
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "HotelBookingRecord");
                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return null;
        }

        [HttpPost]
        public ActionResult PendingCancellationList(ExportModel Expmodel, HotelBookingCancelModel model, FormCollection frm, int? page)
        {
            int SNO = 0;
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelGeneralRepository.SetRequestPageRow();
            model.TabularList = _rep.GetBranchOfficePagedPendingList(page);
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

                    var exportData = _rep.BranchOfficePendingList().Select(m => new
                    {
                        SNO = m.SNo,
                        GuestName = (m.BookingDetail.Guests[0].Title) + " " + (m.BookingDetail.Guests[0].FirstName) + " " + m.BookingDetail.Guests[0].MiddleName + " " + m.BookingDetail.Guests[0].LastName,
                        HotelName = m.BookingDetail.HotelName,
                        RequestDate = m.CreatedOn.ToShortDateString(),
                        Status = m.CancelStatus
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "HotelBookingRecord");
                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return null;
        }

        public ActionResult ProcessCancellation(long? id)
        {
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            _model = _rep.FillCanceledDetail(id);
            return View(_model);
        }

        [HttpPost]
        public ActionResult ProcessCancellation(HotelBookingCancelModel model)
        {
            HotelBookingCancelRepository _rep = new HotelBookingCancelRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            _model = _rep.GetCancelRequestStatus(model.BookingCancelId);
            GeneralRepository gProvider = new GeneralRepository();
            TravelSession sessionObj = (TravelSession)System.Web.HttpContext.Current.Session["TravelSessionInfo"];
            string ReservationEmail = System.Configuration.ConfigurationManager.AppSettings["ReservationEmail"];
            var agent = gProvider.GetAgentInfo(ATLTravelPortal.Repository.GeneralRepository.LoggedUserId());
            string subject = "Hotel Booking Cancilation Status # Ref No : " + _model.BookingDetail.BookingRecordId + "#" + _model.BookingDetail.BookingId + "#" + _model.BookingDetail.ConfirmationNo + "#" + _model.BookingDetail.ReferenceNo + "|" + _model.BookingDetail.HotelName + ", " + _model.BookingDetail.CityName + ", " + _model.BookingDetail.CountryName;
            HotelGeneralRepository.sendEmial(agent.Email, ReservationEmail, "", subject, subject, "HTML", "");
            return View(_model);
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
