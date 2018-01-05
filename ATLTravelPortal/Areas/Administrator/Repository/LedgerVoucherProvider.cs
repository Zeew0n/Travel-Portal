using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Text;

namespace ATLTravelPortal.Areas.Administrator.Repository
{

    public class LedgerVoucherProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public decimal totalDrAmount = 0;
        public decimal totalCrAmount = 0;

        public void SaveVoucher(List<GL_Transactions> Gl_trans)
        {

            foreach (var item in Gl_trans)
            {
                ent.GL_Transactions.AddObject(new GL_Transactions()
                {

                    ProductId = item.ProductId,
                    TranDate = item.TranDate,
                    LedgerId = item.LedgerId,
                    VoucherNo = item.VoucherNo,
                    Narration1 = item.Narration1,
                    Amount = item.Amount,
                    Dr_Cr = item.Dr_Cr,
                    TranStatusId = item.TranStatusId,
                    MakerId = item.MakerId,
                    MakerDate = item.MakerDate,
                    TranTypeId = item.TranTypeId,
                    CurrencyId = item.CurrencyId,
                    BaseCurrencyId = item.BaseCurrencyId,
                    FXRate = item.FXRate,
                    FCYAmount = item.FCYAmount,
                    MakerRemark = GetFormattedRemark(string.Empty, item.CheckerRemark, item.MakerId),
                    MakerTerminalId = item.MakerTerminalId
                });
            }
            ent.SaveChanges();

        }


        public Int64 GetVoucherNumber(int productId)
        {
            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("VoucherNumber", 0);
            ent.GL_GetVoucherNumber(productId, -1, -1, param);
            return (Int64)param.Value;
        }

        public List<GL_Ledgers> GetLedgerName(string LedgerName, int maxResult)
        {
            return GetAllLedgerName(LedgerName, maxResult).ToList();
        }
        public IEnumerable<GL_Ledgers> GetAllLedgerName(string searchText, int maxResult)
        {

            return ent.GL_Ledgers.Where(x => (x.LedgerName.ToLower().Contains(searchText) || x.LedgerName.ToUpper().Contains(searchText)) & x.ProductId == 1).Take(maxResult).ToList().Select(x =>
                                new GL_Ledgers { LedgerName = x.LedgerName, LedgerId = x.LedgerId }
                );
        }

        public void SaveGeneralLedgerTransaction(List<GL_Transactions> Transaactionentry)
        {

            foreach (var item in Transaactionentry)
            {
                ent.GL_Transactions.AddObject(new GL_Transactions()
                {

                    ProductId = item.ProductId,
                    TranDate = item.TranDate,
                    LedgerId = item.LedgerId,
                    //isAutoExpire = item.isAutoExpire,
                    //ActiveFromDate = item.ActiveFromDate,
                    //ActiveToDate = item.ActiveToDate,
                    //CreatedBy = item.CreatedBy,
                    //CreatedDate = DateTime.Now

                });
            }
            ent.SaveChanges();
        }



        public IEnumerable<LedgerVoucherModel> GetTransactionList(Int64 VoucherNumber)
        {
            List<LedgerVoucherModel> model = new List<LedgerVoucherModel>();

            var result = ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNumber);


            foreach (var item in result)
            {

                var obj = new LedgerVoucherModel();
                obj.TranDate = item.TranDate;
                obj.ProductName = item.Core_Products.ProductName;
                obj.ProductId = item.ProductId;
                obj.Narration1 = item.Narration1;
                obj.VoucherNo = item.VoucherNo;
                obj.Debit = item.Dr_Cr;
                obj.Amount = item.Amount;
                obj.MakerID = item.MakerId;

                string userName = string.Empty;
                if (item.MakerId > 0)
                {
                    var userDetails = ent.UsersDetails.Where(x => x.AppUserId == item.MakerId).FirstOrDefault();
                    if (userDetails != null)
                        userName = userDetails.FullName;
                }

                obj.MakerName = userName;
                obj.LegderName = item.GL_Ledgers.LedgerName;


                if (obj.Debit == "D")
                {
                    totalDrAmount = totalDrAmount + Convert.ToDecimal(item.Amount);


                }

                else if (obj.Debit == "C")
                {
                    totalCrAmount = totalCrAmount + Convert.ToDecimal(item.Amount);

                }
                obj.txtSumDrAmount = totalDrAmount;
                obj.txtSumCrAmount = totalCrAmount;
                // obj.TranStatusId = item.GL_TransactionStatus.TranStatusId;
                obj.TranStatusId = (int)item.TranStatusId;
                obj.TranStatusName = item.GL_TransactionStatus.TranStatusName;

                obj.DeletedName = GetUserName(item.DeletedBy);
                obj.DeleteDate = item.DeletedDate;



                model.Add(obj);
            }


