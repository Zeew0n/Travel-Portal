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
    public class DistributorMakePaymentController : Controller
    {
        //
        // GET: /Administrator/DistributorMakePayment/
        // paymentmode: 1-Cash, 2-Cheque, 3-Draft, 4-BankTransfer, 5-RTGS, 6-CashGivenTo
        //status: 1-Approved, 2-Processing, 3-Rejected
        MakePaymentProvider ser = new MakePaymentProvider();

        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession(); ;
            MakePaymentModel model = new MakePaymentModel();
            model.AgentId = ts.LoginTypeId;
            model.ChequeList = ser.GetChequeList(model.AgentId);
            model.DraftList = ser.GetDraftList(model.AgentId);
            model.CashList = ser.GetCashList(model.AgentId);
            model.BankTransferList = ser.GetBankTransferList(model.AgentId);
            model.RTGSList = ser.GetRTGSList(model.AgentId);
            model.CashGivenToList = ser.GetCashGivenToList(model.AgentId);
            model.CreditList = ser.GetCreditRequestList(model.AgentId);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MakePaymentModel model = new MakePaymentModel();

            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");
            model.CreditRequestCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.SalesAgentList = ser.GetAllGetSalesAgentList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(MakePaymentModel model)
        {
            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");
            model.SalesAgentList = ser.GetAllGetSalesAgentList();

            var ts = SessionStore.GetTravelSession(); ;

            model.AgentId = ts.LoginTypeId;
            model.CreatedBy = ts.AppUserId;
            model.flag = "DistributorMakePayment";

           
            if (model.rdbPaymentMode.ToString() == "Cheque")
            {
                model.PaymentModeId = 2;

                string chequedrawnonbankname = ser.GetBankName(model.ChequeDrawnonBank);
                model.ChequeDrawnonBankName = chequedrawnonbankname;
                string chequebankname = ser.GetBankName(model.ChequeBankId);
                model.ChequeBankName = chequebankname;
                string chequebranchname = ser.GetBankBranchName(model.ChequeBankBranchId);
                model.ChequeBranchName = chequebranchname;
               
                ser.BranchChequeAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "Draft")
            {
                model.PaymentModeId = 3;

                string draftbankname = ser.GetBankName(model.DraftBankId);
                model.DraftBankName = draftbankname;
                string draftbankbranchname = ser.GetBankBranchName(model.DraftBankBranchId);
                model.DraftBranchName = draftbankbranchname;
                ser.BranchDraftAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "Cash")
            {
                model.PaymentModeId = 1;

                string cashbankname = ser.GetBankName(model.CashBankId);
                model.CashBankName = cashbankname;
                string cashbankbranchname = ser.GetBankBranchName(model.DraftBankBranchId);
                model.CashBranchName = cashbankbranchname;

                ser.BranchCashAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "BankTransfer")
            {
                model.PaymentModeId = 4;

                string banktransferbankname = ser.GetBankName(model.BankTransferBankId);
                model.BankTransferBankName = banktransferbankname;
                string banktransferbranchname = ser.GetBankBranchName(model.BankTransferBankBranchId);
                model.BankTransferBranchName = banktransferbranchname;

                ser.BranchBankTransferAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "RTGS")
            {
                model.PaymentModeId = 5;

                string RTGSbankname = ser.GetBankName(model.RTGSBankId);
                model.RTSSBankName = RTGSbankname;
                string RTGSbranchname = ser.GetBankBranchName(model.RTGSBankBranchId);
                model.RTGSBranchName = RTGSbranchname;

                ser.BranchRTGSAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "CashGivenTo")
            {
                model.PaymentModeId = 6;

                ser.BranchCashGivenToAdd(model);
            }

            if (model.rdbPaymentMode.ToString() == "CreditRequest")
            {
                model.PaymentModeId = 7;
                ser.BranchCreditRequest(model, ts.AppUserId);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
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

            model.CreditRequestCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");

            model.SalesAgentList = ser.GetAllGetSalesAgentList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, MakePaymentModel model)
        {
            var ts = SessionStore.GetTravelSession(); ;
            model.AgentId = ts.LoginTypeId;
            model.UpdatedBy = ts.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;
            model.CreatedBy = ts.AppUserId;

            model.DepositId = Id;

            MakePaymentModel m = new MakePaymentModel();

            ViewData["Bank"] = new SelectList(ser.AllBank(), "BankId", "BankName");
            ViewData["BankBranch"] = new SelectList(ser.AllBankBranch(model.BankId), "BankBranchId", "BranchName");
            ViewData["ChequeDrawnOnBank"] = new SelectList(ser.GetBank(), "BankId", "BankName");
            model.SalesAgentList = ser.GetAllGetSalesAgentList();

            m = ser.GetBranchDistributroPaymentDetail(Id);

            model.flag = "DistributorMakePayment";

            if (model.rdbPaymentMode.ToString() == "Cash")
            {
                model.PaymentModeId = 1;
                ser.BranchCashEdit(model);
            }
            if (model.rdbPaymentMode.ToString() == "Cheque")
            {
                model.PaymentModeId = 2;
                ser.BranchChequeEdit(model);
            }
            if (model.rdbPaymentMode.ToString() == "Draft")
            {
                model.PaymentModeId = 3;
                ser.BranchDraftEdit(model);
            }

            if (model.rdbPaymentMode.ToString() == "BankTransfer")
            {
                model.PaymentModeId = 4;
                ser.BranchBankTransferEdit(model);
            }
            if (model.rdbPaymentMode.ToString() == "RTGS")
            {
                model.PaymentModeId = 5;
                ser.BranchRTGSEdit(model);
            }
            if (model.rdbPaymentMode.ToString() == "CashGivenTo")
            {
                model.PaymentModeId = 6;
                ser.BranchCashGivenToEdit(model);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            ser.BranchDistributorMakePaymentDelete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            MakePaymentModel model = new MakePaymentModel();
            model = ser.GetBranchDistributroPaymentDetail(id);
            return View(model);
        }


    }
}
