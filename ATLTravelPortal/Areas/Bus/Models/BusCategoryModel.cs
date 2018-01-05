using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusCategoryModel
    {
        [DisplayName("Category Name")]
        public int BusCategoryId { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name required.")]
        public string BusCategoryName { get; set; }
        public int SNo { get; set; }
        public BusMessageModel Message { get; set; }
        public IPagedList<BusCategoryModel> TabularList { get; set; }
    }
}