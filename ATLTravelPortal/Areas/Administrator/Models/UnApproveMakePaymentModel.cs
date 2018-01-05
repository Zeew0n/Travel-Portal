using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class UnApproveMakePaymentModel
    {
        public UnApproveMakePaymentModel()
        {
            ChequeList = new List<UnApproveMakePaymentModel>();
   
        }
        public Int64 DepositId { get; set; }
        public enum PaymentMode
        {
            Cheque=1,
            Draft=2,
            Cash=3,
            BankTransfer=4,
            RTGS=5,
            CashGivenTo=6
        }
        public PaymentMode rdbPaymentMode { get; set; }

        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }

        [DisplayName("Agent Id")]
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }

        [Required]
        [Range(1, 9999999999999999999)]
        [DisplayName("Amount")]
        public double Amount { get; set; }


        [Required]
        [Range(1, 9999999999999999999)]
        [DisplayName("Amount")]
        public double? CashGivenToAmount { get; set; }


        [Required]
        [Range(1, 9999999999999999999)]
        [DisplayName("Amount")]
        public double? RTGSAmount { get; set; }

        [Required]
        [Range(1, 9999999999999999999)]
        [DisplayName("Amount")]
        public double? BankTransferAmount { get; set; }


        [Required]
        [Range(1, 99999999999999999)]
        [DisplayName("Amount")]
        public double? ChequeAmount { get; set; }

        [Required]
        [Range(1, 99999999999999999)]
        [DisplayName("Amount")]
        public double? DraftAmount { get; set; }

        [Required]
        [Range(1, 99999999999999999)]
        [DisplayName("Amount")]
        public double? CashAmount { get; set; }


        [Required]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        public string BankTransferMobileNumber { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        public string ChequeMobileNumber { get; set; }
      
        [DisplayName("Transaction Id")]
        public string TransactionId { get; set; }

        [DisplayName("Transaction Id")]
        public string BankTransferTransactionId { get; set; }

        [DisplayName("Transaction Id")]
        public string ChequeTransactionId { get; set; }

        [DisplayName("Transaction Id")]
        public string CashTransactionId { get; set; }


        [Required]
        [DisplayName("Cheque Drawn on Bank")]
        public int ChequeDrawnonBank { get; set; }
        public string ChequeDrawnonBankName { get; set; }

        [Required]
        [DisplayName("Cheque Issue Date")]
        public DateTime? ChequeIssueDate { get; set; }

        [Required]
        [DisplayName("Cheque Number")]
        public string ChequeNumber { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int BankId { get; set; }
        public string BankName { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int RTGSBankId { get; set; }
        public string RTSSBankName { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int BankTransferBankId { get; set; }
        public string BankTransferBankName { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int DraftBankId { get; set; }
        public string DraftBankName { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int ChequeBankId { get; set; }
        public string ChequeBankName { get; set; }

        [Required]
        [DisplayName("Deposited In Bank")]
        public int CashBankId { get; set; }
        public string CashBankName { get; set; }

        [DisplayName("Bank Branch")]
        public int BankBranchId { get; set; }
        public string BranchName { get; set; }

        [DisplayName("Bank Branch")]
        public int RTGSBankBranchId { get; set; }
        public string RTGSBranchName { get; set; }

        [DisplayName("Bank Branch")]
        public int BankTransferBankBranchId { get; set; }
        public string BankTransferBranchName { get; set; }

        [DisplayName("Bank Branch")]
        public int CashBankBranchId { get; set; }
        public string CashBranchName { get; set; }



        [DisplayName("Bank Branch")]
        public int ChequeBankBranchId { get; set; }
        public string ChequeBranchName { get; set; }

        [DisplayName("Bank Branch")]
        public int DraftBankBranchId { get; set; }
        public string DraftBranchName { get; set; }

        [DisplayName("Remarks")]
        public string Remakrs { get; set; }

        [DisplayName("Remarks")]
        public string CashGivenToRemakrs { get; set; }

        [DisplayName("Remarks")]
        public string RTGSRemakrs { get; set; }

        [DisplayName("Remarks")]
        public string BankTransferRemakrs { get; set; }

        [DisplayName("Remarks")]
        public string CashRemakrs { get; set; }


        [DisplayName("Remarks")]
        public string ChequeRemakrs { get; set; }

        [DisplayName("Remarks")]
        public string DraftRemakrs { get; set; }

        [Required]
        [DisplayName("Draft Number")]
        public string DraftNumber { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime DepositDate { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? CashGivenToDepositDate { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? RTGSDepositDate { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? BankTransferDepositDate { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? CashDepositDate { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? DraftDepositDate { get; set; }

        [Required]
        [DisplayName("UTR Number")]
        public string RTGSUTRNumber { get; set; }

        [Required]
        [DisplayName("Sales Agent")]
        public int SalesAgent { get; set; }
        public string SalesAgentName { get; set; }
        public IEnumerable<SelectListItem> SalesAgentList { get; set; }

      
        [DisplayName("Account Number")]
        public string AccountId { get; set; }

      
        [DisplayName("Currency")]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        public int CreatedBy { get; set; }

        public string InstrumentNo { get; set; }
        public bool isApproved { get; set; }
        public int Status { get; set; }

        [Required]
        public string CashGivenToDate { get; set; }
         [Required]
        public string ChequeDate { get; set; }
         [Required]
        public string DraftDate { get; set; }
         [Required]
        public string CashDate { get; set; }
         [Required]
        public string BankTransferDate { get; set; }
         [Required]
        public string RTGSDate { get; set; }

         public IEnumerable<UnApproveMakePaymentModel> UnAppoveMakePaymentList { get; set; }


        public List<UnApproveMakePaymentModel> ChequeList { get; set; }
        public IEnumerable<UnApproveMakePaymentModel> DraftList { get; set; }
        public IEnumerable<UnApproveMakePaymentModel> CashList { get; set; }
        public IEnumerable<UnApproveMakePaymentModel> BankTransferList { get; set; }
        public IEnumerable<UnApproveMakePaymentModel> RTGSList { get; set; }
        public IEnumerable<UnApproveMakePaymentModel> CashGivenToList { get; set; }
    }
}