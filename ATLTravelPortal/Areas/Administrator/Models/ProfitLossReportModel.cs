using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ProfitLossReportModel
    {
        [DisplayName("Ledger Name")]
        public string txtLedgerName { get; set; }

        [DisplayName("Expenses")]
        public decimal? txtExpenses { get; set; }

        [DisplayName("Income")]
        public decimal? txtIncome { get; set; }

        [DisplayName("Apply Date Filter")]
        public bool AppliedDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Product:")]
        [Range(1, int.MaxValue, ErrorMessage = "*")]
        public int ProductId { get; set; }

        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [DisplayName("To")]
        public DateTime ToDate { get; set; }

        [DisplayName("Amount")]
        public string txtExpensesAmount { get; set; }

        [DisplayName("Amount")]
        public string txtIncomeAmount { get; set; }

        public Decimal txtSumExpenses { get; set; }
        public Decimal txtSumIncome { get; set; }

        public decimal txtLiabilities { get; set; }
        public decimal txtAsset { get; set; }
        public decimal txtSumLiabilities { get; set; }
        public decimal txtSumAsset { get; set; }
        public IEnumerable<ProfitLossReportModel> BalanceSheetList { get; set; }
        public IEnumerable<ProfitLossReportModel> ProfitLossReportlist { get; set; }
    }
}