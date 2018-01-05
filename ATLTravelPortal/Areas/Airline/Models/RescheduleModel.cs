using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class RescheduleModel
    {
        [DisplayName("Departure City")]
        public string deptcity { get; set; }

        [DisplayName("Destination City")]
        public string destncity { get; set; }

        [DisplayName("From Date")]
        public string fromdatestring { get; set; }
        public DateTime fromdate { get; set; }

        [DisplayName("To Date")]
        public DateTime todate { get; set; }
        public string todatestring { get; set; }     

        [DisplayName("Departure Time")]
        public TimeSpan depttime { get; set; }

        [DisplayName("Arrival Time")]
        public TimeSpan arrivaltime { get; set; }
    }
}