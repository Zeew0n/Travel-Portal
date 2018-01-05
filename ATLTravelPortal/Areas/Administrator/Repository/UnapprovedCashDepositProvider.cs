using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    
    public class UnapprovedCashDepositProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public List<UnapprovedCashDepositModel> GetUnApprovedList()
        {
            var data = ent.Core_AgentCashDeposits.Where(x => x.isApproved == false);

            List<UnapprovedCashDepositModel> model = new List<UnapprovedCashDepositModel>();

            foreach (var item in data)
            {
                var temp = new UnapprovedCashDepositModel 
                {
                    AccountNumber=GetBankAccountNumber(item.BankId),
                    AgentName=item.Agents.AgentName,
                    Amount=item.Amount,
                    BankName=item.Banks.BankName,
                    BranchName=item.BankBranches.BranchName,
                    CreatdBy=item.UsersDetails.FullName,
                    CreatedDate=item.CreatedDate,
                    DepositId=item.DepositId,
                    DepositDate=item.DepositDate,
                    Currency=item.Currencies.CurrencyCode,
                    InstrumentNo=item.InstrumentNo
                    
                };
                model.Add(temp);
            }
            return model.ToList();
        }

        public string GetBankAccountNumber(int bankId)
        {
            var result = ent.Core_AdminBanks.Where(z => z.BankId == bankId).FirstOrDefault();
            if (result != null)
                return result.AccountNumber;
            return string.Empty;
        }

        public UnapprovedCashDepositModel GetUnApprovedDetails(int DepositId)
        {
            var item = ent.Core_AgentCashDeposits.Where(x => x.DepositId == DepositId).FirstOrDefault();

            UnapprovedCashDepositModel model = new UnapprovedCashDepositModel
            {
                AccountNumber = item.AccountNumber,
                AgentName = item.Agents.AgentName,
                Amount = item.Amount,
                BankName = item.Banks.BankName,
                BranchName = item.BankBranches.BranchName,
                CreatdBy = item.UsersDetails.FullName,
                CreatedDate = item.CreatedDate,
                DepositId = item.DepositId,
                DepositDate = item.DepositDate,
                Currency = item.Currencies.CurrencyCode,
                InstrumentNo=item.InstrumentNo,
                PaymentModes = item.PaymentModes.ModeName
            };

            return model;
        }

        public void ApproveCashDeposit(int DepositId, int userid)
        {
            ent.Air_ApproveCashDeposit(DepositId, userid);
        }

    }
}