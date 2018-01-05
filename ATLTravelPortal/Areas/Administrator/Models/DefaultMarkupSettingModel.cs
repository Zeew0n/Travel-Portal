using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class DefaultMarkupSettingModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Min Markup")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal MiniumMarkupValue { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Max Markup")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal MaximumMarkupValue { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Default Markup")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal DefaultMarkupValue { get; set; }

        [DisplayName("Apply the setting on all Agent now (Default values will apply on agent.)")]
        public bool isApplyOnAllEgent { get; set; }
       

    }
    }
