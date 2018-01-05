using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageCustomizeInquiryModel : FormPropertyModel<AirPackageCustomizeInquiryModel>
    {

        public int PId { get; set; }
        public int AgentId { get; set; }

        public int SNO { get; set; }
        public DateTime? TravelDateStart { get; set; }
        public DateTime? TravelDateEnd { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int? NoOfAdult { get; set; }
        public int? NoOfChild { get; set; }
        public string ContactNo { get; set; }
        public string Remark { get; set; }

        public string Status { get; set; }
        public string AgentName { get; set; }
       

    }
}