using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class BranchDistributorPaymentController : Controller
    {
        //
        // GET: /Administrator/BranchDistributorPayment/

        // paymentmode: 1-Cash, 2-Cheque, 3-Draft, 4-BankTransfer, 5-RTGS, 6-CashGivenTo
        //status: 1-Approved, 2-Processing, 3-Rejected

        MakePaymentProvider ser = new MakePaymentProvider();

        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();
            MakePaymentModel model = new MakePaymentModel();
            model.AgentCashDepositsList = ser.GetBranchDistributorCashDepositsList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? AgentId, string DistributorName)
        {
            MakePaymentModel model = new MakePaymentModel();
            var ts = SessionStore.GetTravelSession();
            if (DistributorName != null)
            {
                string SearchText = DistributorName.ToString().Trim();
                model.AgentCashDepositsList = ser.GetBranchDistributorCashDepositsList().Where(xx => xx.AgencyName.Contains(SearchText)).ToList();
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var ts = SessionStore.GetTravelSession();
            MakePaymentModel model = new MakePaymentModel();
            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");

            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");

            model.SalesAgentList = ser.GetAllGetSalesAgentList();
            model.AgentList = new CreditLimitProvider().GetAllBranchDistributorList(ts.LoginTypeId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MakePaymentModel model)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");
            model.SalesAgentList = ser.GetAllGetSalesAgentList();
            model.AgentList = new CreditLimitProvider().GetAllBranchDistributorList(ts.LoginTypeId);

            model.CreatedBy = ts.AppUserId;

            if (model.rdbPaymentMode.ToString() == "Cash")
            {
                model.PaymentModeId = 1;
                int depositid = ser.BranchCashAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }
            if (model.rdbPaymentMode.ToString() == "Cheque")
            {
                model.PaymentModeId = 2;
                int depositid = ser.BranchChequeAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }
            if (model.rdbPaymentMode.ToString() == "Draft")
            {
                model.PaymentModeId = 3;
                int depositid = ser.BranchDraftAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }

            if (model.rdbPaymentMode.ToString() == "BankTransfer")
            {
                model.PaymentModeId = 4;
                int depositid = ser.BranchBankTransferAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }
            if (model.rdbPaymentMode.ToString() == "RTGS")
            {
                model.PaymentModeId = 5;
                int depositid = ser.BranchRTGSAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }
            if (model.rdbPaymentMode.ToString() == "CashGivenTo")
            {
                model.PaymentModeId = 6;
                int depositid = ser.BranchCashGivenToAdd(model);
                ser.ApproveUnapprovedBranchDistributorMakePayment(depositid, model.CreatedBy);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var ts = SessionStore.GetTravelSession();
            MakePaymentModel model = new MakePaymentModel();
            model = ser.GetBranchDistributroPaymentDetail(Id);
            model.CashGivenToDate = TimeFormat.DateFormat(model.CashGivenToDepositDate.ToString());
            model.ChequeDate = TimeFormat.DateFormat(model.ChequeIssueDate.ToString());
            model.DraftDate = TimeFormat.DateFormat(model.DraftDepositDate.ToString());
            model.CashDate = TimeFormat.DateFormat(model.CashDepositDate.ToString());
            model.BankTransferDate = TimeFormat.DateFormat(model.BankTransferDepositDate.ToString());
            model.RTGSDate = TimeFormat.DateFormat(model.RTGSDepositDate.ToString());

            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");


            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");

            model.SalesAgentList = ser.GetAllGetSalesAgentList();
            model.AgentList = new CreditLimitProvider().GetAllBranchDistributorList(ts.LoginTypeId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, MakePaymentModel model)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            model.DepositId = Id;
            model.UpdatedBy = ts.AppUserId;

            MakePaymentModel m = new MakePaymentModel();

            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");
            model.SalesAgentList = ser.GetAllGetSalesAgentList();
            model.AgentList = new CreditLimitProvider().GetAllBranchDistributorList(ts.LoginTypeId);
            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");

            m = ser.GetBranchDistributroPaymentDetail(Id);

            try
            {
                if (model.rdbPaymentMode.ToString() == "Cash")
                {
                    model.PaymentModeId = 1;
                    ser.BranchCashEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "Cheque")
                {
                    model.PaymentModeId = 2;
                    ser.BranchChequeEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "Draft")
                {
                    model.PaymentModeId = 3;
                    ser.BranchDraftEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);
                }

                if (model.rdbPaymentMode.ToString() == "BankTransfer")
                {
                    model.PaymentModeId = 4;
                    ser.BranchBankTransferEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "RTGS")
                {
                    model.PaymentModeId = 5;
                    ser.BranchRTGSEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "CashGivenTo")
                {
                    model.PaymentModeId = 6;
                    ser.BranchCashGivenToEdit(model);
                    ser.ApproveUnapprovedBranchDistributorMakePayment((int)Id, model.UpdatedBy);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return RedirectToAction("Edit", new { @Id = Id });
            }
        }

        public ActionResult Details(int id)
        {
            MakePaymentModel model = new MakePaymentModel();
            model = ser.GetBranchDistributroPaymentDetail(id);
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                MakePaymentModel model = new MakePaymentModel();
                model.DeletedBy = ts.AppUserId;
                ser.MakeBranchDistributorPaymentDelete(Id, model.DeletedBy);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }












    }
}
