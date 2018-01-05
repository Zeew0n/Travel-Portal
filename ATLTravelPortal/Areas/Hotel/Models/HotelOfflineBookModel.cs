using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Pagination;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelOfflineBookModel
    {
        public HotelCore.Utility.Itineary Itineary { get; set; }
        public HotelBookingDetailModel BookingDetail { get; set; }
        public HotelMessageModel Message { get; set; }
        public IPagedList<HotelBookingRecordModel> TabularList { get; set; }
        public List<HotelBookingRecordModel> ListOfflineHotelBook { get; set; }
        public long BookingRecordId { get; set; }

        public string GDSBookingId { get; set; }
        public string BookingReferenceNo { get; set; }
        public string BookingConformationNo { get; set; }
        public static int DefaultPageSize = 15;

    }
}