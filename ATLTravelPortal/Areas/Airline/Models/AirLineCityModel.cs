using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using ATLTravelPortal.Helpers;

namespace  ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineCityModel
    {
        public int CityID;

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(10, ErrorMessage = "Please enter <= 10 characters")]
        [DisplayName("Code")]
        public string CityCode { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(1000, ErrorMessage = "Please enter <= 1000 characters")]
        [DisplayName("Name")]
        public string CityName { get; set; }

        public string id;


        [Required(ErrorMessage = "*")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }



        [Required(ErrorMessage = "*")]
        [DisplayName("Airline City Type")]
        public int AirlineCityTypId { get; set; }
        public IEnumerable<SelectListItem> AirlineCityTypList { get; set; }

    }
}