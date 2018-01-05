using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class SpecialFaresModel
    {
        public int SpecialFareId { get; set; }
        public int SNO { get; set; }
        [Required(ErrorMessage=" ")]
        [DisplayName("From City")]
        public string FromCityName { get; set; }
        public int FromCityId { get; set; }
        public int hdfFromCityId { get; set; }

         [Required(ErrorMessage = " ")]
        [DisplayName("To City")]
        public string ToCityName { get; set; }
        public int ToCityId { get; set; }
        public int hdfToCityId { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Airline")]
        public string AirlineName { get; set; }
        public int AirlineId { get; set; }
        public int hdfAirlineName { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " ")]
        [DisplayName("Regular Fare")]
        public double? RegularFare { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " ")]
        [DisplayName("Special Fare")]
        public double? SpecialFare { get; set; }

         [Required(ErrorMessage = " ")]
        [DisplayName("Effective From")]
        public DateTime? EffectiveFrom { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Expire On")]
        public DateTime? ExpireOn { get; set; }
        

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public IPagedList<SpecialFaresModel> ListSpecialFares { get; set; }

    }
}