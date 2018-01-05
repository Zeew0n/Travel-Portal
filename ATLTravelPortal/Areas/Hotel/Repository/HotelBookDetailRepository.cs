using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBookDetailRepository
    {
        public HotelBookingDetailModel GetHotelBooking(long? BookingRecordId)
        {
            HotelCore.GetHotelBooking.Response _res = new HotelCore.GetHotelBooking.Response();
            HotelCore.GetHotelBooking.Request _req = new HotelCore.GetHotelBooking.Request();
            HotelBookingDetailModel model = new HotelBookingDetailModel();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            HotelMessageModel _msg = new HotelMessageModel();
            if (BookingRecordId != null)
            {
                var obj = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == BookingRecordId).FirstOrDefault();
                if (obj != null)
                {
                    _req.BookingId = obj.GDSBookingId;
                    HotelCore.API _api = new HotelCore.API();
                    //_res = _api.GetHotelBooking(_req);
                    var _bookingDtl = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == BookingRecordId).FirstOrDefault();
                    Administrator.Models.AgentModel _agent = new Administrator.Models.AgentModel {
                        AgentName = _bookingDtl.Agents.AgentName,
                        Address=_bookingDtl.Agents.Address,
                        PhoneNo=_bookingDtl.Agents.Phone,
                        AgentId=_bookingDtl.AgentId
                    };
                    model.CheckInDate = _bookingDtl.CheckInDate;
                    model.CheckOutDate = _bookingDtl.CheckOutDate;
                    model.CityName = _bookingDtl.CityName;
                    model.CountryName = _bookingDtl.CountryName;
                    model.CurrencyCode = _bookingDtl.CurrencyCode;
                    model.Flightinfo = _bookingDtl.FlightInfo;
                    model.HotelRating = _bookingDtl.HotelRating;
                    model.HotelImageUrl = _bookingDtl.HotelImageUrl;
                    model.TotalChargableAmount = _bookingDtl.TotalChargeableAmount;
                    model.BookingId = _bookingDtl.GDSBookingId;
                    model.ConfirmationNo = _bookingDtl.BookingConformationNo;
                    model.ReferenceNo = _bookingDtl.BookingReferenceNo;
                    model.AgentDetail = _agent;
                    var _guests = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == BookingRecordId);
                    List<GuestDetailModel> _guestList = new List<GuestDetailModel>();
                    foreach (var item in _guests)
                    {
                        GuestDetailModel _guest = new GuestDetailModel();
                        _guest.Address1 = item.Address1;
                        _guest.Address2 = item.Address2;
                        _guest.Age = item.Age;
                        _guest.City = item.City;
                        _guest.Country = item.Country;
                        _guest.Email = item.Email;
                        _guest.Title = item.Title;
                        _guest.FirstName = item.FirstName;
                        _guest.GuestState = item.GuestState;
                        _guest.GuestType = item.GuestType;
                        _guest.IsLeadGuest = item.IsLeadGuest;
                        _guest.LastName = item.LastName;
                        _guest.MiddleName = item.MiddleName;
                        _guest.PhoneNo = item.PhoneNo;
                        _guest.RoomIndex = item.RoomIndex;
                        _guest.Title = item.Title;
                        _guest.ZipCoade = item.ZipCoade;
                        _guestList.Add(_guest);
                    }
                    List<HotelCore.Utility.RoomGuestData> _roomGuestList = new List<HotelCore.Utility.RoomGuestData>();

                    List<int> _childAge = new List<int>();
                    var _roomDtl = _ent.Htl_BookingRoomDetail.Where(x => x.BookingRecordId == BookingRecordId);
                    foreach (var item in _roomDtl)
                    {
                        HotelCore.Utility.RoomGuestData _roomGuest = new HotelCore.Utility.RoomGuestData();
                        _roomGuest.NoOfAdults = item.NoOfAdult;
                        _roomGuest.NoOfChild = item.NoOfChild;
                        _roomGuest.RoomTypeName = item.RoomTypeName;
                        _roomGuestList.Add(_roomGuest);
                    }
                    var _roomType = _ent.Htl_BookingRoomDetail.Where(x => x.BookingRecordId == BookingRecordId);
                    List<HotelCore.Utility.HotelRoomsDetails> RoomList = new List<HotelCore.Utility.HotelRoomsDetails>();
                    var bookingRoomCode = "";
                    foreach (var item in _roomType)
                    {
                        HotelCore.Utility.HotelRoomsDetails room = new HotelCore.Utility.HotelRoomsDetails();
                        room.RoomTypeName = item.RoomTypeName;
                        room.NoOfUnits = 1;
                        bookingRoomCode = item.BookingRoomCode;
                        var _nightRate = _ent.Htl_BookingNightRate.Where(x => x.BookingRoomCodeId == item.BookingRoomCodeId);
                        List<HotelCore.Utility.DayRates> _dayRates = new List<HotelCore.Utility.DayRates>();
                        foreach (var item1 in _nightRate)
                        {
                            HotelCore.Utility.DayRates _dayRate = new HotelCore.Utility.DayRates();
                            _dayRate.Days = item1.BookingDate;
                            _dayRate.LowRate = item1.BookingRate;
                            _dayRates.Add(_dayRate);
                        }
                        room.DayRates = _dayRates.ToArray();
                        var _roomRate = _ent.Htl_BookingRoomRate.Where(x => x.BookingRoomCodeId == item.BookingRoomCodeId);
                        List<HotelCore.Utility.RoomRate> _roomRateList = new List<HotelCore.Utility.RoomRate>();
                        HotelCore.Utility.RoomRate RoomRate = new HotelCore.Utility.RoomRate();
                        RoomRate.TotalRoomRate = _roomRate.Where(x => x.Particular == "Total-Rate").FirstOrDefault().Amount;
                        RoomRate.ExtraGuestCharges = _roomRate.Where(x => x.Particular == "Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.TotalRoomTax = _roomRate.Where(x => x.Particular == "Tax").FirstOrDefault().Amount;
                        RoomRate.ServiceTax = _roomRate.Where(x => x.Particular == "Service-Tax").FirstOrDefault().Amount;
                        RoomRate.DisCount = _roomRate.Where(x => x.Particular == "Discount").FirstOrDefault().Amount;
                        RoomRate.TotalTaxesAndFees = RoomRate.TotalRoomTax + RoomRate.ServiceTax;
                        //RoomRate.AgentServiceCharge = _roomRate.Where(x => x.Particular == "Agent-Service-Charge").FirstOrDefault().Amount;
                        RoomRate.CommissionExtraGuestCharge = _roomRate.Where(x => x.Particular == "Commission-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.CommissionRatePerRoom = _roomRate.Where(x => x.Particular == "Commission-Rate-Per-Room").FirstOrDefault().Amount;
                        RoomRate.DiscountExtraGuestCharge = _roomRate.Where(x => x.Particular == "Discount-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.DiscountRatePerRoom = _roomRate.Where(x => x.Particular == "Discount-Rate-Per-Room").FirstOrDefault().Amount;
                        RoomRate.MarkupExtraGuestCharge = _roomRate.Where(x => x.Particular == "Markup-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.MarkupRatePerRoom = _roomRate.Where(x => x.Particular == "Markup-Rate-Per-Room").FirstOrDefault().Amount;
                        room.RoomRate = RoomRate;
                        RoomList.Add(room);
                    }

                    model.RoomDetail = RoomList.ToArray();
                    model.RoomGuest = _roomGuestList.ToArray();
                    model.Guests = _guestList.ToArray();
                    model.HotelAddress = _bookingDtl.HotelAddress;
                    model.HotelEmail = _bookingDtl.HotelEmail;
                    model.HotelName = _bookingDtl.HotelName;
                    model.HotelPhoneNo = _bookingDtl.HotelPhone;
                    model.NoOfRooms = _bookingDtl.NoOfRoom;
                    model.SpecialRequest = _bookingDtl.SpecialRequest;
                    model.BookingDetail = _res.BookingDetail;
                    _msg.ActionMessage = "Success.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = false;
                    _msg.MsgType = 0;
                    model.Message = _msg;
                }
                else
                {
                    _msg.ActionMessage = "Invalid Operation.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    model.Message = _msg;
                }
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                model.Message = _msg;
            }
            return model;
        }
    }
}