using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Train.Models
{
    public class TrainSearchLogModel
    {

        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public int? NoOfSearch { get; set; }

        public List<TrainSearchLogModel> SeachList { get; set; }
        public IPagedList<TrainSearchLogModel> PagedList { get; set; }
    }
}