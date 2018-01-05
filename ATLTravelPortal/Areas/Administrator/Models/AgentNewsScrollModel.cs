using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentNewsScrollModel
    {
        [Required]
        [DisplayName("News Text:")]
        public string NewsText { get; set; }

        [DisplayName("IsActive:")]
        public bool IsActive { get; set; }

        public int ScrollNewsId { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        

        public IEnumerable<AgentNewsScrollModel> NewsScrollList { get; set; }

    }
}