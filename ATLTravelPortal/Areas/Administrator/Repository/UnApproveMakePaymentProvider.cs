using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class UnApproveMakePaymentProvider
    {
        EntityModel ent = new EntityModel();
        AvailableBalanceProvider ser = new AvailableBalanceProvider();
        //for listing 
        public List<UnApproveMakePaymentModel> GetUnApprovedMakePaymentList()
        {
            List<UnApproveMakePaymentModel> model = new List<UnApproveMakePaymentModel>();

            var result = ent.Core_AgentCashDeposits.Where(x => x.Status == 2).OrderByDescending(xx => xx.CreatedDate).AsEnumerable();
            foreach (var item in result)
            {
                UnApproveMakePaymentModel obj = new UnApproveMakePaymentModel
                {
                    AgentId = item.AgentId,
                    AgentName = item.Agents.AgentName,
                    AgentCode = ser.GetAgencyCode(item.AgentId),
                    DepositId = item.DepositId,
                    PaymentModeId = item.PaymentModeId,
                    Status = item.Status,
                    ChequeAmount = item.Amount,
                    ChequeIssueDate = item.DepositDate,
                    DraftAmount = item.Amount,
                    DraftDepositDate = item.DepositDate,
                    CashAmount = item.Amount,
                    CashDepositDate = item.DepositDate,
                    BankTransferAmount = item.Amount,
                    BankTransferDepositDate = item.DepositDate,
                    RTGSAmount = item.Amount,
                    RTGSDepositDate = item.DepositDate,
                    CashGivenToAmount = item.Amount,
                    CashGivenToDepositDate = item.DepositDate
                   
                };
                model.Add(obj);
            }
            return model.ToList();
        }


        public UnApproveMakePaymentModel GetUnApprovedMakePaymentDetails(int DepositId)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == DepositId).FirstOrDefault();
            UnApproveMakePaymentModel model = new UnApproveMakePaymentModel();

            model.DepositId = result.DepositId;
            model.AgentId = result.AgentId;
            model.DepositDate = result.DepositDate;
            model.DraftDepositDate = result.DepositDate;
            model.CashDepositDate = result.DepositDate;
            model.BankTransferDepositDate = result.DepositDate;
            model.RTGSDepositDate = result.DepositDate;
            model.CashGivenToDepositDate = result.DepositDate;
            model.BankId = result.BankId;
            model.ChequeBankId = result.BankId;
            model.DraftBankId = result.BankId;
            model.CashBankId = result.BankId;
            model.BankTransferBankId = result.BankId;
            model.RTGSBankId = result.BankId;
            model.BankBranchId = result.BankBranchId;
            model.ChequeBankBranchId = result.BankBranchId;
            model.DraftBankBranchId = result.BankBranchId;
            model.CashBankBranchId = result.BankBranchId;
            model.BankTransferBankBranchId = result.BankBranchId;
            model.RTGSBankBranchId = result.BankBranchId;
            model.AccountId = result.AccountNumber;
            model.Amount = result.Amount;
            model.ChequeAmount = result.Amount;
            model.DraftAmount = result.Amount;
            model.CashAmount = result.Amount;
            model.BankTransferAmount = result.Amount;
            model.RTGSAmount = result.Amount;
            model.CashGivenToAmount = result.Amount;
            model.CurrencyName = result.Currencies.CurrencyName;
            model.InstrumentNo = result.InstrumentNo;
            model.Remakrs = result.Remark;
            model.ChequeRemakrs = result.Remark;
            model.DraftRemakrs = result.Remark;
            model.CashRemakrs = result.Remark;
            model.BankTransferRemakrs = result.Remark;
            model.RTGSRemakrs = result.Remark;
            model.CashGivenToRemakrs = result.Remark;
            model.MobileNumber = result.MobileNumber;
            model.ChequeMobileNumber = result.MobileNumber;
            model.BankTransferMobileNumber = result.MobileNumber;
            model.TransactionId = result.TransactionId;
            model.ChequeTransactionId = result.TransactionId;
            model.CashTransactionId = result.TransactionId;
            model.BankTransferTransactionId = result.TransactionId;

            if (result.ChequeDrawnOnBankId == null)
            {
                model.ChequeDrawnonBank = 0;
            }
            else
            {
                model.ChequeDrawnonBank = (int)result.ChequeDrawnOnBankId;
            }
            if (result.ChequeIssueDate == null)
            {
                model.ChequeIssueDate = DateTime.Now;
            }
            else
            {
                model.ChequeIssueDate = result.ChequeIssueDate;
            }
            if (result.ChequeNumber == null)
            {
                model.ChequeNumber = "";
            }
            else
            {
                model.ChequeNumber = result.ChequeNumber;
            }
            model.DraftNumber = result.DraftNumber;
            model.RTGSUTRNumber = result.UTRNumber;
           // model.SalesAgentName = result.UsersDetails.FullName;
            model.PaymentModeId = result.PaymentModeId;
            model.DraftNumber = result.DraftNumber;
            model.ChequeDrawnonBankName = result.Banks.BankName;
            model.ChequeBankName = result.Banks.BankName;
            model.ChequeBranchName = result.BankBranches.BranchName;
            model.DraftBankName = result.Banks.BankName;
            model.DraftBranchName = result.BankBranches.BranchName;
            model.CashBankName = result.Banks.BankName;
            model.CashBranchName = result.BankBranches.BranchName;
            model.BankTransferBankName = result.Banks.BankName;
            model.BankTransferBranchName = result.BankBranches.BranchName;
            model.RTSSBankName = result.Banks.BankName;
            model.RTGSBranchName = result.BankBranches.BranchName;
            //model.SalesAgent = (int)result.SalesAgentId;
            model.SalesAgentName = result.SalesAgentId != 0 ? new MakePaymentProvider().GetSalesAgentName(model.SalesAgent): "-";
          //  model.SalesAgentName=result.SalesAgentId !=0 ? GetUserDetails(result.SalesAgentId) : "-";

            return model;
        }

        public void ApproveUnapproveMakePayment(int DepositId, int userid)
        {
            ent.Air_ApproveCashDeposit(DepositId, userid);
        }

        public void RejectDeposit(int id, int DeletedBy)
        {
            MakePaymentProvider serMakePayment = new MakePaymentProvider();
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == id).FirstOrDefault();
            result.Status = 3;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

            serMakePayment.UpdateGL_Transactions(id, DeletedBy);

           
        }
        public string GetUserDetails(int? UserID)
        {

            return ent.UsersDetails.SingleOrDefault(u => u.AppUserId == UserID).FullName;
        }

    }
}