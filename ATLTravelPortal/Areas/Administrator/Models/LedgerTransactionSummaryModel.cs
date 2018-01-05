using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class LedgerTransactionSummaryModel
    {
        #region Filter Parameters

        [DisplayName("Products")]
        public int? ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductsOption { get; set; }
        [DisplayName("Currency")]
        [Required(ErrorMessage = "*")]
        public int CurrencyId { get; set; }
        public IEnumerable<SelectListItem> CurrencyOption { get; set; }
        [DisplayName("Ledger Of")]
        [Required(ErrorMessage = "*")]
        public int LedgerOf { get; set; }
        public IEnumerable<SelectListItem> LedgerOfOption { get; set; }
        [DisplayName("Date From")]
        [Required(ErrorMessage = "*")]
        public DateTime DateFrom { get; set; }
        [DisplayName("Date To")]
        [Required(ErrorMessage = "*")]
        public DateTime DateTo { get; set; }
        [DisplayName("Filter Type")]
        public int? FilterType { get; set; }
        public IEnumerable<SelectListItem> FilterTypeOption { get; set; }
        [DisplayName("Filter Value")]
        public float FilterValue { get; set; }

        public IEnumerable<LedgerTransactionSummaryModel> LedgerTransactionList {get;set;}

        #endregion

        public Int64? LedgerId { get; set; }
        public string LedgerName { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? Dr { get; set; }
        public decimal? Cr { get; set; }
        public decimal? ClosingBalance { get; set; }

    }
}