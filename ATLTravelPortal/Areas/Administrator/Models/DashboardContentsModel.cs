using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class DashboardContentsModel
    {
        public int DasbBoardContentId { get; set; }
        [Required(ErrorMessage = " ")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Body")]
        public string Body { get; set; }

        [DisplayName("IsPublished")]
        public bool IsPublished { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<DashboardContentsModel> ListDashboardContents { get; set; }
    }
}