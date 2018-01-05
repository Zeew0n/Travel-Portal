using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Pagination;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class PendingBookingModel
    {
        public HotelCore.Utility.Itineary Itineary { get; set; }
        public HotelBookingDetailModel BookingDetail { get; set; }
        public HotelMessageModel Message { get; set; }
        public IPagedList<HotelBookingRecordModel> TabularList { get; set; }
        public long BookingRecordId { get; set; }
    }
}