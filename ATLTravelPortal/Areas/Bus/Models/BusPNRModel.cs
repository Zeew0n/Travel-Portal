using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusPNRModel
    {
        [HiddenInput]
        public long BusPNRId { get; set; }
        public int Sno { get; set; }
        [DisplayName("Service Provider")]
        public int ServiceProviderId { get; set; }
        [DisplayName("Agent Name")]
        public int AgentId { get; set; }

        [DisplayName("Distrubutor Name")]
        public int DistrubutorId { get; set; }

        [DisplayName("Ref No.")]
        public string RefrenceNumber { get; set; }

        [DisplayName("Bus Operator")]
        [Required(ErrorMessage = "Bus Operator Name required.")]
        public int BusMasterId { get; set; }
        public string BusMasterName { get; set; }

        [DisplayName("Bus Category")]
        [Required(ErrorMessage = "Bus Category Name required.")]
        public int BusCategoryId { get; set; }
        public string BusCategoryName { get; set; }

        [DisplayName("Bus No")]
        //[Required(ErrorMessage = "Bus No required.")]
        public string BusNo { get; set; }

        [DisplayName("No of Seat")]
        [Required(ErrorMessage = "No of Seat required.")]
        public int NoOfSeat { get; set; }


        public int TicketStatusId { get; set; }
        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("From City Name")]
        [Required(ErrorMessage = "From City Name required.")]
        public int FromCityId { get; set; }
        public string FromCityName { get; set; }

        [DisplayName("To City Name")]
        [Required(ErrorMessage = "To City Name required.")]
        public int ToCityId { get; set; }
        public string ToCityName { get; set; }
        [DisplayName("Departure Date Time")]
        [Required(ErrorMessage = "Departure Date Time required.")]
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        [DisplayName("Arrival Date Time")]
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        [DisplayName("Insurance Amount")]
        public double InsurenceAmount { get; set; }
        [DisplayName("Remarks")]
        public string Remarks { get; set; }
        [DisplayName("Fare Rule")]
        public string FareRule { get; set; }
        [DisplayName("Facility")]
        public string FacilityDetails { get; set; }
        [DisplayName("Prefix")]
        [Required(ErrorMessage = "Prefix required.")]
        public string Prefix { get; set; }
        [DisplayName("Passenger Name")]
        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        [DisplayName("Mobile No")]
        [Required(ErrorMessage="*")]
        public string MobileNumber { get; set; }
        [DisplayName("Phone No")]
        public string PhoneNumber { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage="*")]
        public string ContactAddress { get; set; }
        public BusMessageModel Message { get; set; }
        public string Type { get; set; }
        public List<BusPassengerModel> Passengers { get; set; }

        public bool HideServiceCharge { get; set; }

        public string AgentName { get; set; }
        public string AgentAddress { get; set; }
        public string AgentCode { get; set; }
        public string AgentPhone { get; set; }
        public string AgentEmial { get; set; }

        public string OperatorName { get; set; }
        public string OperatorAddress { get; set; }
        public string OperatorPhone { get; set; }
        public string OperatorEmail { get; set; }
        public string OperatorContactPerson { get; set; }
        public string OperatorMobileNo { get; set; }

        public bool IsOnline { get; set; }

        public string PNRNo { get; set; }

        public string SeatNumber { get; set; }
        public string BookingDate { get; set; }
        public string PassengerName { get; set; }
        public string PickUpPouints { get; set; }
        public double Rate { get; set; }
        public double DisRate { get; set; }
        public double TotalAmount { get; set; }
        public double ServiceCharge { get; set; }
        public double GrandTotal { get; set; }
        public string ItinearyNumber { get; set; }
        public IPagedList<BusPNRModel> TabularList { get; set; }

        public IEnumerable<SelectListItem> Salutations { get; set; }
        public IEnumerable<SelectListItem> BusCategories { get; set; }
        public IEnumerable<SelectListItem> BusOperators { get; set; }
        public IEnumerable<SelectListItem> BusTypes { get; set; }

        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To")]
        public DateTime? ToDate { get; set; }
        public IEnumerable<SelectListItem> AgentList { get; set; }
        public DateTime? IssuedDate { get; set; }
        public AvailableBalanceViewModel AvilableBalance { get; set; }
    }
    public class AvailableBalanceViewModel
    {
        /// This is for Available in masterpage
        public double? CreditLimitNPR { get; set; }
        public double? CurrentBalanceNPR { get; set; }
        public double? CreditLimitUSD { get; set; }
        public double? CurrentBalanceUSD { get; set; }
        public double? CreditLimitINR { get; set; }
        public double? CurrentBalanceINR { get; set; }

        public string CurrencyNPR { get; set; }
        public string CurrencyUSD { get; set; }
        public string CurrencyINR { get; set; }
        public bool isLowBalanceNPR { get; set; }
        public bool isLowBalanceUSD { get; set; }
        public bool isLowBalanceINR { get; set; }
    }
    public enum Salutation
    {
        [Description("Mr")]
        Mr = 0,
        [Description("Mrs")]
        Mrs = 1,
        [Description("Ms")]
        Ms = 2,
        [Description("Dr")]
        Dr = 3
    }
}