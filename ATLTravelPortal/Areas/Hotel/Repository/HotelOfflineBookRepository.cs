using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Pagination;


namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelOfflineBookRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

        public List<HotelBookingRecordModel> GetOfflineHotelBookList()
        {
            var result = _ent.Htl_BookingRecord.Where(x => x.TicketStatusId == 28 || x.TicketStatusId == 14).OrderByDescending(x => x.CreatedOn);
            List<HotelBookingRecordModel> model = new List<HotelBookingRecordModel>();

            foreach (var item in result)
            {
                HotelBookingRecordModel _booking = new HotelBookingRecordModel
                {
                    AddBookingRefId = item.AddBookingRefId,
                    AgentId = item.AgentId,
                    AgentName = item.Agents.AgentName,
                    BookingReferenceNo = item.BookingReferenceNo,
                    CheckInDate = item.CheckInDate,
                    CheckOutDate = item.CheckOutDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedOn,
                    CurrencyCode = item.CurrencyCode,
                    FlightInfo = item.FlightInfo,
                    GDSBookingId = item.GDSBookingId,
                    GDSID = item.GDSID,
                    BookingRecordId = item.BookingRecordId,
                    HotelBookingStatus = item.HotelBookingStatus,
                    HotelCode = item.HotelCode,
                    HotelName = item.HotelName,
                    HotelRating = item.HotelRating,
                    NoOfNights = item.NoOfNights,
                    NoOfRoom = item.NoOfRoom,
                    SearchIndex = item.SearchIndex,
                    SearchSessionId = item.SearchSessionId,
                    SpecialRequest = item.SpecialRequest,
                    TotalAmount = item.TotalChargeableAmount,
                    HotelAddress = item.HotelAddress,
                    TicketStatusId =(int) item.TicketStatusId
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model;


        }



        public HotelOfflineBookModel GetDetail(long? id)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelMessageModel _msg = new HotelMessageModel();
            if (id != null)
            {
                HotelItinearyModel _itinModel = new HotelItinearyModel();
                HotelBookRepository _bookRep = new HotelBookRepository();
                HotelBookDetailRepository _bookingDtlRep = new HotelBookDetailRepository();
                HotelBookingDetailModel _bookingDtlModel = new HotelBookingDetailModel();
                _bookingDtlModel = _bookingDtlRep.GetHotelBooking(id);
                _model.BookingDetail = _bookingDtlModel;
                _model.BookingRecordId = id.Value;
                _itinModel = _bookRep.GetItineary(id);
                _model.Itineary = _itinModel.Itineary;
                _model.Message = _bookingDtlModel.Message;
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                _model.Message = _msg;
            }

            return _model;
        }


        public void UpdateHtl_BookingRecord(HotelOfflineBookModel model)
        {
            int AgntiId = _ent.Htl_BookingRecord.FirstOrDefault(x => x.BookingRecordId == model.BookingRecordId).AgentId;

            _ent.Htl_SaveSalesTransaction(Repository.HotelGeneralRepository.getIPAddress(), model.BookingRecordId, AgntiId, ATLTravelPortal.Repository.GeneralRepository.LogedUserId());
            Htl_BookingRecord result = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
            result.TicketStatusId = 16;
            result.GDSBookingId = model.GDSBookingId;
            result.BookingReferenceNo = model.BookingReferenceNo;
            result.BookingConformationNo = model.BookingConformationNo;

            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _ent.SaveChanges();
        }

        public void CancelOfflineTicket(HotelOfflineBookModel model)
        {
            Htl_BookingRecord result = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
            result.TicketStatusId = 15;
            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _ent.SaveChanges();
        }



        public IPagedList<HotelBookingRecordModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return GetOfflineHotelBookList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

       

    }
}