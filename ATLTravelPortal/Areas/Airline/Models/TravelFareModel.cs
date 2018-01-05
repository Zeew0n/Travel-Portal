using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class TravelFareModel
    {
        public Int64 PaperFareId{get;set;}

        [DisplayName("Airline")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int AirlineId{get;set;}
        public string AirlineNmae{get;set;}
        
        [DisplayName("Flight Session")]
        //[Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int FlightSeasonId{get;set;}
        public string FlightSeasonName{get;set;}

        [DisplayName("Departure City")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int DepartureCityId{get;set;}
        public string DepartureCityName{get;set;}

        [DisplayName("Destination City")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int DestinationCityId{get;set;}
        public string DestinationCityName{get;set;}

        [DisplayName("Flight Class")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int FlightClassId{get;set;}
        public string FlightClassName{get;set;}

        [DisplayName("OneWay Fare")]
        public string OneWayFareBasis{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("Departure City")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " *")]
        public decimal OneWayFare{get;set;}

        
        [DisplayName("RoundWay Fare Basic")]
        public string RoundWayFareBasis{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("RoundWay Fare")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " *")]
        public decimal RoundWayFare{get;set;}

        //[Required(ErrorMessage="*")]
        [DisplayName("Expire On")]
        public DateTime? ExpireOn{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("Effective From")]
        public DateTime EffectiveFrom{get;set;}

        [DisplayName("Flight Type")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int FlightTypeId{get;set;}

        public string FlightTypes { get; set; }
        
        [Required(ErrorMessage="*")]
        [DisplayName("Child Fare")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "*")]
        public double ChildFare{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Child Fare ")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "*")]
        public decimal ChildFareUSD { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("ChildFare Type")]
        public string ChildFareType{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("ChildFare On")]
        public string ChildFareOn{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("InfantFare")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number!!")]
        public double InfantFare{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("InfantFare")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number!!")]
        public decimal InfantFareUSD { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("InfantFare Type")]
        public string InfantFareType{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("InfantFare On")]
        public string InfantFareOn{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("Refund Fee")]
        //[RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "*")]
        public decimal RefundFee{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Refund Fee ($)")]
        //[RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "*")]
        public decimal RefundFeeDollar { get; set; }

        [Required(ErrorMessage="*")]
        [DisplayName("Reissue Fee")]
        //[RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " *")]
        public decimal ReissueFee{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Reissue Fee ($)")]
        //[RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " *")]
        public decimal ReissueFeeDollar { get; set; }

        [DisplayName("Currencies")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "*")]
        public int CurrencyId{get;set;}

        public string CurrencyName { get; set; }

        
        [DisplayName("Term And Condition")]
        public string TermsAndConditions{get;set;}

         [Required(ErrorMessage = "*")]
        [DisplayName("Tour Code")]
        public string TourCode{get;set;}

        public decimal TotalRoundTripFare { get; set; }
        public decimal FuelCharge { get; set; }
        public decimal GoingFare { get; set; }
        public bool ValidTillFurtherNotice { get; set; }

        public decimal OneWayFareUSD { get; set; }
        public decimal RoundWayGoingUSD { get; set; }
        public decimal RoundWayReturnUSD { get; set; }
        public decimal RoundWayFareUSD { get; set; }
        
        public IEnumerable<TravelFareModel> airlineTravelportalList { get; set; }
    }
}