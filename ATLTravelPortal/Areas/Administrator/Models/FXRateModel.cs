using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class FXRateModel
    {
        [Required]
        [Range(1, 9999999999999999999)]
        [DisplayName("Rate")]
        public Double? ExchangeRate { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public bool isApproved { get; set; }

        public int FXRateId { get; set; }

        public int SNO { get; set; }

        public IPagedList<FXRateModel> FXRateList { get; set; }
    }
}