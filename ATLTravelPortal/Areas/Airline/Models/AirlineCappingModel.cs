using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirlineCappingModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("GDS Name")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        public int ServiceProviderId { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        //[DisplayName("Airline Name")]
        //public int AirlineId { get; set; }

         [Required(ErrorMessage = "*")]
         [DisplayName("Airline Name")]
        public string AirlinesName { get; set; }

         [HiddenInput]
         public int? hdfAirlineName { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Total Number of Ticket")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public int TotalTicketNumber { get; set; }

       

        public Int64 cappingId { get; set; }
        public string AirlineName { get; set; }

        public IEnumerable<AirlineCappingModel> airlineCappingList { get; set; }
    }
}