            return model.AsEnumerable();

        }

        public string GetUserName(int? id)
        {
            string username = ent.UsersDetails.Where(x => x.AppUserId == id).Select(x => x.FullName).FirstOrDefault();
            return username;
        }


        public void DeleteVoucher(Int64 voucherno, LedgerVoucherModel model)
        {

            List<GL_Transactions> result = ent.GL_Transactions.Where(x => x.VoucherNo == voucherno).ToList();
            foreach (var item in result)
            {
                item.TranStatusId = 4;
                item.DeletedBy = model.DeletedBy;
                item.DeletedDate = DateTime.Now;
                item.DeletedRemark = GetFormattedRemark(item.DeletedRemark, model.DeleteRemark, model.DeletedBy ?? 0);
                item.DeletedTerminalId = model.CheckerTerminal;

                ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                ent.SaveChanges();
            }

        }

        public LedgerVoucherModel GetLedgerVoucherByVoucherNo(Int64? voucherno)
        {
            var result = ent.GL_Transactions.Where(x => x.VoucherNo == voucherno);

            LedgerVoucherModel model = new LedgerVoucherModel();
            if (result.Count() != 0)
            {
                model.ProductList = new SelectList(ent.Core_Products.Where(x => x.isActive == true).ToList(), "ProductId", "ProductName", result.First().ProductId);
                model.CurrencyList = new SelectList(ent.Currencies.ToList(), "CurrencyId", "CurrencyCode", result.First().CurrencyId);
                model.CurrencyID = result.First().CurrencyId;
                model.ProductId = result.First().ProductId;

                model.TranDate = result.First().TranDate;
                model.VoucherNo = voucherno != null ? (long)voucherno : 0;
                List<LedgerVoucherModel> TransactionList = new List<LedgerVoucherModel>();

                foreach (var t in result)
                {
                    LedgerVoucherModel obj = new LedgerVoucherModel()
                    {
                        TranID = t.TranId,
                        ProductId = t.ProductId,
                        VoucherNo = t.VoucherNo,
                        TranDate = t.TranDate,
                        Narration1 = t.Narration1,
                        Narration2 = t.Narration2,
                        DebitAmount = t.Dr_Cr == "D" ? t.Amount : 0,
                        CreditAmount = t.Dr_Cr == "C" ? t.Amount : 0,
                        Debit = t.Dr_Cr == "D" ? "Dr" : "Cr",
                        LegderName = t.GL_Ledgers.LedgerName,
                        LedgerId = t.LedgerId
                    };
                    TransactionList.Add(obj);
                }
                model.TranList = TransactionList;
                model.txtSumDrAmount = (decimal)TransactionList.Sum(x => x.DebitAmount);
                model.txtSumCrAmount = (decimal)TransactionList.Sum(x => x.CreditAmount);
                return model;
            }
            return null;
        }

        public bool EditGL_Transactions(LedgerVoucherModel model)
        {
            foreach (var t in model.TranList)
            {
                GL_Transactions transaction = ent.GL_Transactions.Where(x => x.TranId == t.TranID).FirstOrDefault();

                transaction.Dr_Cr = t.Debit == "Dr" ? "D" : "C";
                transaction.LedgerId = t.LedgerId;
                transaction.Narration1 = t.Narration1;
                if (t.Debit == "Dr")
                {
                    transaction.Amount = t.DebitAmount;
                }
                else if (t.Debit == "Cr")
                {
                    transaction.Amount = t.CreditAmount;
                }
                transaction.TranStatusId = 1;

                transaction.CheckerId = model.AppUserId;
                transaction.CheckerDate = DateTime.UtcNow;
                transaction.CheckerTerminalId = model.CheckerTerminal;
                transaction.CheckerRemark = GetFormattedRemark(transaction.CheckerRemark, model.CheckerRemark, model.AppUserId);


                ent.ApplyCurrentValues(transaction.EntityKey.EntitySetName, transaction);
            }
            ent.SaveChanges();
            return true;
        }

        public string GetFormattedRemark(string oldRemark, string newRemark, int appUserId)
        {
            var data = ent.UsersDetails.Where(x => x.AppUserId == appUserId).FirstOrDefault();
            StringBuilder remarkBuilder = new StringBuilder();
            remarkBuilder.Append(oldRemark);
            remarkBuilder.Append(string.Format("[ User: {0} has updated the voucher on {1} | {2}]", data.FullName, DateTime.UtcNow, newRemark));
            return remarkBuilder.ToString();
        }
    }
}