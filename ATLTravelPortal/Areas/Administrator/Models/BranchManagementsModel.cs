using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class BranchManagementsModel
    {
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchPhoneNumber { get; set; }
        public string BranchContactPerson { get; set; }
        public string BranchContactPhoneNo { get; set; }
        public string BranchContactEmail { get; set; }
        public string hfCheckBankOrBranch { get; set; }
        public string Message { get; set; }
        public int BranchCountryId { get; set; }
        public int BankBranchId { get; set; }
        public int CountryId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public IEnumerable<BranchManagementsModel> GetBranchList { get; set; }
    }
}