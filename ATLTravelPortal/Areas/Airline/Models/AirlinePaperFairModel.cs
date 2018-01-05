using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

//Added By DP
namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirlinePaperFairMainModel
    {       
        public int RuleId { get; set; } 
        
        [Required (ErrorMessage ="*")]
        [DisplayName("Airline")] 
        public int AirlineId { get; set; }

        [DisplayName("Flight Type")]
        public int FlightType { get; set; }

        [DisplayName("Flight Season")]
        public int FlightSeasonId { get; set; }

        [DisplayName("Effective From")]
        public DateTime EffectiveFrom { get; set; }

        [DisplayName("Effective To")]
        public DateTime EffectiveTo { get; set; }

        [DisplayName("ChildFare")]
        public decimal ChildFare { get; set; }

        [DisplayName("ChildFare Type")]
        public string ChildFareType { get; set; }

        [DisplayName("ChildFareOn")]
        public string ChildFareOn { get; set; }

        [DisplayName("InfantFare")]
        public decimal InfantFare { get; set; }

        [DisplayName("InfantFareType")]
        public string InfantFareType { get; set; }

        [DisplayName("InfantFareOn")]
        public string InfantFareOn { get; set; }

        [DisplayName("RefundFee")]
        public decimal RefundFee {get;set;}

        [DisplayName("ReissueFee")]
        public decimal ReissueFee {get;set;}

        [DisplayName("TermAndCondition")]
        public string TermAndCondition {get;set;}

        public int CreatedBy {get;set;}
        public DateTime CreatedDate {get;set;}
        public int UpdatedBy {get;set;}
        public DateTime UpdatedDate {get;set;}

        public int FlightTypeId { get; set; }
  
    }
}