using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class CreditLimitModel
    {
        [DisplayName("Agent")]
        public string AgencyName { get; set; }
        public string AgencyCode { get; set; }
        public int ddlAgentId { get; set; }
      
        public IEnumerable<SelectListItem> AgentList { get; set; }


        [Required]
        [DisplayName("Type")]
        public string txtType { get; set; }
        public int ddlTypeId { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }


        [DisplayName("Bank")]
        public string BankName { get; set; }
        public int? ddlBankId { get; set; }
        public IEnumerable<SelectListItem> BankList { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Amount")]
        public Double? txtAmount { get; set; }

        [Required]
        [DisplayName("Currency")]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Effective From")]
        public DateTime? FromDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Expire On")]
        public DateTime? ToDate { get; set; }

        public int CheckerId { get; set; }
        public string CreatedBy { get; set; }

        public int MakerId { get; set; }
        public bool? isApproved { get; set; }
        public string ApprovedBy { get; set; }
        public bool? isActive { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Remarks")]
        public string Comments { get; set; }

        public int CreditLimitTypeId { get; set; }
        public string CreditLimitTypeName { get; set; }

        public IEnumerable<CreditLimitModel> CreditLimitList { get; set; }

        public IEnumerable<CreditLimitModel> CreditLimitDetailList { get; set; }

        public CreditLimitModel CreditLimit { get; set; }

        public int AgentCreditLimitId { get; set; }

        public bool hdBank { get; set; }
        public bool hdEffectiveFrom { get; set; }
        public bool hdExpireOn { get; set; }
        public bool hdAmount { get; set; }
        public bool showbutton { get; set; }
        public bool showfield { get; set; }


        [HiddenInput]
        public int? hdfbank { get; set; }
        [HiddenInput]
        public DateTime? hdfEffectiveFrom { get; set; }
        [HiddenInput]
        public DateTime? hdfExpireOn { get; set; }
        [HiddenInput]
        public int hdfagentid { get; set; }
        [HiddenInput]
        public int hdfTypeid { get; set; }


        public int agentid { get; set; }

        public string hdfminDate { get; set; }
        public string hdfmaxDate { get; set; }


      
        public IEnumerable<SelectListItem> Currencies { get; set; }
        public int? DaysLeft { get; set; }

        public int AmountType { get; set; }

        public bool ShowHideAmountType { get; set; }
    }
}