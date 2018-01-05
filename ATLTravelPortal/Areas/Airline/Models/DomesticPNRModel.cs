using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System;
using ATLTravelPortal.Helpers;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class DomesticPNRModel
    {
        [DisplayName("Start City")]
        public string StartCity { get; set; }

        [DisplayName("End City")]
        public string EndCity { get; set; }

        public DateTime DepartureDate { get; set; }

        public int NoOfSeats { get; set; }

        [HiddenInput]
        public string hdStartCityCode { get; set; }

        [HiddenInput]
        public string hdEndCityCode { get; set; }

        public int NoOfAdults { get; set; }

        public int NoOfChildren { get; set; }

        public int NoOfInfants { get; set; }

        public int ChoosedSheet { get; set; }

        public string ChoosedBookingClass { get; set; }

        [Required(ErrorMessage = "*")]
        public string TitleName { get; set; }

        [Required(ErrorMessage = "*")]
        public string PNRFirstName { get; set; }

        public string PNRMiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        public string PNRLastName { get; set; }


        [Required(ErrorMessage = "*")]
        public string PNRContactNumber { get; set; }

        public string PNREmailAddress { get; set; }

        public string TravellerTitle { get; set; }
        public string TravellerFirstName { get; set; }
        public string TravellerMiddleName { get; set; }
        public string TravellerLastName { get; set; }
        public string TravellerGender { get; set; }
        public DateTime TravellerDOB { get; set; }

        public string TravellerPassportNumber { get; set; }

        public string TravellerMobileNumber { get; set; }

        public string TravellerEmailAddress { get; set; }


        [Required(ErrorMessage = "*")]
        public int TravellerAge { get; set; }

       
    }

}