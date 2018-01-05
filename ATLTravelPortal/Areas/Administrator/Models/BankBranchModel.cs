using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class BankBranchModel
    {
        public int BankId { get; set; }

        [Required(ErrorMessage = " ")]
        public string BankName { get; set; }

        public string BankAddress { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string PhoneNo { get; set; }

       [Required(ErrorMessage = " ")]
       [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        public string ContactPerson { get; set; }

        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string ContactPersonPhoneNo { get; set; }

        public string ContactPersonMobileNo { get; set; }

        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\b([,;]\s?)?)*$", ErrorMessage = "Not a valid Email")]
        public string ContactPersonEmail { get; set; }

        public int CountryId { get; set; }

        [Required(ErrorMessage = " ")]
        public string Country { get; set; }

        [Required(ErrorMessage = " ")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = " ")]
        public string BranchAddress { get; set; }
        public string BranchPhoneNumber { get; set; }
        public string BranchContactPerson { get; set; }
        public string BranchContactPhoneNo { get; set; }
        public string BranchContactEmail { get; set; }
        public int hfCheckBankOrBranch { get; set; }
        public string Message { get; set; }
        public int BranchCountryId { get; set; }
        public int BankBranchId { get; set; }
        public int hfBankId { get; set; }
        public int hfCount { get; set; }
        public int hfBranchId { get; set; }
        public string BranchCountryName { get; set; }
        public IEnumerable<BankBranchModel> BankBranchList { get; set; }
        public BankBranchModel Branch { get; set; }
        public IEnumerable<BankBranchModel> BankList { get; set; }

        public IEnumerable<SelectListItem> ddlCountriesList { get; set; }
        public IEnumerable<SelectListItem> ddlBankList { get; set; }
    }
}