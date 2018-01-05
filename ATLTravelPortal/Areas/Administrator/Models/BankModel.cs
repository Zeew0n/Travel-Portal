using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class BankModel
    {
        public int BankId { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string BankAddress { get; set; }

        [Required]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string PhoneNo { get; set; }

        [Required]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        public string ContactPerson { get; set; }


        //[RegularExpression(@"^(\d+[ \-]+\d+)$", ErrorMessage = "Must contain digit.")]
         [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string ContactPersonPhoneNo { get; set; }


       [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public string ContactPersonMobileNo { get; set; }

        
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        public string ContactPersonEmail { get; set; }
        public int CountryId { get; set; }

        [Required(ErrorMessage = " ")]
        public string Country { get; set; }
        public string BranchName { get; set; }
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
        public IEnumerable<BankModel> GetAllBranch { get; set; }
        public BankModel Branch { get; set; }
        public IEnumerable<BankModel> BankList { get; set; }

        public IEnumerable<SelectListItem> ddlCountriesList { get; set; }

       
    }
}