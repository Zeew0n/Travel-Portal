using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Models
{
    public class CardValueModel
    {
        [DisplayName("Card Value")]
        public int CardValueId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Value")]
        public double CardValue { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Value Desc")]
        public string CardValueDesc { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public string StarusName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
         [DisplayName("Status")]
        public string StatusName { get; set; }

        public IEnumerable<CardValueModel> CardValueList { get; set; }
        public IEnumerable<SelectListItem> CardStatusList { get; set; }
    }
}