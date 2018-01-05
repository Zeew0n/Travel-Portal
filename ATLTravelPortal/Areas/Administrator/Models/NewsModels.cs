using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class NewsModel: FormPropertyModel<NewsModel>
    {
        public int PId { get; set; }
        
        [Required(ErrorMessage = "Title Required")]
        [DisplayName("Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "URL Required")]
        [DisplayName("URL:")]
        public string URL { get; set; }

        [Required(ErrorMessage = "Summary Required")]
        [DisplayName("Summary:")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [DisplayName("Description:")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "IsPublish Required")]
        [DisplayName("IsPublish:")]
        public bool IsPublish { get; set; }
    }
}