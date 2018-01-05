using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineFlightTaxMappingModel
    {
        public Int64 MappingId { get; set; }

        [DisplayName("Airline")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        public int AirLineId { get; set; }
        public string AirlineName { get; set; }

        [DisplayName("Flight Tax")]
        [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        public int FlightTaxId { get; set; }
        public string FlightTaxName { get; set; }

        [DisplayName("Commission Value")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public double CommissionValue { get; set; }

        [Required(ErrorMessage="CommissionType must be select!!")]
        [DisplayName("Commission Type")]
        public string CommissionType { get; set; }


       public List<SelectListItem> commissionList = new List<SelectListItem>();
       public string ddlcommission { get; set; }

       public List<int> airlinelist { get; set; }

       public IEnumerable<AirLineFlightTaxMappingModel> airLineFlightTaxMappingList { get; set; }
    }
}