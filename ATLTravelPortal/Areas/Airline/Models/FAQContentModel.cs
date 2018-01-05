using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class FAQContentModel
    {
        public int FaqId { get; set; }
        public int SNO { get; set; }
        [Required]
        [DisplayName("Heading:")]
        public int HeadingId { get; set; }
        public string HeadingTitle { get; set; }
        [Required]
        [DisplayName("Question:")]
        public string Question { get; set; }
        [Required]
        [DisplayName("Answer:")]
        public string Answer { get; set; }
        public bool statusId { get; set; }

        [DisplayName("Created By:")]
        public int? CreatedBy { get; set; }
        public string CreatorName { get; set; }

        [DisplayName("Created Date:")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Updated By:")]
        public int? UpdatedBy { get; set; }
        public string UpdatorName { get; set; }

        [DisplayName("Updated Date:")]
        public DateTime? UpdatedDate { get; set; }

        public IEnumerable<SelectListItem> ddlHeadingList { get; set; }
        public IPagedList<FAQContentModel> FAQContentList { get; set; }
    }
}