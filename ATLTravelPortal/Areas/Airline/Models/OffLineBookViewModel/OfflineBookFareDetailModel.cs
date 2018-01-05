using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TBO.Passenger;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel
{
    public class OfflineBookFareDetailModel
    {
        public PassengerType PaxType { get; set; }

        public int PaxTypeId { get; set; }
        public IEnumerable<SelectListItem> PaxTypeList { get; set; }

        public long TicketId { get; set; }
        public string MPNRId { get; set; }
        public string PNRId { get; set; }
        public long? TktId { get; set; }
        public string TourCode { get; set; }
        public string CorporateCode { get; set; }
        public string ValidatingAirline { get; set; }
        public Int64 PassengerId { get; set; }
        
      
        [Required]
        public string TicketNumber { get; set; }
        public double AdditionalTxnFee { get; set; }
        public double AirlineTransFee { get; set; }

        public DateTime? DOB { get; set; }  
        
        [Required(ErrorMessage = " ")]
        [DisplayName("Base Fare")]
        public double BaseFare { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Tax")]
        public double Tax { get; set; }

        public double OtherCharges { get; set; }
        public double ServiceTax { get; set; }
        public double MarkupAmount { get; set; }
        public double CommissionAmount { get; set; }
        public double DiscountAmount { get; set; }
       // public double ServiceCharge { get; set; }
        public string Currency { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public double FSC { get; set; }
        public int TicketStatusId { get; set; }
        public string TicketStatus { get; set; }
        public string Remarks { get; set; }
        public string Endorsement { get; set; }
        public double SellingAdditionalTxnFee { get; set; }
        public double SellingAirlineTransFee { get; set; }
        public double AgentAirlineMarkup { get; set; }

        [Required(ErrorMessage = "*")]
        public double SellingBaseFare { get; set; }

        [Required(ErrorMessage = "*")]
        public double SellingTax { get; set; }
        public double SellingOtherCharges { get; set; }
        public double SellingServiceTax { get; set; }
        public double SellingFSC { get; set; }
        //public double AgentServiceCharge { get; set; }
        public double ExchangeRate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Pax Type")]
        public PassengerType FarePaxType { get; set; }



    }
}