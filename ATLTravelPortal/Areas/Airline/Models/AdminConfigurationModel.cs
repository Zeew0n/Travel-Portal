using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public enum MarkupCharge
    {
        includeinTax,
        includeinFare
    }

    public enum ByPass
    {
        Allow,
        Disallow,
        BusAllow,
        BusDisallow,
        MobileAllow,
        MobileDisallow,
        HotelAllow,
        HotelDisallow
    }

    public class AdminConfigurationModel
    {
        public int AdminConfugrationId { get; set; }
        public bool chkEmailEveryTimeBookingIsMade { get; set; }
        public bool chkEmailEveryTimePNRIsMade { get; set; }
        [DisplayName("Send Mail to.")]
        public string txtSendMailTo { get; set; }
        public string txtEnterAlternativeEmail { get; set; }
        [DisplayName("Include in Tax")]
        public MarkupCharge rdbMarkupCharge { get; set; }
        [DisplayName("Type")]
        public int ddlDomesticType { get; set; }
        [DisplayName("Value")]
        public Double? txtDomesticValue { get; set; }
        [DisplayName("Type")]
        public int ddlInternationType { get; set; }
        [DisplayName("Value")]
        public Double? txtInternationalValue { get; set; }
        [DisplayName("TTL")]
        public int? TTL { get; set; }

        public ByPass ByPass { get; set; }
        public ByPass BusByPass { get; set; }
        public ByPass MobileByPass { get; set; }
        public ByPass HotelByPass { get; set; }

        public int DistributorID { get; set; }
        public int BranchOfficeID { get; set; }
        public int SettingID { get; set; }
        public int BusSettingID { get; set; }
        public int MobileSettingID { get; set; }
        public int HotelSettingID { get; set; }
    }
}