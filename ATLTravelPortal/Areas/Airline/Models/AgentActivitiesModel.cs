using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentActivitiesModel
    {
        public string AgentName { get; set; }
        public int? Booked { get; set; }
        public int? Cancelled { get; set; }
        public int? Issued { get; set; }
        public int? Void { get; set; }
        public int? TotalLogin { get; set; }
        public string LastLogin { get; set; }
        public int? GDSHits { get; set; }
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To")]
        public DateTime? ToDate { get; set; }


        [DisplayName("Agent:")]
        public int? AgentId { get; set; }
        


       //public IEnumerable<AgentActivitiesModel> AgentActivitesList { get; set; }
        public IPagedList<AgentActivitiesModel> AgentActivitesList { get; set; }

        public decimal SumBooked { get; set; }
        public decimal SumCancelled { get; set; }
        public decimal SumIssued { get; set; }
        public decimal SumVoid { get; set; }
        public decimal SumTotalLogin { get; set; }
        public decimal SumTotalGDSHits { get; set; }


    }
}