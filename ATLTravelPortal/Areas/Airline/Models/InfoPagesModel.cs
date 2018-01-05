using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class InfoPagesModel
    {
        public int InfoId { get; set; }
        public int SNO { get; set; }
        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Title:")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Description:")]
        public string Description { get; set; }
        public IPagedList<InfoPagesModel> InfoPagesList { get; set; }
    }
}