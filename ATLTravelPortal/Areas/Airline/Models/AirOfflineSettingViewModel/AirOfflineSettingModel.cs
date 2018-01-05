using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel
{
    public class AirOfflineSettingModel
    {
        public AirOfflineSettingModel()
        {
            AirlineList = new List<AirOfflineSettingModel>();
        }

        public int PId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCode { get; set; }
        public int AirlineId { get; set; }
        public bool IsOffline { get; set; }
        public List<AirOfflineSettingModel> AirlineList { get; set; }
    }
}