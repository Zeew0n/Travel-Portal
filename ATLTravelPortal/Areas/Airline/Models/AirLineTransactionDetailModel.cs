using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineTransactionDetailModel
    {
        [Required(ErrorMessage="Select")]
        [DisplayName("Transaction")]
        public Int32 Transaction{get;set;}


        [Required(ErrorMessage="Select")]
        [DisplayName("Airline")]
        public Int32 Airline{get;set;}

        [Required(ErrorMessage="Select")]
        [DisplayName("Air Ticket Type")]
        public Int32 AirTicketType{get;set;}

        [Required(ErrorMessage="Select")]
        [DisplayName("Departure City")]
        public Int32 DepartureCity{get;set;}

        [Required]
        [DisplayName("Departure Date")]
        public string DepartureDate{get;set;}

        [Required]
        [DisplayName("Departure Time")]
        public string DepartureTime{get;set;}

        [Required]
        [DisplayName("Is Two Way")]
        public bool IsTwoWay{get;set;}

        [Required]
        [DisplayName("Arrival Date")]
        public string ArrivalDate{get;set;}

        [Required]
        [DisplayName("ArrivalTime")]
        public string ArrivalTime{get;set;}



        public List<SelectListItem> airLinesTypeList { get; set; }

    }
}

