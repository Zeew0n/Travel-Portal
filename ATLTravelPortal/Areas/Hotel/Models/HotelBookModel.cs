using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelBookModel
    {
        [Required(ErrorMessage="*")]
        public int Index { get; set; }
        [Required(ErrorMessage = "*")]
        public int NoOfRooms { get; set; }
        [Required(ErrorMessage = "*")]
        public string[] RoomCodes { get; set; }
        public HotelCore.Utility.Guest[] Guest { get; set; }
        [Required(ErrorMessage = "*")]
        public string SessionId { get; set; }
        public string Flightinfo { get; set; }
        public string SpecialRequest { get; set; }
        public HotelCore.Utility.PaymentInformation PaymentInfo { get; set; }
       
        public HotelCore.Utility.HotelRoomsDetails[] RoomDetail { get; set; }

        public string BookingId { get; set; }
        public string ReferenceNo { get; set; }
        public HotelCore.Utility.Status Status { get; set; }

        public string CityName { get; set; }
        public string CountryName { get; set; }
        [Required(ErrorMessage = "*")]
        public string HotelCode { get; set; }
        [Required(ErrorMessage = "*")]
        public string HotelName { get; set; }
        public string HotelPhoneNo { get; set; }
        public string HotelEmail { get; set; }
        public string HotelAddress { get; set; }
        public string HotelDescription { get; set; }
        public string HotelImageUrl { get; set; }
        public string PromoDescription { get; set; }
        public string HotelMap { get; set; }
        public HotelCore.Utility.HotelRating HotelRating { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public HotelCore.Utility.RoomGuestData[] RoomGuest { get; set; }
        public string RoomTypeName { get; set; }
        public HotelCore.Utility.BookingRoomRate[] BookingRoomRate { get; set; }
        public IEnumerable<SelectListItem> ddlCountryList { get; set; }
        public int GDSID { get; set; }
        public string RateKey { get; set; }
        
        public HotelCore.Utility.Itineary Itineary { get; set; }
        public long BookingRecordId { get; set; }
        public HotelMessageModel Message { get; set; }
        public decimal DisplayExchangeRate { get; set; }
        public string BaseCurrencyCode { get; set; }
        public HotelCancellationPolicyModel PolicyModel { get; set; }
        public decimal TotalChargableAmount { get; set; }
        public decimal MarkupRatePerRoom { get; set; }
        public decimal MarkupExtraGuestCharge { get; set; }
        public decimal DiscountRatePerRoom { get; set; }
        public decimal DiscountExtraGuestCharge { get; set; }
        public decimal CommissionRatePerRoom { get; set; }
        public decimal CommissionExtraGuestCharge { get; set; }
        public decimal AgentServiceCharge { get; set; }
        public string QuotationMessage { get; set; }
        [Required(ErrorMessage = "Accept hotel")]
        public bool TermsConditions { get; set; }
        
    }
}