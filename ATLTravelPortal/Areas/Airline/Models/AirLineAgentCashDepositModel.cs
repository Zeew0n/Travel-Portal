using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ATLTravelPortal.Helpers;

namespace  ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineAgentCashDepositModel
    {
        public Int64 DepositedId{get;set;}

        [DisplayName("Agent")]
        public Int32 Agentid{get;set;}

        [DisplayName("Applied Date Filter")]
        public bool AppliedDate { get; set; }

        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        [DisplayName("Agent")]
        public string AgentName { get; set; }

        [DisplayName("Mode")]
        public string ModeName { get; set; }

        [Required(ErrorMessage="*")]
        [DisplayName("Date")]
        public DateTime? DepositedDate{get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Amount")]
        public decimal? CashAmount{get;set;}

        [Required(ErrorMessage="*")]
        [DisplayName("Pay Mode")]
        public int Paymentmode{get;set;}

        [DisplayName("Bank")]
        public int BankId{get;set;}

        [DisplayName("Bank")]
        public string BankName { get; set; }

        [DisplayName("Amount in Word")]
        public string AmountInWord{get;set;}

        [DisplayName("Remark")]
        public string Remark{get;set;}
        
        public int CreatedBy{get;set;}
        public DateTime? CreatedDate{get;set;}
        public int? UpdatedBy{get;set;}
        public DateTime? UpdatedDate{get;set;}

        [DisplayName("Is Active")]
        public bool IsApproved{get;set;}

        [DisplayName("CreatedBy")]
        public string CreatedName { get; set; }

        [DisplayName("VerifiedBy")]
        public string VerifiedName { get; set; }
        [DisplayName("UnApproved")]
        public bool UnApproved { get; set; }

        public IEnumerable<AirLineAgentCashDepositModel> airlinecashDepositList { get; set; }

    }
}