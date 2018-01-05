using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public enum CallType
    {
        Incoming,
        Outgoing
    }

    public class AgentCallLogModel
    {

        public CallType rdbCallType { get; set; }

        public int PhoneCallLogId { get; set; }
        public int SNO { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
        public int AgentId { get; set; }

        [HiddenInput]
        public int? hdfAgentId { get; set; }

        public string CategortId { get; set; }
        public string CategoryName { get; set; }

        public string SubCategortId { get; set; }
        public string SubCategoryName { get; set; }


        [DisplayName("For")]
        public int For_ProductId { get; set; }
        public string For_ProductName { get; set; }
        public IEnumerable<SelectListItem> For_ProductList { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("On")]
        public int? On_ServiceProviderId { get; set; }
        public string On_ServiceProviderName { get; set; }
        public IEnumerable<SelectListItem> On_ServiceProviderList { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Purpose")]
        public string Purpose { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        //[Required(ErrorMessage = " ")]
        [DisplayName("Call Duration")]
        public double CallDuration { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Call Duration")]
        public string Duration { get; set; }

        [DisplayName("Follow up this agent")]
        public bool Followupthisagent { get; set; }

        public int LoggedBy { get; set; }
        public string LoggedByName { get; set; }
        public DateTime LoggedDate { get; set; }

        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public bool outgoing { get; set; }
        public bool incoming { get; set; }

        public bool isDelete { get; set; }
        public int? commentid { get; set; }
        public int hdfComment { get; set; }
        [Required(ErrorMessage = " ")]
        public string Comment { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreatedDate { get; set; }

        public IEnumerable<AgentCallLogModel> CommentList { get; set; }


        public IPagedList<AgentCallLogModel> AgentFollowUpCallLogList { get; set; }
        public IEnumerable<AgentCallLogModel> AgentCallLogList { get; set; }
    }

}