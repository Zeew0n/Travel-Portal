using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Train.Models
{
    public class TrainPassengerModel
    {
        public long TrainPassengerId { get; set; }
        public long TrainPNRId { get; set; }
        [DisplayName("Prefix:")]
        [Required(ErrorMessage = "*")]
        public string Prefix { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }
        [DisplayName("Gender:")]
        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }
        [DisplayName("Age:")]
        [Required(ErrorMessage = "*")]
        public int Age { get; set; }
        [DisplayName("Nationality:")]
        [Required(ErrorMessage = "*")]
        public string Nationality { get; set; }
        [DisplayName("ID Type:")]
        public int? IDTypeId { get; set; }
        public string IDTypeName { get; set; }
        [DisplayName("ID Number:")]
        public string IDNumber { get; set; }
        public string PassengerType { get; set; }
        public double Fare { get; set; }
        public double Markup { get; set; }
        public double TaxAmount { get; set; }
        public double CommissionAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double ServiceCharge { get; set; }
        public int TicketStatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsPrimary { get; set; }

        public List<SelectListItem> ddlSMAgeList { get; set; }
        public List<SelectListItem> ddlSFAgeList { get; set; }
        public List<SelectListItem> ddlAdultAgeList { get; set; }
        public List<SelectListItem> ddlIDTypeList { get; set; }
        public List<SelectListItem> ddlGenderList { get; set; } 
        public List<SelectListItem> ddlPrefixList { get; set; }
        public List<SelectListItem> ddlChaildAgeList { get; set; }
    }
}