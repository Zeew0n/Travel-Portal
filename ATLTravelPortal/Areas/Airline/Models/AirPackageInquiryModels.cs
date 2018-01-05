using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Models;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageInquiryModel : FormPropertyModel<AirPackageInquiryModel>
    {

        public int PId { get; set; }
        public int SNO { get; set; }
        public int AgentId { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Title { get; set; }
        public DateTime? TravelDate { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int? NoOfAdult { get; set; }
        public int? NoOfChild { get; set; }
        public string ContactNo { get; set; }
        public string Remark { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string Status { get; set; }
        public string AgentName { get; set; }

        public PackageModel packageDetail { get; set; }

        public IPagedList<AirPackageInquiryModel> PackagesList { get; set; }
    }
}