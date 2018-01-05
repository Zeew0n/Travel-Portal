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
    public class TagsModel : FormPropertyModel<TagsModel>
    {

        public int PId { get; set; }

        [Required(ErrorMessage = "Tag Name Required")]
        [DisplayName("Tag Name:")]
        public string Name { get; set; }

        


    }
}