using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel
{
    public class OnLineAirlineSettingsModel
    {
        public int OnlineAirlineSettingId { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Service Provider")]
        public int ServiceProvider { get; set; }
        public string ServiceProviderName { get; set; }
        public IEnumerable<SelectListItem> ServiceProviderList { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Airline Code")]
        public string AirlineCode { get; set; }

        public string AirlineName { get; set; }

        [HiddenInput]
        public int? hdfAirlineName { get; set; }


        public int CreatedBy { get; set; }

        public IEnumerable<OnLineAirlineSettingsModel> OnLineAirlineSettingList { get; set; }


       


    }
}