using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelItinearyModel
    {
        public HotelCore.Utility.HotelRoomsDetails[] RoomDetail { get; set; }
        public HotelCore.Utility.DayRates[] DayRates { get; set; }
        public HotelCore.Utility.Itineary Itineary { get; set; }
        public int GDSID { get; set; }
        public string CurrencyCode { get; set; }
        public int NoOfRoom { get; set; }
        public int NoOfAdult { get; set; }
        public int NoOfChild { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalTaxAndFees { get; set; }
        public decimal TotalCharge { get; set; }
        public decimal ExtraGuestCharges { get; set; }
        public long BookingRecordId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CancellationNumber { get; set; }
        public HotelMessageModel Message { get; set; }
        public int? TicketStatusId { get; set; }
    }
}