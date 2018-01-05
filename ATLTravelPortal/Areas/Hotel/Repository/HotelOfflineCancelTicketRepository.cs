using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Pagination;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelOfflineCancelTicketRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

        public List<HotelBookingRecordModel> GetOfflineHotelCancelTicketList()
        {
            var result = _ent.Htl_BookingRecord.Where(x => x.TicketStatusId == 15).OrderByDescending(x => x.CreatedOn);
            List<HotelBookingRecordModel> model = new List<HotelBookingRecordModel>();

            foreach (var item in result)
            {
                HotelBookingRecordModel _booking = new HotelBookingRecordModel
                {
                    AddBookingRefId = item.AddBookingRefId,
                    AgentId = item.AgentId,
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

        public IPagedList<HotelBookingRecordModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return GetOfflineHotelCancelTicketList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }
    }
}