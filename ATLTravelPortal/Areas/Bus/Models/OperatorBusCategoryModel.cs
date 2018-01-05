using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ATLTravelPortal.Areas.Bus.Models
{
    public class OperatorBusCategoryModel
    {
        public int OBCategoryId { get; set; }

        [DisplayName("Operator Name")]
        [Required(ErrorMessage = "Operator Name required.")]
        public int BusMasterId { get; set; }
        public string BusMasterName { get; set; }
        public IEnumerable<SelectListItem> ddlBusMasterList { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name required.")]
        public int BusCategoryId { get; set; }
        public string BusCategorName { get; set; }
        public IEnumerable<SelectListItem> ddlBusCategorList { get; set; }

        [DisplayName("Facility")]
        [Required(ErrorMessage = "Facility required.")]
        public string FacilityDetails { get; set; }
        [DisplayName("Fare Rules")]
        [Required(ErrorMessage = "Fare Rulese required.")]
        public string FareRules { get; set; }

        public BusMessageModel Message { get; set; }
        public int Sno { get; set; }
        public IPagedList<OperatorBusCategoryModel> TabularList { get; set; }
    }
}