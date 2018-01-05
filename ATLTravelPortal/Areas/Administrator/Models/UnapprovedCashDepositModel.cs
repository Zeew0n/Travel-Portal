using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class UnapprovedCashDepositModel
    {
        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName("Deposit Date")]
        public DateTime DepositDate { get; set; }

        [DisplayName("Bank")]
        public string BankName { get; set; }

        [DisplayName("Branch")]
        public string BranchName { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Amount")]
        public double Amount { get; set; }

        [DisplayName("Currency")]
        public string Currency { get; set; }


        [DisplayName("Payment Mode")]
        public string PaymentModes { get; set; }

        [DisplayName("Insturment No")]
        public string InstrumentNo { get; set; }

        [DisplayName("CreatedBy")]
        public string CreatdBy { get; set; }

        [DisplayName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        public Int64 DepositId { get; set; }

       public IEnumerable<UnapprovedCashDepositModel> unapprovedCashDepositList { get; set; }

    }
}