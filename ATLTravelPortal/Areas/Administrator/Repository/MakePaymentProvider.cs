using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class MakePaymentProvider
    {
        EntityModel ent = new EntityModel();

        //for listing 
        public List<MakePaymentModel> GetAgentCashDepositsList()
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_AgentCashDeposits.Where(x=>x.Status != 3).OrderByDescending(xx => xx.CreatedDate).AsEnumerable();
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.AgentId,
                    AgencyName = item.Agents.AgentName,
                    AgentCode = item.Agents.AgentCode,
                    DepositId = item.DepositId,
                    PaymentModeName = item.PaymentModes.ModeName,
                    ChequeAmount = item.Amount,
                    ChequeIssueDate = item.DepositDate,
                    status = item.Status,
                    CurrencyId = item.CurrencyId,
                    CurrencyName = item.Currencies.CurrencyName
                };
                model.Add(obj);
            }
            return model.ToList();
        }
        //for listing 


        //for listing 
        public List<MakePaymentModel> GetDistributorAgentCashDepositsList(int AppUserId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

          
            var ts = SessionStore.GetTravelSession();
            var result = from a in ent.Core_AgentCashDeposits
                         join b in ent.Agents on a.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId
                         select a;

          //  var result = ent.Core_AgentCashDeposits.Where(x => (x.Status != 3 && x.Createdby == AppUserId)).OrderByDescending(xx => xx.CreatedDate).AsEnumerable();
            foreach (var item in result.Where(x=>x.Status !=3))
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.AgentId,
                   AgencyName = item.Agents.AgentName,
                   AgentCode = item.Agents.AgentCode,
                    DepositId = item.DepositId,
                    PaymentModeName = item.PaymentModes.ModeName,
                    ChequeAmount = item.Amount,
                    ChequeIssueDate = item.DepositDate,
                    status = item.Status,
                    CurrencyId = item.CurrencyId,
                    CurrencyName = item.Currencies.CurrencyName
                };
                model.Add(obj);
            }
            return model.ToList();
        }

        //for Branch List
        public List<MakePaymentModel> GetBranchDistributorCashDepositsList()
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();


            var ts = SessionStore.GetTravelSession();

            var result = from T1 in ent.Core_DistributorAgentCashDeposit
                         join T2 in ent.Distributors on T1.DistributorId equals T2.DistributorId
                         where T2.BranchOfficeId == ts.LoginTypeId
                         select T1;
           
            foreach (var item in result.Where(x => x.Status != 3))
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.DistributorId,
                    AgencyName = GetDistributorNameById(item.DistributorId),
                    AgentCode = GetDistributorCodeById(item.DistributorId),
                    DepositId = item.DepositId,
                    PaymentModeName = item.PaymentModes.ModeName,
                    ChequeAmount = item.Amount,
                    ChequeIssueDate = item.DepositDate,
                    status = item.Status,
                    CurrencyId = item.CurrrencyId,
                    CurrencyName = item.Currencies.CurrencyName
                };
                model.Add(obj);
            }
            return model.ToList();
        }
        private string GetDistributorNameById(int DistributorId)
        {
            string distributorname = ent.Distributors.Where(x => x.DistributorId == DistributorId).Select(x => x.DistributorName).FirstOrDefault();
            return distributorname;
        }
        private string GetDistributorCodeById(int distributorid)
        {
            string distributorcode = ent.Distributors.Where(x => x.DistributorId == distributorid).Select(x => x.DistributorCode).FirstOrDefault();
            return distributorcode;
        }

        ////////////////////for saving Cheque date//////////////////////////////////////
        public void ChequeAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = DateTime.Now,
                BankId = modelToSave.ChequeBankId,
                BankBranchId = modelToSave.ChequeBankBranchId,
                AccountNumber = modelToSave.AccountId == null ? "" : modelToSave.AccountId,
                Amount = (double)modelToSave.ChequeAmount,
                CurrencyId = 1,
                PaymentModeId = modelToSave.PaymentModeId,// == MakePaymentModel.PaymentMode.Cheque ,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.ChequeRemakrs == null ? "" : modelToSave.ChequeRemakrs,
                Status = 1,//Approved
                MobileNumber = modelToSave.ChequeMobileNumber == null ? "" : modelToSave.ChequeMobileNumber,
                TransactionId = modelToSave.ChequeTransactionId == null ? "" : modelToSave.ChequeTransactionId,
                ChequeDrawnOnBankId = modelToSave.ChequeDrawnonBank == 0 ? 0 : modelToSave.ChequeDrawnonBank,
                ChequeIssueDate = modelToSave.ChequeIssueDate,
                ChequeNumber = modelToSave.ChequeNumber == null ? "" : modelToSave.ChequeNumber,
                DraftNumber = modelToSave.DraftNumber == null ? "" : modelToSave.DraftNumber,
                UTRNumber = modelToSave.RTGSUTRNumber == null ? "" : modelToSave.RTGSUTRNumber,
                SalesAgentId = modelToSave.SalesAgent == 0 ? 0 : modelToSave.SalesAgent
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }

        /////////////////////////////////////////////////////////////////////////////////



        ////////////////////for saving Cheque date//////////////////////////////////////
        public int BranchChequeAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = DateTime.Now,
                BankId = modelToSave.ChequeBankId,
                BankBranchId = modelToSave.ChequeBankBranchId,
                AccountNumber = modelToSave.AccountId == null ? "" : modelToSave.AccountId,
                Amount = (double)modelToSave.ChequeAmount,
                CurrrencyId = 1,
                PaymentModeId = modelToSave.PaymentModeId,// == MakePaymentModel.PaymentMode.Cheque ,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.ChequeRemakrs == null ? "" : modelToSave.ChequeRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = modelToSave.ChequeMobileNumber == null ? "" : modelToSave.ChequeMobileNumber,
                TransactionId = modelToSave.ChequeTransactionId == null ? "" : modelToSave.ChequeTransactionId,
                ChequeDrawnOnBankId = modelToSave.ChequeDrawnonBank == 0 ? 0 : modelToSave.ChequeDrawnonBank,
                ChequeIssueDate = modelToSave.ChequeIssueDate,
                ChequeNumber = modelToSave.ChequeNumber == null ? "" : modelToSave.ChequeNumber,
                DraftNumber = modelToSave.DraftNumber == null ? "" : modelToSave.DraftNumber,
                UTRNumber = modelToSave.RTGSUTRNumber == null ? "" : modelToSave.RTGSUTRNumber,
                SalesAgentId = modelToSave.SalesAgent == 0 ? 0 : modelToSave.SalesAgent
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }

        /////////////////////////////////////////////////////////////////////////////////




        /////////////////////////////For saving Draft///////////////////////////////////
        public void DraftAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.DraftDepositDate,
                BankId = modelToSave.DraftBankId,
                BankBranchId = modelToSave.DraftBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.DraftAmount,
                CurrencyId = modelToSave.DraftCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.DraftRemakrs == null ? "" : modelToSave.DraftRemakrs,
                Status = 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = modelToSave.DraftNumber,
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving Draft///////////////////////////////////
        public int BranchDraftAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.DraftDepositDate,
                BankId = modelToSave.DraftBankId,
                BankBranchId = modelToSave.DraftBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.DraftAmount,
                CurrrencyId = modelToSave.DraftCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.DraftRemakrs == null ? "" : modelToSave.DraftRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = modelToSave.DraftNumber,
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving Cash///////////////////////////////////
        public void CashAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.CashDepositDate,
                BankId = modelToSave.CashBankId,
                BankBranchId = modelToSave.CashBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.CashAmount,
                CurrencyId = modelToSave.CashCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.CashRemakrs == null ? "" : modelToSave.CashRemakrs,
                Status = 1,//Approved
                MobileNumber = "",
                TransactionId = modelToSave.CashTransactionId,
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving Branch Cash///////////////////////////////////
        public int BranchCashAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.CashDepositDate,
                BankId = modelToSave.CashBankId,
                BankBranchId = modelToSave.CashBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.CashAmount,
                CurrrencyId = modelToSave.CashCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.CashRemakrs == null ? "" : modelToSave.CashRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = "",
                TransactionId = modelToSave.CashTransactionId,
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////For saving BankTransfer///////////////////////////////////
        public void BankTransferAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.BankTransferDepositDate,
                BankId = modelToSave.BankTransferBankId,
                BankBranchId = modelToSave.BankTransferBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.BankTransferAmount,
                CurrencyId = modelToSave.BankTransferCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.BankTransferRemakrs == null ? "" : modelToSave.BankTransferRemakrs,
                Status = 1,//Approved
                MobileNumber = modelToSave.BankTransferMobileNumber,
                TransactionId = modelToSave.BankTransferTransactionId,
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving BankTransfer///////////////////////////////////
        public int BranchBankTransferAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.BankTransferDepositDate,
                BankId = modelToSave.BankTransferBankId,
                BankBranchId = modelToSave.BankTransferBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.BankTransferAmount,
                CurrrencyId = modelToSave.BankTransferCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.BankTransferRemakrs == null ? "" : modelToSave.BankTransferRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = modelToSave.BankTransferMobileNumber,
                TransactionId = modelToSave.BankTransferTransactionId,
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = 0
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////For saving RTGS///////////////////////////////////
        public void RTGSAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.RTGSDepositDate,
                BankId = modelToSave.RTGSBankId,
                BankBranchId = modelToSave.RTGSBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.RTGSAmount,
                CurrencyId = modelToSave.RTGSCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.RTGSRemakrs == null ? "" : modelToSave.RTGSRemakrs,
                Status = 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = modelToSave.RTGSUTRNumber,
                SalesAgentId = 0
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving BRanch RTGS///////////////////////////////////
        public int BranchRTGSAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.RTGSDepositDate,
                BankId = modelToSave.RTGSBankId,
                BankBranchId = modelToSave.RTGSBankBranchId,
                AccountNumber = "",
                Amount = (double)modelToSave.RTGSAmount,
                CurrrencyId = modelToSave.RTGSCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.RTGSRemakrs == null ? "" : modelToSave.RTGSRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = modelToSave.RTGSUTRNumber,
                SalesAgentId = 0
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving RTGS///////////////////////////////////
        public void CashGivenToAdd(MakePaymentModel modelToSave)
        {
            Core_AgentCashDeposits datamodel = new Core_AgentCashDeposits
            {
                AgentId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.CashGivenToDepositDate,
                BankId = 3,
                BankBranchId = 1,
                AccountNumber = "",
                Amount = (double)modelToSave.CashGivenToAmount,
                CurrencyId = modelToSave.CashGivenToCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.CashGivenToRemakrs == null ? "" : modelToSave.CashGivenToRemakrs,
                Status = 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = modelToSave.SalesAgent
            };
            ent.AddToCore_AgentCashDeposits(datamodel);
            ent.SaveChanges();
            ApproveUnapproveMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////For saving RTGS///////////////////////////////////
        public int BranchCashGivenToAdd(MakePaymentModel modelToSave)
        {
            Core_DistributorAgentCashDeposit datamodel = new Core_DistributorAgentCashDeposit
            {
                DistributorId = modelToSave.AgentId,
                DepositDate = (DateTime)modelToSave.CashGivenToDepositDate,
                BankId = 3,
                BankBranchId = 1,
                AccountNumber = "",
                Amount = (double)modelToSave.CashGivenToAmount,
                CurrrencyId = modelToSave.CashGivenToCurrencyId,
                PaymentModeId = modelToSave.PaymentModeId,
                InstrumentNo = "",
                Createdby = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now,
                Remark = modelToSave.CashGivenToRemakrs == null ? "" : modelToSave.CashGivenToRemakrs,
                Status = modelToSave.flag == "DistributorMakePayment" ? 2 : 1,//Approved
                MobileNumber = "",
                TransactionId = "",
                ChequeDrawnOnBankId = 0,
                ChequeIssueDate = DateTime.Now,
                ChequeNumber = "",
                DraftNumber = "",
                UTRNumber = "",
                SalesAgentId = modelToSave.SalesAgent
            };
            ent.AddToCore_DistributorAgentCashDeposit(datamodel);
            ent.SaveChanges();
            return (int)datamodel.DepositId;
            //ApproveUnapprovedBranchDistributorMakePayment((int)datamodel.DepositId, modelToSave.CreatedBy);
        }
        //////////////////////////////////////////////////////////////////////////////////


        //for edit




        public void BranchCreditRequest(MakePaymentModel model, int UserId)
        {
            Core_DistributorCreditLimits crLmt = new Core_DistributorCreditLimits();
            crLmt.Amount = model.CreditAmount;
            crLmt.DistributorId = model.AgentId;
            crLmt.isApproved = false;
            crLmt.CreditLimitTypeId = 2;
            crLmt.CurrencyId = model.CreditRequestCurrencyId;
            crLmt.MakerDate = DateTime.Now;
            crLmt.MakerId = UserId;
            crLmt.CheckerDate = null;
            crLmt.CheckerId = null;
            crLmt.isActive = true;
            crLmt.Comments = model.CreditRequestRemakrs;
            ent.AddToCore_DistributorCreditLimits(crLmt);
            ent.SaveChanges();
        }


        public string GetBankName(int bankid)
        {
            string bankname = ent.Banks.Where(x => x.BankId == bankid).Select(x => x.BankName).FirstOrDefault();
            return bankname;
        }
        public string GetBankBranchName(int bankbranchid)
        {
            string bankbranchname = ent.BankBranches.Where(x => x.BankBranchId == bankbranchid).Select(x => x.BranchName).FirstOrDefault();
            return bankbranchname;
        }



        public void MakePaymentEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Now;
            result.BankId = model.ChequeBankId;
            result.BankBranchId = model.ChequeBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.ChequeAmount;
            result.CurrencyId = 1;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.ChequeRemakrs;
            result.Status = 1;
            result.MobileNumber = model.ChequeMobileNumber;
            result.TransactionId = model.ChequeTransactionId;
            result.ChequeDrawnOnBankId = model.ChequeDrawnonBank;
            result.ChequeIssueDate = model.ChequeIssueDate;
            result.ChequeNumber = model.ChequeNumber;
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        //for edit
        public void ChequeEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Now;
            result.BankId = model.ChequeBankId;
            result.BankBranchId = model.ChequeBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.ChequeAmount;
            result.CurrencyId = model.ChequeCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.ChequeRemakrs;
            result.Status = 1;
            result.MobileNumber = model.ChequeMobileNumber;
            result.TransactionId = model.ChequeTransactionId;
            result.ChequeDrawnOnBankId = model.ChequeDrawnonBank;
            result.ChequeIssueDate = DateTime.Parse(model.ChequeDate);
            result.ChequeNumber = model.ChequeNumber;
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;
            

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
           // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }


        //for edit
        public void BranchChequeEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Now;
            result.BankId = model.ChequeBankId;
            result.BankBranchId = model.ChequeBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.ChequeAmount;
            result.CurrrencyId = model.ChequeCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.ChequeRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1; 
            result.MobileNumber = model.ChequeMobileNumber;
            result.TransactionId = model.ChequeTransactionId;
            result.ChequeDrawnOnBankId = model.ChequeDrawnonBank;
            result.ChequeIssueDate = DateTime.Parse(model.ChequeDate);
            result.ChequeNumber = model.ChequeNumber;
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;


            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }


        //for edit
        public void DraftEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.DraftDate);
            result.BankId = model.DraftBankId;
            result.BankBranchId = model.DraftBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.DraftAmount;
            result.CurrencyId = model.DraftCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.DraftRemakrs;
            result.Status = 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = model.DraftNumber;
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
           // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }


        //for edit
        public void BranchDraftEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.DraftDate);
            result.BankId = model.DraftBankId;
            result.BankBranchId = model.DraftBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.DraftAmount;
            result.CurrrencyId = model.DraftCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.DraftRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = model.DraftNumber;
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void CashEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.CashDate);
            result.BankId = model.CashBankId;
            result.BankBranchId = model.CashBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.CashAmount;
            result.CurrencyId = model.CashCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.CashRemakrs;
            result.Status = 1;
            result.MobileNumber = "";
            result.TransactionId = model.TransactionId;
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
           // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }


        //for edit
        public void BranchCashEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.CashDate);
            result.BankId = model.CashBankId;
            result.BankBranchId = model.CashBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.CashAmount;
            result.CurrrencyId = model.CashCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.CashRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1;
            result.MobileNumber = "";
            result.TransactionId = model.TransactionId;
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }




        //for edit
        public void BankTransferEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Parse( model.BankTransferDate);
            result.BankId = model.BankTransferBankId;
            result.BankBranchId = model.BankTransferBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.BankTransferAmount;
            result.CurrencyId = model.BankTransferCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.BankTransferRemakrs;
            result.Status = 1;
            result.MobileNumber = model.BankTransferMobileNumber;
            result.TransactionId = model.BankTransferTransactionId; ;
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
           // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void BranchBankTransferEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.BankTransferDate);
            result.BankId = model.BankTransferBankId;
            result.BankBranchId = model.BankTransferBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.BankTransferAmount;
            result.CurrrencyId = model.BankTransferCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.BankTransferRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1;
            result.MobileNumber = model.BankTransferMobileNumber;
            result.TransactionId = model.BankTransferTransactionId; ;
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = "";
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void RTGSEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Parse( model.RTGSDate);
            result.BankId = model.RTGSBankId;
            result.BankBranchId = model.RTGSBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.RTGSAmount;
            result.CurrencyId = model.RTGSCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.RTGSRemakrs;
            result.Status = 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = model.RTGSUTRNumber;
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            //ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void BranchRTGSEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.RTGSDate);
            result.BankId = model.RTGSBankId;
            result.BankBranchId = model.RTGSBankBranchId;
            result.AccountNumber = "";
            result.Amount = (double)model.RTGSAmount;
            result.CurrrencyId = model.RTGSCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.RTGSRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = model.RTGSUTRNumber;
            result.SalesAgentId = 0;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            //ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void CashGivenToEdit(MakePaymentModel model)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.AgentId = model.AgentId;
            result.DepositDate = DateTime.Parse( model.CashGivenToDate);
            result.BankId = 3;
            result.BankBranchId = 1;
            result.AccountNumber = "";
            result.Amount = (double)model.CashGivenToAmount;
            result.CurrencyId = model.CashGivenToCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.CashGivenToRemakrs;
            result.Status = 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = model.RTGSUTRNumber;
            result.SalesAgentId = model.SalesAgent;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
           // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }

        //for edit
        public void BranchCashGivenToEdit(MakePaymentModel model)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == model.DepositId).FirstOrDefault();

            result.DepositId = model.DepositId;
            result.DistributorId = model.AgentId;
            result.DepositDate = DateTime.Parse(model.CashGivenToDate);
            result.BankId = 3;
            result.BankBranchId = 1;
            result.AccountNumber = "";
            result.Amount = (double)model.CashGivenToAmount;
            result.CurrrencyId = model.CashGivenToCurrencyId;
            result.PaymentModeId = model.PaymentModeId;
            result.InstrumentNo = "";
            result.Remark = model.CashGivenToRemakrs;
            result.Status = model.flag == "DistributorMakePayment" ? 2 : 1;
            result.MobileNumber = "";
            result.TransactionId = "";
            result.ChequeDrawnOnBankId = 0;
            result.ChequeIssueDate = DateTime.Now;
            result.ChequeNumber = "";
            result.DraftNumber = "";
            result.UTRNumber = model.RTGSUTRNumber;
            result.SalesAgentId = model.SalesAgent;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            // ApproveUnapproveMakePayment((int)model.DepositId, model.UpdatedBy);
        }


        public MakePaymentModel GetMakePaymentDetail(int id)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == id).FirstOrDefault();
            MakePaymentModel model = new MakePaymentModel();

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


            model.ChequeCurrencyId = result.CurrencyId;
            model.ChequeCurrencyName = result.Currencies.CurrencyName;
            model.DraftCurrencyId = result.CurrencyId;
            model.DraftCurrencyName = result.Currencies.CurrencyName;
            model.CashCurrencyId = result.CurrencyId;
            model.CashCurrencyName = result.Currencies.CurrencyName;
            model.BankTransferCurrencyId = result.CurrencyId;
            model.BankTransferCurrencyName = result.Currencies.CurrencyName;
            model.RTGSCurrencyId = result.CurrencyId;
            model.RTGSCurrencyName = result.Currencies.CurrencyName;
            model.CashGivenToCurrencyId = result.CurrencyId;
            model.CashGivenToCurrencyName = result.Currencies.CurrencyName;
          


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
            //model.rdbPaymentMode = result.PaymentModeId;
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
            model.SalesAgent = result.SalesAgentId;
            model.SalesAgentName = result.SalesAgentId != 0 ? GetSalesAgentName(model.SalesAgent) : "-";





            return model;

        }

        public MakePaymentModel GetBranchDistributroPaymentDetail(int id)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == id).FirstOrDefault();
            MakePaymentModel model = new MakePaymentModel();

            model.DepositId = result.DepositId;
            model.AgentId = result.DistributorId;

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


            model.ChequeCurrencyId = result.CurrrencyId;
            model.ChequeCurrencyName = result.Currencies.CurrencyName;
            model.DraftCurrencyId = result.CurrrencyId;
            model.DraftCurrencyName = result.Currencies.CurrencyName;
            model.CashCurrencyId = result.CurrrencyId;
            model.CashCurrencyName = result.Currencies.CurrencyName;
            model.BankTransferCurrencyId = result.CurrrencyId;
            model.BankTransferCurrencyName = result.Currencies.CurrencyName;
            model.RTGSCurrencyId = result.CurrrencyId;
            model.RTGSCurrencyName = result.Currencies.CurrencyName;
            model.CashGivenToCurrencyId = result.CurrrencyId;
            model.CashGivenToCurrencyName = result.Currencies.CurrencyName;

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
            //model.rdbPaymentMode = result.PaymentModeId;
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
            model.SalesAgent = result.SalesAgentId;
            model.SalesAgentName = result.SalesAgentId != 0 ? GetSalesAgentName(model.SalesAgent) : "-";
            return model;

        }

        public string GetSalesAgentName(int? SalesAgentId)
        {
            string SalesAgentName = ent.UsersDetails.Where(x => x.AppUserId == SalesAgentId).Select(x => x.FullName).FirstOrDefault();
            return SalesAgentName;
        }

        ///////////////////////////////////////approve //////////////////////////////////////////

        public void ApproveUnapproveMakePayment(int DepositId, int userid)
        {
           
            ent.Air_ApproveCashDeposit(DepositId, userid);
        }

        public void ApproveUnapprovedBranchDistributorMakePayment(int DepositId, int userid)
        {

            ent.Air_ApproveBranchDistributorCashDeposit(DepositId, userid);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        //for delete
        public void MakePaymentDelete(int DepositId, int DeletedBy)
        {
            Core_AgentCashDeposits result = ent.Core_AgentCashDeposits.Where(x => x.DepositId == DepositId).FirstOrDefault();
            result.Status = 3;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

            UpdateGL_Transactions(DepositId, DeletedBy);
        }
      
      //  UPDATE GL_Transactions SET TranStatusId=3 WHERE TranTypeId=2 and RefNo=@DepositId;
        public void UpdateGL_Transactions(int DepositId, int DeletedBy)
        {
            List<GL_Transactions> result = ent.GL_Transactions.Where(x => (x.RefNo == DepositId && x.TranTypeId == 2)).ToList();
            foreach (var item in result)
            {
                item.TranStatusId = 3;
                item.DeletedBy = DeletedBy;
                item.DeletedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                ent.SaveChanges();

            }

        }

        public void MakeBranchDistributorPaymentDelete(int DepositId, int DeletedBy)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == DepositId).FirstOrDefault();
            result.Status = 3;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

            UpdateGL_Transactions(DepositId, DeletedBy);
        }

        public List<MakePaymentModel> AllBank()
        {
            var query = (from aa in ent.Core_AdminBanks
                         join bb in ent.Banks on aa.BankId equals bb.BankId
                         select new MakePaymentModel
                         {
                             BankId = bb.BankId,
                             BankName = bb.BankName

                         }).ToList();
            return query;

        }

        public List<Banks> GetBank()
        {
            return ent.Banks.ToList();
        }

        public List<MakePaymentModel> AllBankBranch(int id)
        {
            var query = (from a in ent.Core_AdminBanks
                         join b in ent.BankBranches on a.BankBranchId equals b.BankBranchId
                         where a.BankId == id
                         select new MakePaymentModel
                         {
                             BankBranchId = b.BankBranchId,
                             BranchName = b.BranchName

                         }).ToList();
            return query;
        }

        public List<UsersDetails> GetSalesAgentList()
        {
            return ent.UsersDetails.Where(x => (x.UserTypeId == 4 && x.aspnet_Users.aspnet_Membership.IsLockedOut == false)).ToList();
        }

        public IEnumerable<SelectListItem> GetAllGetSalesAgentList()
        {
            List<UsersDetails> all = GetSalesAgentList().ToList();
            var GetAllGetSalesAgentListList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.FullName,
                    Value = item.AppUserId.ToString()
                };
                GetAllGetSalesAgentListList.Add(teml);
            }
            return GetAllGetSalesAgentListList.OrderBy(x=>x.Text).AsEnumerable();
        }


        public IEnumerable<SelectListItem> GetCurrenciesList()
        {
            List<Currencies> all = GetCurrencies().ToList();
            var CurrenciesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CurrencyCode,
                    Value = item.CurrencyId.ToString()
                };
                CurrenciesList.Add(teml);
            }
            return CurrenciesList.AsEnumerable();
        }

        public IQueryable<Currencies> GetCurrencies()
        {
            return ent.Currencies.AsQueryable();
        }





        ///////////////////////////Distributor Make Payment//////////////////////////////////////////
        //for listing 
        public List<MakePaymentModel> GetChequeList(int distributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 2 && x.DistributorId == distributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.DistributorId,
                    DepositId = item.DepositId,
                    PaymentModeName = "Cheque",
                    ChequeAmount = item.Amount,
                    ChequeIssueDate = item.DepositDate,
                    status = item.Status,
                    ChequeCurrencyId = item.CurrrencyId,
                    ChequeCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.ToList();
        }
        //for listing 
        public IEnumerable<MakePaymentModel> GetDraftList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 3 && x.DistributorId == DistributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.DistributorId,
                    DepositId = item.DepositId,
                    PaymentModeName = "Draft",
                    DraftAmount = item.Amount,
                    DraftDepositDate = item.DepositDate,
                    status = item.Status,
                    DraftCurrencyId = item.CurrrencyId,
                    DraftCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }
        //for listing 
        public IEnumerable<MakePaymentModel> GetCashList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 1 && x.DistributorId == DistributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    DepositId = item.DepositId,
                    AgentId = item.DistributorId,
                    PaymentModeName = "Cash",
                    CashAmount = item.Amount,
                    CashDepositDate = item.DepositDate,
                    status = item.Status,
                    CashCurrencyId = item.CurrrencyId,
                    CashCurrencyName = item.Currencies.CurrencyName,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }
        //for listing 
        public IEnumerable<MakePaymentModel> GetBankTransferList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 4 && x.DistributorId == DistributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    DepositId = item.DepositId,
                    AgentId = item.DistributorId,
                    PaymentModeName = "Bank Transfer",
                    BankTransferAmount = item.Amount,
                    BankTransferDepositDate = item.DepositDate,
                    status = item.Status,
                    BankTransferCurrencyId = item.CurrrencyId,
                    BankTransferCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }
        //for listing 
        public IEnumerable<MakePaymentModel> GetRTGSList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 5 && x.DistributorId == DistributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    DepositId = item.DepositId,
                    AgentId = item.DistributorId,
                    PaymentModeName = "RTGS",
                    RTGSAmount = item.Amount,
                    RTGSDepositDate = item.DepositDate,
                    status = item.Status,
                    RTGSCurrencyId = item.CurrrencyId,
                    RTGSCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }
        //for listing 
        public IEnumerable<MakePaymentModel> GetCashGivenToList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorAgentCashDeposit.Where(x => (x.PaymentModeId == 6 && x.DistributorId == DistributorId));
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    DepositId = item.DepositId,
                    AgentId = item.DistributorId,
                    PaymentModeName = "Cash Given To",
                    CashGivenToAmount = item.Amount,
                    CashGivenToDepositDate = item.DepositDate,
                    status = item.Status,
                    CashGivenToCurrencyId = item.CurrrencyId,
                    CashGivenToCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }

        //for listing 
        public IEnumerable<MakePaymentModel> GetCreditRequestList(int DistributorId)
        {
            List<MakePaymentModel> model = new List<MakePaymentModel>();

            var result = ent.Core_DistributorCreditLimits.Where(x => x.DistributorId == DistributorId && x.isActive == true).ToList(); ;//.Where(x => x.CreditLimitTypeId == 2);
            foreach (var item in result)
            {
                MakePaymentModel obj = new MakePaymentModel
                {
                    AgentId = item.DistributorId,
                    PaymentModeName = "CreditRequest",
                    CreditAmount = item.Amount,
                    CreditRequestRemakrs = item.Comments,
                    IsCreditRequestApproved = (bool)item.isApproved,
                    CreditRequestStatus = item.isApproved == true ? "Approved" : ((item.isApproved == false && item.CheckerId != null) ? "Rejected" : "Processing"),
                    CreditRequestDate = item.isApproved == true ? (DateTime)item.CheckerDate : ((item.isApproved == false && item.CheckerId != null) ? (DateTime)item.CheckerDate : (DateTime)item.MakerDate),
                    CreditRequestCurrencyId = item.CurrencyId,
                    CreditRequestCurrencyName = item.Currencies.CurrencyName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }

        //for delete
        public void BranchDistributorMakePaymentDelete(int DepositId)
        {
            Core_DistributorAgentCashDeposit result = ent.Core_DistributorAgentCashDeposit.Where(x => x.DepositId == DepositId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////



    }
}