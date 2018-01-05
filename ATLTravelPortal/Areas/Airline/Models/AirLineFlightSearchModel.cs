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
    public class AirLineFlightSearchModels
    {
        [Required(ErrorMessage = "Please Select Departure City")]
        [DisplayName("Departure City")]
        public string DepartureCity_Name { get; set; }
        //public int DepartureCity { get; set; }

        [Required(ErrorMessage = "Please Select Destination City")]
        [DisplayName("Destination City")]
        public string DestinationCity_Name { get; set; }
        //public int DestinationCity { get; set; }

        [DisplayName("AirLineName")]
        public string AirLineName { get; set; }
        [DisplayName("FlightNumber")]
        public string FlightNumber { get; set; }

        [DisplayName("FlightRate")]
        public double FlightRate { get; set; }

        [DisplayName("FlightTime")]
        public Single FlightTime { get; set; }
        public IEnumerable<SelectListItem> DepartureCityList { get; set; }
        public IEnumerable<SelectListItem> DestinationCityList { get; set; }

        public string id { get; set; }      
        //public string DepartureCity_Name { get; set; }
        //public string DestinationCity_Name { get; set; }

        public int DepartureCity { get; set; }
        public int DestinationCity { get; set; }
        public IEnumerable<AirLineFlightSearchModels> airLineFlightSearchList { get; set; }
        
        public List<double> TotalRate { get; set; }
        public List<float> TotalFlightTime { get; set; }
        public DictionaryEntry Group;
        
        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }

        [HiddenInput]
        public int Json_Departure_city_Id { get; set; }

        [HiddenInput]
        public int Json_Destination_city_Id { get; set; }

    }
}