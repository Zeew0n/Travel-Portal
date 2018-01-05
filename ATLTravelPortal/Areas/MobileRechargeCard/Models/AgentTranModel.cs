using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Models
{
    public class AgentTranModel
    {
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public bool? IsSuccess { get; set; }
        public string TranDate { get; set; }
        public int? TranCount { get; set; }
        [DisplayName("Report Type")]
        public string ReportType { get; set; }
        public List<SelectListItem> ddlReportType { get; set; }
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }
        public List<AgentTranModel> List { get; set; }
    }
}