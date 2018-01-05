using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelDealViewModel
    {
        #region Htl_Deals Properties
        [HiddenInput]
        public int HotelDealId { get; set; }

        [DisplayName("Deal Name")]
        [HiddenInput]
        public int DealMasterId { get; set; }
        public string DealMaserText { get; set; }

        [DisplayName("Hotel")]
        public int? HotelId { get; set; }
        public string HotelName { get; set; }

        [DisplayName("Deal Identifier")]
        public string DealIdentifier { get; set; }
        [HiddenInput]
        public string DealIdentifierText { get; set; }

        [DisplayName("Per Room")]
        public double MarkupOnPerRoom { get; set; }

        public bool isPercentMarkupOnPerRoom { get; set; }
        [DisplayName("Extra Guest Charge")]
        public double MarkupOnExtraGuestCharge { get; set; }
        public bool isPercentMarkupOnExtraGuestCharge { get; set; }

        public double CommissionOnPerRoom { get; set; }
        public bool isPercentCommissionOnPerRoom { get; set; }
        public double CommissionOnExtraGuestCharge { get; set; }
        public bool isPercentCommissionOnExtraGuestCharge { get; set; }

        [DisplayName("Currency")]
        public int CurrencyId { get; set; }
        public string Currency { get; set; }

        public int MakerId { get; set; }
        public DateTime MakerDate { get; set; }
        public bool isVerified { get; set; }
        public int? VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #endregion

        #region For DropdownLists

        public IEnumerable<SelectListItem> HotelList { get; set; }
        public IEnumerable<SelectListItem> DealMasterList { get; set; }
        public IEnumerable<SelectListItem> DealIdentifierList { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }

        #endregion

        public IEnumerable<HotelDealViewModel> DealList { get; set; }
    }
}