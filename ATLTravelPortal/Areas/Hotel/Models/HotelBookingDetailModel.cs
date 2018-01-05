using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelBookingDetailModel
    {
        public HotelCore.Utility.HotelBookingDetail[] BookingDetail { get; set; }
        public HotelCore.Utility.Status Status { get; set; }
        public GuestDetailModel[] Guests { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelPhoneNo { get; set; }
        public string HotelEmail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
        public string CurrencyCode { get; set; }
        public HotelCore.Utility.RoomGuestData[] RoomGuest { get; set; }
        public string SpecialRequest { get; set; }
        public string Flightinfo { get; set; }
        public HotelCore.Utility.BookingRoomRate[] RoomRate { get; set; }
        public string BookingRecordId { get; set; }
        public HotelCore.Utility.DayRates[] DayRates { get; set; }
        public string HotelRating { get; set; }
        public string HotelImageUrl { get; set; }
        public HotelMessageModel Message { get; set; }
        public HotelCore.Utility.HotelRoomsDetails[] RoomDetail { get; set; }
        public decimal TotalChargableAmount { get; set; }
        public string BookingId { get; set; }
        public string ReferenceNo { get; set; }
        public string ConfirmationNo { get; set; }
        public Administrator.Models.AgentModel AgentDetail { get; set; }

    }
}