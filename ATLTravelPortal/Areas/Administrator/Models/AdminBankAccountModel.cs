using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AdminBankAccountModel
    {
        public int AdminBankId { get; set; }

        [Required]
        [DisplayName("Bank")]
        public int BankId { get; set; }
        public string BankName { get; set; }
        public IEnumerable<SelectListItem> BankNameList { get; set; }

        [Required]
        [DisplayName("Bank Branch")]
        public int BankBranchId { get; set; }
        public string BankBranchName { get; set; }
        public IEnumerable<SelectListItem> BankBranchNameList { get; set; }

        [Required]
        [DisplayName("Bank Account Type")]
        public int BankAccountTypeId { get; set; }
        public string BankAccountTypeName { get; set; }
        public IEnumerable<SelectListItem> BankAccountTypeNameList { get; set; }

        [Required]
        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        [Required]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        public IEnumerable<AdminBankAccountModel> AdminBankAccountList { get; set; }

        public IEnumerable<SelectListItem> ddlBankList { get; set; }
        public IEnumerable<SelectListItem> ddlBankBranchList { get; set; }
        public IEnumerable<SelectListItem> ddlAccountTypeList { get; set; }

    }
}