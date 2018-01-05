using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System;

using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class FlightsSearchModel
    {

        [DisplayName("From")]
        [Required(ErrorMessage = "*")]
        public string StartCity { get; set; }

        [DisplayName("Where")]
        [Required(ErrorMessage = "*")]
        public string EndCity { get; set; }

        [DisplayName("Leave")]
        [Required(ErrorMessage = "*")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Return")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("No of Seat(s)")]
        [Required(ErrorMessage = "*")]
        public int NoOfSeats { get; set; }

        [HiddenInput]
        public bool hdIsOneWay { get; set; }

        [HiddenInput]
        public int hdStartCityId { get; set; }

        [HiddenInput]
        public string hdStartCityName { get; set; }

        [HiddenInput]
        public string hdStartCityCode { get; set; }

        [HiddenInput]
        public int hdEndCityId { get; set; }

        [HiddenInput]
        public string hdEndCityName { get; set; }

        [HiddenInput]
        public string hdEndCityCode { get; set; }

        [DisplayName("Adults(12+ yrs)")]
        [Required(ErrorMessage = "*")]
        public int NoOfAdults { get; set; }

        [DisplayName("Children(2-11 yrs)")]
        public int NoOfChildren { get; set; }

        [DisplayName("Infants(Under 2 yrs)")]
        public int NoOfInfants { get; set; }
    }
}