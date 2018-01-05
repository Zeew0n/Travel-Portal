using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class CountryManagementModel
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-zA-Z]{0,3}$", ErrorMessage = " ")]
        [DisplayName("Code")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        public string CountryStatus { get; set; }

        public IPagedList<CountryManagementModel> CountryManagementList { get; set; }
    }
}