using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class LedgerVoucherModel
    {
        public Int64 TranID { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Tran Date")]
        public DateTime TranDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
        [Range(1, int.MaxValue, ErrorMessage = "*")]
        // [Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        public int AgentId { get; set; }

        public string AgentName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Tran Mode")]
        public string TranMode { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Amount")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number!!")]
        public decimal TranAmount { get; set; }

        [DisplayName("Refrence No")]
        public string RefrenceNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Narration1")]
        public string Narration1 { get; set; }


        [DisplayName("Narration2")]
        public string Narration2 { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Amount In Words")]
        public string AmountInWords { get; set; }

        public int AppUserId { get; set; }
        public int? MakerID { get; set; }
        public string MakerName { get; set; }
        public DateTime MakerDate { get; set; }
        public int? CheckerID { get; set; }
        public string CheckerName { get; set; }
        public DateTime? CheckerDate { get; set; }

        public string CheckerTerminal { get; set; }
        [Required]
        [DisplayName("Remark")]
        public string CheckerRemark { get; set; }
        public int? DeletedBy { get; set; }
        public string DeletedName { get; set; }
        public DateTime? DeleteDate { get; set; }

        [DisplayName("Apply Date Filter")]
        // [Required(ErrorMessage = "*")]
        public bool AppliedDate { get; set; }

        [DisplayName("From Date")]
        // [Required(ErrorMessage = "*")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        // [Required(ErrorMessage = "*")]
        public DateTime ToDate { get; set; }

        [DisplayName("UnApproved")]
        public bool UnApproved { get; set; }

        public IEnumerable<LedgerVoucherModel> LedgerVoucherlist { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long VoucherNumber { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int CurrencyID { get; set; }

        [Required(ErrorMessage=" ")]
        public Int64 VoucherNo { get; set; }

        public IEnumerable<LedgerVoucherModel> TransactionList { get; set; }

        public string Debit { get; set; }
        public string Credit { get; set; }
        public Double Amount { get; set; }
        public Decimal txtSumDrAmount { get; set; }
        public Decimal txtSumCrAmount { get; set; }

        public string LegderName { get; set; }
        public int TranStatusId { get; set; }
        public string TranStatusName { get; set; }


        [Required(ErrorMessage=" ")]
        public string DeleteRemark { get; set; }

        public IEnumerable<SelectListItem> ProductList { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }

        public double DebitAmount { get; set; }
        public double CreditAmount { get; set; }
        public Int64 LedgerId { get; set; }

        public List<LedgerVoucherModel> TranList { get; set; }

    }
}