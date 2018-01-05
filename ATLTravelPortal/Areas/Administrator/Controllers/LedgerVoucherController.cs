#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(Add = "Create", View = "Search", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class LedgerVoucherController : Controller
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        LedgerVoucherProvider _ser = new LedgerVoucherProvider();
        GeneralProvider _provider = new GeneralProvider();

        public ActionResult Create()
        {
            var agentList = ent.Agents.ToList();
            var productList = ent.Core_Products.Where(x => x.isActive == true).ToList();
            // var CurrencyList = ent.Currencies.Where(x=>x.CurrencyId==1).ToList();
            var CurrencyList = ent.Currencies.ToList();
            ViewData["ProductList"] = new SelectList(productList, "ProductId", "ProductName", 0);
            ViewData["CurrencyList"] = new SelectList(CurrencyList, "CurrencyId", "CurrencyName", 0);
            return View();
        }

        [HttpPost]
        public ActionResult Create(LedgerVoucherModel model, FormCollection coll)
        {
            try
            {
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                Int64 VoucherNumber = _ser.GetVoucherNumber(model.ProductId);

                ///////////Begin of Saving transaction info  ///////////////////////
                int totalentry = Convert.ToInt32(coll["noOfentry"]);
                List<GL_Transactions> entryDataList = new List<GL_Transactions>();
                for (int i = 0; i < totalentry; i++)
                {
                    string Dr_Cr = coll["DrCr"] ?? coll["DrCr" + i];
                    GL_Transactions list = new GL_Transactions();
                    if (string.IsNullOrEmpty(coll["Narration"] ?? coll["Narration" + i]) && (string.IsNullOrEmpty(coll["DrCr"] ?? coll["DrCr" + i])))
                    {
                        /////// TODO: Handle error due to java script error.Do not put this code here ///// 
                    }
                    else
                    {
                        list.LedgerId = Convert.ToInt32(coll["LedgerId"] ?? coll["LedgerId" + i]);
                        list.Narration1 = coll["Narration"] ?? coll["Narration" + i];
                        list.TranDate = model.TranDate;
                        list.ProductId = model.ProductId;
                        list.CurrencyId = model.CurrencyID;
                        list.TranStatusId = 1;
                        list.MakerId = ts.AppUserId;
                        list.TranTypeId = 2;
                        list.MakerDate = DateTime.Now;
                        if (Dr_Cr == "Dr" || Dr_Cr == "D" || Dr_Cr == "d")
                        {
                            list.Dr_Cr = "D";
                            list.Amount = Convert.ToDouble(coll["Debit"] ?? coll["Debit" + i]);
                        }
                        else if (Dr_Cr == "Cr" || Dr_Cr == "C" || Dr_Cr == "c")
                        {
                            list.Dr_Cr = "C";
                            list.Amount = Convert.ToDouble(coll["Credit"] ?? coll["Credit" + i]);
                        }
                        list.VoucherNo = VoucherNumber;
                        list.BaseCurrencyId = 1;

                        Core_FXRate ExchangeRate = ent.Core_FXRate.Where(x => (x.CurrencyID == model.CurrencyID && x.isApproved == true)).OrderByDescending(xx => xx.CreatedDate).FirstOrDefault();

                        double FXRate = 1;
                        if (ExchangeRate != null)
                        {
                            FXRate = ExchangeRate.ExchangeRate;
                        }

                        list.FXRate = FXRate;
                        list.FCYAmount = list.Amount * FXRate;

                        list.CheckerRemark = model.CheckerRemark;
                        string clientIP;
                        clientIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (clientIP == string.Empty)
                        {
                            clientIP = Request.ServerVariables["REMOTE_ADDR"];
                        }
                        list.CheckerTerminalId = clientIP;

                        entryDataList.Add(list);
                    }

                }
                _ser.SaveVoucher(entryDataList);
                TempData["SuccessMessage"] = "Successfully Created General Voucher";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = "There is an error: " + ex.Message;
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public ActionResult Search(LedgerVoucherModel model)
        {

            model.TransactionList = _ser.GetTransactionList(model.VoucherNo);

            return PartialView("VUC_TransactionList", model);
        }

        [HttpPost]
        public ActionResult Delete(Int64 Id, LedgerVoucherModel model)
        {
            var obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.DeletedBy = obj.AppUserId;
            try
            {
                string clientIP;
                clientIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (clientIP == string.Empty)
                {
                    clientIP = Request.ServerVariables["REMOTE_ADDR"];
                }
                model.CheckerTerminal = clientIP;
                _ser.DeleteVoucher(Id, model);
                model.TransactionList = _ser.GetTransactionList(Id);
                TempData["SuccessMessage"] = "Voucher has been successfully deleted.";
                return PartialView("VUC_TransactionList", model);
            }
            catch
            {
                TempData["ActionResponse"] = "Unable to delete voucher.";
                return PartialView("VUC_TransactionList", model);
            }

        }

        [HttpGet]
        public ActionResult Edit(Int64? VoucherNo)
        {
            var result = _ser.GetLedgerVoucherByVoucherNo(VoucherNo);

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(LedgerVoucherModel model)
        {
            LedgerVoucherModel result = new LedgerVoucherModel();
            try
            {
                var obj = (TravelSession)Session["TravelPortalSessionInfo"];
                model.AppUserId = obj.AppUserId;

                string clientIP;
                clientIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (clientIP == string.Empty)
                {
                    clientIP = Request.ServerVariables["REMOTE_ADDR"];
                }
                model.CheckerTerminal = clientIP;

                _ser.EditGL_Transactions(model);
                result = _ser.GetLedgerVoucherByVoucherNo(model.VoucherNo);
                TempData["SuccessMessage"] = "Successfully Edited General Voucher";
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = "There is an error: " + ex.Message;
                return View(result);
            }
        }
    }
}
