using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Pagination;
using ATLTravelPortal.Repository;
using System.IO;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBookingRecordRepository
    {
        private DateTime CurrentDateTime = ATLTravelPortal.Repository.GeneralRepository.CurrentDateTime();
        private int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
        public IEnumerable<HotelBookingRecordModel> List()
        {
            int Sno = 1;
            int no = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();


            var result = _ent.Htl_BookingRecord.Where(x => x.IsProcessed == true || x.TicketStatusId==4).OrderByDescending(x => x.CreatedOn);
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
                    TicketStatusId = item.TicketStatusId,
                    TicketStatus=item.TicketStatusId==null?"NA":item.TicketStatus.ticketStatusName
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId && x.IsLeadGuest==true);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        No=no++,
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.SNo = Sno++;
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }


        public IEnumerable<HotelBookingRecordModel> DistributorList()
        {
            int Sno = 1;
            int no = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();


            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingRecord
                         join b in _ent.Agents on a.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId && (a.TicketStatusId == 4 || a.IsProcessed == true)
                         orderby a.CreatedOn descending
                         select a;


            // var result = _ent.Htl_BookingRecord.Where(x => x.IsProcessed == true ).OrderByDescending(x => x.CreatedOn);
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
                    TicketStatusId = item.TicketStatusId,
                    TicketStatus = item.TicketStatusId == null ? "NA" : item.TicketStatus.ticketStatusName
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId && x.IsLeadGuest == true);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        No = no++,
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.SNo = Sno++;
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }



        public IEnumerable<HotelBookingRecordModel> BranchOfficeList()
        {
            int Sno = 1;
            int no = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();


            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingRecord
                         join b in _ent.Agents on a.AgentId equals b.AgentId
                         where b.BranchOfficeId == ts.LoginTypeId && (a.TicketStatusId==4 || a.IsProcessed==true)
                         orderby a.CreatedOn descending
                         select a;


          
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
                    TicketStatusId = item.TicketStatusId,
                    TicketStatus = item.TicketStatusId == null ? "NA" : item.TicketStatus.ticketStatusName
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId && x.IsLeadGuest == true);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        No = no++,
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.SNo = Sno++;
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }


        public IPagedList<HotelBookingRecordModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return List().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }
        public IPagedList<HotelBookingRecordModel> GetDistributorPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return DistributorList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public IPagedList<HotelBookingRecordModel> GetBranchOfficePagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return BranchOfficeList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public HotelItinearyModel Itineary(long? id)
        {
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelBookRepository _bookRep = new HotelBookRepository();
            _model = _bookRep.GetItineary(id);
            if (_model.Message.MsgNumber == 1)
            {
                _model.BookingRecordId = id.Value;
            }
            return _model;
        }
        public HotelItinearyModel CancelEmailFormat(long? id)
        {
            HotelItinearyModel _model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            if (id != null)
            {
                TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
                var obj = _ent.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == id).FirstOrDefault();
                if (obj != null)
                {
                    HotelBookRepository _bookRep = new HotelBookRepository();
                    _model = _bookRep.GetItineary(obj.BookingRecordId);
                    _model.BookingRecordId = id.Value;
                    _msg.ActionMessage = "Success.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = false;
                    _msg.MsgType = 1;
                }
                else
                {
                    _msg.ActionMessage = "Invalid Operation.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                }
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
            }
            _model.Message = _msg;
            return _model;
        }
    }
}