using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class MEsCreditLimitModel
    {
        public int MEsCreditLimitId { get; set; }

            public int MEsID { get; set; }
            public string MEsName { get; set; }

            public int CurrencyID { get; set; }
            public string CurrencyCode { get; set; }

            [DisplayName("Amount")]
            [Required(ErrorMessage = "*")]
            public double? Amount { get; set; }

            [DisplayName("Effective Date")]
            [Required(ErrorMessage = "*")]
            public DateTime EffictiveFrom { get; set; }

            [DisplayName("Expire Date") ]
            [Required(ErrorMessage = "*")]
            public DateTime ExpireOn{get;set;}

            public int status { get; set; }

         
           public IEnumerable<SelectListItem> CurrencyList { get; set; }
           public IEnumerable<SelectListItem> MEsList { get; set; }
           public List<MEsCreditLimitModel> MEsCreditLimitList { get; set; }
    }
}