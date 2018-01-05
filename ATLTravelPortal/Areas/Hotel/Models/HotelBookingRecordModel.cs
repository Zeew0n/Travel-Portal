using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Pagination;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelBookingRecordModel
    {
        public long BookingRecordId { get; set; }
        public int SNO { get; set; }
        public int GDSID { get; set; }
        public int SNo { get; set; }
        public int AgentId { get; set; }
        public int SearchIndex { get; set; }
        public int NoOfRoom { get; set; }
        public string FlightInfo { get; set; }
        public string SessionId { get; set; }
        public string SpecialRequest { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelRating { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfNights { get; set; }
        public decimal TotalAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string GDSBookingId { get; set; }
        public string BookingReferenceNo { get; set; }
        public string HotelBookingStatus { get; set; }
        public string AddBookingRefId { get; set; }
        public bool IsCanceled { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SearchSessionId { get; set; }
        public HotelMessageModel Message { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string TicketStatus { get; set; }
        public int? TicketStatusId { get; set; }
        public string AgentName { get; set; }
        public string HotelAddress { get; set; }

        public IEnumerable<GuestDetailModel> GuestDetails { get; set; }

        public IPagedList<HotelBookingRecordModel> TabularList { get; set; }

        public string GuestName { get; set; }
    }
}