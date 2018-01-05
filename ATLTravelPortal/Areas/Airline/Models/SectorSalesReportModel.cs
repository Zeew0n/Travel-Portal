using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class SectorSalesReportModel
    {
        [Required]
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }
       
        [DisplayName("Departs:")]
        public int DepartCityId { get; set; }
        public string DepartCity { get; set; }
        public IEnumerable<SelectListItem> DepartCityList { get; set; }


        [DisplayName("Arrive:")]
        public int ArriveCityId { get; set; }
        public string ArriveCity { get; set; }
        public IEnumerable<SelectListItem> ArriveCityList { get; set; }

        public int hdfDepartCityId { get; set; }
        public int hdfArriveCityId { get; set; }

        //[Required]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //[DisplayName("AirLine Types:")]
        //public int AirlineTypesId { get; set; }

        private int m_id = 1;
        [DisplayName("Airline Type:")]
        public int AirlineTypesId
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        public string AirlineTypes { get; set; }
        public IEnumerable<SelectListItem> AirlineTypesList { get; set; }


        public int? SegmentId { get; set; }

        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Agent:")]
        public int? AgentId { get; set; }
        public string Agent { get; set; }
        public IEnumerable<SelectListItem> AgentList { get; set; }

        //public string Departure { get; set; }
        //public string Arrival { get; set; }
        //public string Segment { get; set; }

        public decimal txtSumMainSegment { get; set; }
        public decimal txtSumSegment { get; set; }

        public string TicketStatusName { get; set; }

        public decimal txtSumTotalCancelledTicketStatus { get; set; }
        public decimal txtSumTotalBookedTicketStatus { get; set; }
        public decimal txtDifference { get; set; }


        public IEnumerable<SectorSalesReportModel> SegmentSalesReportList { get; set; }
        public IEnumerable<SectorSalesReportModel> SegmentSalesDetailsReportList { get; set; }





    }
}