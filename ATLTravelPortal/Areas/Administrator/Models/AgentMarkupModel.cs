using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentMarkupModel
    {
        public int AirlineId { get; set; }
        [DisplayName("Airline Name")]
       // [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "AirlineName must be select!!")]
        public string AirlineName { get; set; }

        [DisplayName("Airline Photo")]
        public string AirlinePhoto { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Markup Value")]
        public decimal MarkupValue { get; set; }


    }
}