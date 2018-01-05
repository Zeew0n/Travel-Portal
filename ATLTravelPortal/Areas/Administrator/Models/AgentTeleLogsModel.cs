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
    public class AgentTeleLogsModel
    {
        public int AgentTeleLogId { get; set; }
        public int SNO { get; set; }
        [Required(ErrorMessage = " ")]
        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
        public int AgentId { get; set; }


        [HiddenInput]
        public int? hdfAgentId { get; set; }
        
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [DisplayName("Problem Category")]
        public string ProblemCategoryId { get; set; }
        public string ProblemCategoryName { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Competitor Information")]
        public string CompetitorInformation { get; set; }

        [DisplayName("Follow Up")]
        public bool isNeededFollowUp { get; set; }

        [DisplayName("Created By")]
        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        public bool isDelete { get; set; }
        public int? commentid { get; set; }
        public int hdfComment { get; set; }

        [Required(ErrorMessage = " ")]
        public string Comment { get; set; }

        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public List<AgentTeleLogsModel> CommentList { get; set; }
        //public List<AgentTeleLogsModel> AgentTeleLogsFollowupList { get; set; }
        public List<AgentTeleLogsModel> AgentTeleLogsList { get; set; }
        public IPagedList<AgentTeleLogsModel> AgentActivitesList { get; set; }
        public IPagedList<AgentTeleLogsModel> AgentTeleLogsFollowupList { get; set; }













       



    }
}