using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class UnApprovedVoucherModel
    {
        public Int64 VoucherNo { get; set; }

        public DateTime TranDate { get; set; }

        public string ProductName { get; set; }

        public string LedgerName { get; set; }

        public string Narration1 { get; set; }

        public Double? CreditAmount { get; set; }

        public Double? DebitAmount { get; set; }

        public IEnumerable<UnApprovedVoucherModel> UnApprovedVoucherList { get; set; }

    }
}