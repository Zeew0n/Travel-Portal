using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ContentsModel
    {
        public int ContentId { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Title")]
        public string Title { get; set; }

        public string Value { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("URL")]
        public string URL { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Body")]
        public string Body { get; set; }

       
        [DisplayName("IsPublish")]
        public bool isPublish { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public int UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DomainName { get; set; }

        public IPagedList<ContentsModel> ListContents { get; set; }

        



        
    }
}