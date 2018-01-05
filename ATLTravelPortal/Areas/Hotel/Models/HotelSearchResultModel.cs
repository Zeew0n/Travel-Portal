using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Pagination;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelSearchResultModel
    {
        public HotelCore.Utility.Status Status { get; set; }
        public HotelCore.Utility.HotelSearchResult[] Result { get; set; }
        public string SessionId { get; set; }
        public bool IsDomestic { get; set; }
        public HotelCore.Utility.CityInfo[] CityInfo { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public int NoOfRooms { get; set; }

        public IPagedList<HotelCore.Utility.HotelSearchResult> TabularList { get; set; }
        public HotelCore.Utility.RoomGuestData[] RoomGestDataList { get; set; }

        public int GDSID { get; set; }
        public bool IsNextPage { get; set; }
        public string CacheKey { get; set; }
        public string CacheLocation { get; set; }
        public HotelMessageModel Message { get; set; }
        public decimal FromRate { get; set; }
        public decimal ToRate { get; set; }
        public HotelCore.Utility.HotelRatingInput HotelRating { get; set; }
        public string HotelName { get; set; }
        public bool IsSessionData { get; set; }
        public string[] RateRanges { get; set; }
        public int[] StarRatings { get; set; }
        public IEnumerable<SelectListItem> ddlRateRangeList { get; set; }
        public IEnumerable<SelectListItem> ddlStarRatingList { get; set; }
        public string FilterHotelLocation { get; set; }
        public string FilterHotelName { get; set; }
        public decimal DisplayExchangeRate { get; set; }
        public string BaseCurrencyCode { get; set; }
    }
}