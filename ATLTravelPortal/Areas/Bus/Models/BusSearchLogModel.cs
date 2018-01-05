using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Pagination;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusSearchLogModel
    {
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        public List<SelectListItem> AgentListddl { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public int? NoOfSearch { get; set; }

        public List<BusSearchLogModel> SeachList { get; set; }
       // public IPagedList<BusSearchLogModel> PagedList { get; set; }

        public BusMessageModel Message { get; set; }
    }
    
}



