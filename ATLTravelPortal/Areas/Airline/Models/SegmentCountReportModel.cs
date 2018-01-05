using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class SegmentCountReportModel
    {
        public string Info { get; set; }
        public string Jan { get; set; }
        public string Feb { get; set; }
        public string Mar { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string Jun { get; set; }
        public string July { get; set; }
        public string Aug { get; set; }
        public string Sep { get; set; }
        public string Oct { get; set; }
        public string Nov { get; set; }
        public string Dec { get; set; }

      
        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
        public int? AgentId { get; set; }

        [HiddenInput]
        public int? hdfAgentId { get; set; }

        private int ServiceProvider_Id = 1;
        [Required(ErrorMessage = " ")]
        [DisplayName("Service Provider")]
        public int ServiceProviderId
        {
            get
            {
                return ServiceProvider_Id;
            }
            set
            {
                ServiceProvider_Id = value;
            }
        }
        public string ServiceProviderName { get; set; }
        public IEnumerable<SelectListItem> ServiceProviderList { get; set; }


        private int Year_id = 2011;
        [Required(ErrorMessage = " ")]
        [DisplayName("Year")]
        public int YearId
        {
            get
            {
                return Year_id;
            }
            set
            {
                Year_id = value;
            }
        }
        public string YearName { get; set; }
        public IEnumerable<SelectListItem> YearList { get; set; }


        public IPagedList<SegmentCountReportModel> SegmentCountReportList { get; set; }

        public double SumJan { get; set; }
        public double SumFeb { get; set; }
        public double SumMarch { get; set; }
        public double SumApril { get; set; }
        public double SumMay { get; set; }
        public double SumJune { get; set; }
        public double SumJuly { get; set; }
        public double SumAug { get; set; }
        public double SumSep { get; set; }
        public double SumOct { get; set; }
        public double SumNov { get; set; }
        public double SumDec { get; set; }

        public double SumAllMonths { get; set; }

        public double SumBooked { get; set; }
        public double SumCancelled { get; set; }

    }

    public class SegmentCountReportExportModel
    {
        public string Info { get; set; }
        public string Jan { get; set; }
        public string Feb { get; set; }
        public string March { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string Jun { get; set; }
        public string July { get; set; }
        public string Aug { get; set; }
        public string Sep { get; set; }
        public string Oct { get; set; }
        public string Nov { get; set; }
        public string Dec { get; set; }


    }
}