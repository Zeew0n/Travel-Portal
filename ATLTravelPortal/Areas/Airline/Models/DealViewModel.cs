using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class DealViewModel
    {
        [HiddenInput]
        public int DealId { get; set; }

        [HiddenInput]
        public int DealMasterId { get; set; }
        public string DealMaserText { get; set; }

        [HiddenInput]
        public int? AirlineId { get; set; }

        [DisplayName("Airline")]
        [Required]
        public string AirlineName { get; set; }
        public IEnumerable<SelectListItem> AirlineNameList { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }

        public int DealIdentifierId { get; set; }
        [HiddenInput]
        public string DealIdentifierText { get; set; }

        public string SectorType { get; set; }
        public bool isSectorWise { get; set; }
        public string FromCity { get; set; }
        [HiddenInput]
        public int? FromCityId { get; set; }

        public string ToCity { get; set; }
        [HiddenInput]
        public int? ToCityId { get; set; }

        public double AdultMarkup { get; set; }
        public double ChildMarkup { get; set; }
        public double InfantMarkup { get; set; }
        public bool isMarkupPercentage { get; set; }
        public double AdultCommission { get; set; }
        public double ChildCommission { get; set; }
        public double InfantCommission { get; set; }
        public bool isCommissionPercentage { get; set; }
        public int DealCalculateOnId { get; set; }
        public string DealCalculatedOnText { get; set; }

        public int MakerId { get; set; }
        public DateTime MakerDate { get; set; }
        public bool isVerified { get; set; }
        public int? VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isDelete { get; set; }

        public IEnumerable<SelectListItem> DealMasterList { get; set; }
        public IEnumerable<SelectListItem> DealAppliedOnList { get; set; }
        public IEnumerable<SelectListItem> DealCalculateOnList { get; set; }
        public IEnumerable<SelectListItem> DealIdentifierList { get; set; }
        public IEnumerable<DealViewModel> DealList { get; set; }

        public string AirlineClass { get; set; }

        //New Properties added

        public double AdultYQCommission { get; set; }
        public double ChildYQCommission { get; set; }
        public double InfantYQCommission { get; set; }
        public bool isYQCommissionPercentage { get; set; }

        public double AdultBFCommission { get; set; }
        public double ChildBFCommission { get; set; }
        public double InfantBFCommission { get; set; }
        public bool isBFCommissionPercentage { get; set; }

        public double AdultYQBFCommission { get; set; }
        public double ChildYQBFCommission { get; set; }
        public double InfantYQBFCommission { get; set; }
        public bool isYQBFCommissionPercentage { get; set; }

        public bool isRoundTrip { get; set; }
        public double Cashback { get; set; }
        public int Source { get; set; }


        public int? BusOperatorId { get; set; }
        public string BusOperatorName { get; set; }
        public IEnumerable<SelectListItem> BusOperatorList { get; set; }

        public int? BusCategoryId { get; set; }
        public string BusCategoryName { get; set; }
        public IEnumerable<SelectListItem> BusCategoryList { get; set; }
    }
}