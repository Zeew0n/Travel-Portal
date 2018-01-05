using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PromotionalFareModel
    {
        public PromotionalFareSector PromotionalFareSector { get; set; }

    }

    public class PromotionalFareSector
    {

        [HiddenInput]
        public long PromotionalFareId { get; set; }



        public int AirlineId { get; set; }
        public string TourCode { get; set; }

        [Required(ErrorMessage = "*")]
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string BICClass { get; set; }
        [Required(ErrorMessage = "*")]
        public string FareBasis { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime? EffectiveFrom { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime? ExpireOn { get; set; }

        [Required(ErrorMessage = "*")]
        public int? NoOfPax { get; set; }

        [Required(ErrorMessage = "*")]
        public double? BaseFare { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal OtherCharges { get; set; }
        public string FareRule { get; set; }
        public int TotalSeatQuota { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public List<PromotionalFareTaxes> Taxes { get; set; }
        public List<PromotionalFareSegment> PromotionalFareSegment { get; set; }
        public List<PromotionalFareSector> PromotionalFareSectorList { get; set; }
        //public IEnumerable<SelectListItem> CityList { get; set; }
        public IEnumerable<SelectListItem> AirlinesList { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }

    }

    public class PromotionalFareSegment
    {
        [HiddenInput]
        public long PromotionalFareSegmentId { get; set; }

        public long PromotionalFareId { get; set; }

        [Required(ErrorMessage = "*")]
        public int FromCityId { get; set; }
        [Required(ErrorMessage = "*")]
        public int ToCityId { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        [Required(ErrorMessage = "*")]

        public DateTime? DepartureDate { get; set; }
        [Required(ErrorMessage = "*")]
        public TimeSpan DepartureTime { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        [Required(ErrorMessage = "*")]
        public string FlightNo { get; set; }
        [Required(ErrorMessage = "*")]
        public int AirlineId { get; set; }
        public string AirlineCode { get; set; }
        public string FareRule { get; set; }
        [Required(ErrorMessage = "*")]
        public string Class { get; set; }

        public IEnumerable<SelectListItem> AirlineList { get; set; }
        public IEnumerable<SelectListItem> FromCityList { get; set; }
        public IEnumerable<SelectListItem> ToCityList { get; set; }
        //public DateTime Effective_Date { get; set; }
        //public DateTime E
    }

    public class PromotionalFareTaxes
    {
        public Int64 PromotionalFareId { get; set; }
        [HiddenInput]
        public Int64 PromotionalFareTaxId { get; set; }
        [Required(ErrorMessage = "*")]
        public string TaxName { get; set; }
        [Required(ErrorMessage = "*")]
        public double TaxAmount { get; set; }

    }

    public class PromotionalFareListModel
    {
        public Int64 PromotionalFareId { get; set; }
        public string AirlineName { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string Currency { get; set; }
        public double BaseFare { get; set; }
        public double Tax { get; set; }
        public double OtherCharges { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? ExpireOn { get; set; }
        public int? NoOfPax { get; set; }
        public string FlightNo { get; set; }

    }
}