using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class FAQHeadingModel
    {
        public int HeadingId { get; set; }
        public int SNO { get; set; }
        [Required]
        [DisplayName("Heading:")]
        public string Title { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IPagedList<FAQHeadingModel> FAQHeadingList { get; set; }
    }
}