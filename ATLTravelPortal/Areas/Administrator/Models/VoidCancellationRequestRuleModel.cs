using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class VoidCancellationRequestRuleModel
    {
        [Required]
        public int? ProductId { get; set;}
        public int? temp { get; set;}
        public IEnumerable<SelectListItem> ProductOption { get; set;}

        [Required]
        public int RuleOnId { get; set;}
        public IEnumerable<SelectListItem> RuleOnOption { get; set;}

        public int VoidCancellationRuleId { get; set;}
        public string Product { get; set;}
        public bool SunDay { get; set;}
        public bool MonDay { get; set;}
        public bool TuesDay { get; set; }
        public bool WednesDay { get; set; }
        public bool ThrusDay { get; set; }
        public bool FriDay { get; set; }
        public bool SaturDay { get; set;}
        public string RuleOn { get; set;}
        public DateTime CreatedDate { get; set;}
        public int CreatedBy { get; set;}

        public DateTime UpdatedDate { get; set;}
        public int UpdatedBy { get; set;}
        [Required]
        public TimeSpan FromTime { get; set;}
        [Required]
        public TimeSpan ToTime { get; set; }

        [Required]
        public int WithinHour { get; set;}

        public IEnumerable<VoidCancellationRequestRuleModel> VoidCancellationRequestList { get; set;}

    }
}