using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Train.Models
{
    public class TrainPNRModel
    {
        [DisplayName("Transaction ID:")]
        public long TrainPNRId { get; set; }
        public int ServiceProviderId { get; set; }
        public int AgentId { get; set; }
        [DisplayName("Agent Name:")]
        public string AgentName { get; set; }
        [DisplayName("Agent Address:")]
        public string AgentAddress { get; set; }
        [DisplayName("Agent Code:")]
        public string AgentCode { get; set; }
        [DisplayName("Agent Phone:")]
        public string AgentPhone { get; set; }
        [DisplayName("Agent Email:")]
        public string AgentEmial { get; set; }
        [DisplayName("Class:")]        
        public int TrainClassId { get; set; }
        public string TrainClassName { get; set; }
        public List<SelectListItem> ddlClassList { get; set; }
        public List<SelectListItem> ddlIDTypeList { get; set; }
        public string Quota { get; set; }
        public int NoOfSeat { get; set; }
        [DisplayName("From Station:")]
        [Required(ErrorMessage = "*")]
        public int FromStationId { get; set; }
        public string FromStationName { get; set; }
        [DisplayName("To Station:")]
        [Required(ErrorMessage = "*")]
        public int ToStationId { get; set; }
        public string ToStationName { get; set; }
        public string Sector { get; set; }
        [DisplayName("Departure Date:")]
        [Required(ErrorMessage = "*")]
        public DateTime DepartureDate { get; set; }
        [DisplayName("Return Date:")]
        public DateTime? ReturnDate { get; set; }
        [DisplayName("Departure Time:")]
        public TimeSpan DepartureTime { get; set; }
        [DisplayName("Arrival Date:")]
        public DateTime? ArrivalDate { get; set; }
        [DisplayName("Arrival Time:")]
        public TimeSpan? ArrivalTime { get; set; }
        [DisplayName("Journey Type:")]
        [Required(ErrorMessage = "*")]
        public string JourneyType { get; set; }
        [DisplayName("Prefix:")]
        [Required(ErrorMessage = "*")]
        public string Prefix { get; set; }
        public List<SelectListItem> ddlPrefixList { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }
        [DisplayName("Gender:")]
        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }
        public List<SelectListItem> ddlGenderList { get; set; }
        [DisplayName("Age:")]
        [Required(ErrorMessage = "*")]
        public int Age { get; set; }
        [DisplayName("Nationality:")]
        [Required(ErrorMessage = "*")]
        public string Nationality { get; set; }
        [DisplayName("ID Type:")]
        [Required(ErrorMessage = "*")]
        public int? IDTypeId { get; set; }
        //public List<SelectListItem> ddlIDTypeList { get; set; }
        public string IDTypeName { get; set; }
        [DisplayName("ID Number:")]
        [Required(ErrorMessage = "*")]
        public string IDNumber { get; set; }
        [DisplayName("Mobile No:")]
        public string MobileNumber { get; set; }
        [DisplayName("Phone Number:")]
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email:")]
        public string EmailAddress { get; set; }
        [DisplayName("Address:")]
        [Required(ErrorMessage = "*")]
        public string ContactAddress { get; set; }
        [DisplayName("Choice Subjects:")]
        public string ChoiceSubjects { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        [DisplayName("Requested Date:")]
        public DateTime CreateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IssuedBy { get; set; }
        public string IssuedByName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public int TicketStatusId { get; set; }
        public string TicketStatusName { get; set; }
        public TrainMessageModel Message { get; set; }
        public List<TrainPassengerModel> Passengers { get; set; }
        public IPagedList<TrainPNRModel> PagedList { get; set; }
        [DisplayName("No of Adult:")]
        [Required(ErrorMessage = "*")]
        public int NoOfAdult { get; set; }
        [DisplayName("No of Child:")]
        public int? NoOfChild { get; set; }
        [DisplayName("No of Senior Male:")]
        public int? NoOfSM { get; set; }
        [DisplayName("No of Senior Female:")]
        public int? NoOfSF { get; set; }
        public string Remarks { get; set; }
        public TimeSpan? ReturnTime { get; set; }
        public bool IsPrimary { get; set; }
        [DisplayName("Train No:")]
        public string TrainNo { get; set; }
        [DisplayName("Train Name:")]
        public string TrainName { get; set; }
        [DisplayName("Fare:")]
        public double? Fair { get; set; }
        [DisplayName("IRCTCS Charge:")]
        public double? IRCTCSCharge { get; set; }
        [DisplayName("GSAS Charge:")]
        public double? GSASCharge { get; set; }
        public double? AgentCharge { get; set; }
        [DisplayName("Exchange Rate:")]
        public double? ExchangeRate { get; set; }
        [DisplayName("AH Charge:")]
        public double? AHMarkUp { get; set; }
        public double? TotalAmount { get; set; }
        [DisplayName("Railway PNR:")]
        [Required(ErrorMessage="*")]
        public string RailWayPNR { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Email:")]
        public string txtEmailTo { get; set; }
        public HttpPostedFileBase PNRFile { get; set; }
        public AvailableBalanceViewModel AvilableBalance { get; set; }
        public List<SelectListItem> ddlChaildAgeList { get; set; }
        public List<SelectListItem> ddlAdultAgeList { get; set; }
        public List<SelectListItem> ddlSMAgeList { get; set; }
        public List<SelectListItem> ddlSFAgeList { get; set; }
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
}