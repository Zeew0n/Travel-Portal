using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class BranchDealViewModel
    {

        [HiddenInput]
        public int DealId { get; set; }



        [HiddenInput]
        public int DealMasterId { get; set; }
        public string DealMaserText { get; set; }

        public int branchofficeid { get; set; }
        public int distributorid { get; set; }

        [HiddenInput]
        public int? AirlineId { get; set; }

        [DisplayName("Airline")]
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

        [Required]
        public double Amount { get; set; }


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

        public int CreatedBy { get; set; }

        public IEnumerable<SelectListItem> DealMasterList { get; set; }
        public IEnumerable<SelectListItem> DealAppliedOnList { get; set; }
        public IEnumerable<SelectListItem> DealCalculateOnList { get; set; }
        public IEnumerable<SelectListItem> DealIdentifierList { get; set; }
        public IEnumerable<BranchDealViewModel> DealList { get; set; }

        public string AirlineClass { get; set; }

        public bool isRoundTrip { get; set; }

        public bool isPercentage { get; set; }


        [DisplayName("Hotel")]
        public string HotelName { get; set; }
        public IEnumerable<SelectListItem> HotelNameList { get; set; }

        [HiddenInput]
        public int? HotelId { get; set; }


        public int? BusOperatorId { get; set; }
        public string BusOperatorName { get; set; }
        public IEnumerable<SelectListItem> BusOperatorList { get; set; }

        public int? BusCategoryId { get; set; }
        public string BusCategoryName { get; set; }
        public IEnumerable<SelectListItem> BusCategoryList { get; set; }
    }
}