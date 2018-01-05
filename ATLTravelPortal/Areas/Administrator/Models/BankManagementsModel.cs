using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class BankManagementsModel
    {
         public int BankId { get; set; }
       
        public string BankName { get; set; }
        
        public string BankAddress { get; set; }
        
        public string PhoneNo { get; set; }
        
        public string ContactPerson { get; set; }
       
        public string ContactPersonPhoneNo { get; set; }
       
        public string ContactPersonMobileNo { get; set; }
        
        public string ContactPersonEmail { get; set; }
        public int CountryId { get; set; }
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
        public IEnumerable<BranchManagementsModel> GetAllBranch { get; set; }
        public BranchManagementsModel Branch { get; set; }
        public IEnumerable<BankManagementsModel> BankList { get; set; }

        public IEnumerable<SelectListItem> ddlCountriesList { get; set; }
    }
    
}