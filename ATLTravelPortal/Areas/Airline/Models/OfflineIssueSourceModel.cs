using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class OfflineIssueSourceModel
    {
        public int OfflineBookingServiceProviderId { get; set; }
        [Required]
        [DisplayName("Source Name:")]
        public string ServiceProvider { get; set; }
        public bool IsActive { get; set; }
        public IPagedList<OfflineIssueSourceModel> SourceList { get; set; }
    }
}