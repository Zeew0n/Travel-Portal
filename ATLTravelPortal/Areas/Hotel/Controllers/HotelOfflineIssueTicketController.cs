using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    public class HotelOfflineIssueTicketController : Controller
    {
        //
        // GET: /Hotel/HotelOfflineIssueTicket/

        public ActionResult Index(int? page)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelOfflineIssueTicketRepository _rep = new HotelOfflineIssueTicketRepository();
            HotelGeneralRepository.SetRequestPageRow();
            _model.TabularList = _rep.GetPagedList(page);
            return View(_model);
        }

    [HttpPost]
        public ActionResult Index(ExportModel Expmodel, HotelBookingRecordModel model, FormCollection frm, int? page)
    {
        HotelOfflineBookModel _model = new HotelOfflineBookModel();
        HotelOfflineIssueTicketRepository _rep = new HotelOfflineIssueTicketRepository();
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

                var exportData = _rep.GetOfflineHotelIssueTicketList().Select(m => new
                {
                    SNo = m.SNo,
                    GuestName = m.GuestName,
                    Location = m.CityName + "" + m.CountryName,
                    HotelDetails = m.HotelName,
                    Rooms = m.NoOfRoom,
                    CheckIn = m.CheckInDate.ToString("MM/dd/yyyy"),
                    CheckOut = m.CheckOutDate.ToString("MM/dd/yyyy"),
                    BookingDate = m.CreatedDate.ToString("MM/dd/yyyy"),
                    
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
