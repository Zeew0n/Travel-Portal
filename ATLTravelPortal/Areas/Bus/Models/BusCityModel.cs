using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;
namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusCityModel
    {
        [DisplayName("City Name")]
        public int BusCityId { get; set; }
        [DisplayName("City Name")]
        [Required(ErrorMessage = "City Name required.")]
        public string BusCityName { get; set; }
        [DisplayName("City Code")]
        [Required(ErrorMessage = "City Name required.")]
        public string BusCityCode { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [DisplayName("Status Name")]
        public string StatusName { get; set; }
        public BusMessageModel Message { get; set; }
        public int SNo { get; set; }
        public IPagedList<BusCityModel> TabularList { get; set; }
    }
}