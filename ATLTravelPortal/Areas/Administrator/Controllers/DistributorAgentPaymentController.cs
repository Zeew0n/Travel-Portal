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
    public class DistributorAgentPaymentController : Controller
    {
        //
        // GET: /Administrator/DistributorAgentPayment/

        // paymentmode: 1-Cash, 2-Cheque, 3-Draft, 4-BankTransfer, 5-RTGS, 6-CashGivenTo
        //status: 1-Approved, 2-Processing, 3-Rejected

        MakePaymentProvider ser = new MakePaymentProvider();

        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();
            MakePaymentModel model = new MakePaymentModel();
            model.AgentCashDepositsList = ser.GetDistributorAgentCashDepositsList(ts.AppUserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? AgentId, string AgencyName)
        {
            MakePaymentModel model = new MakePaymentModel();
            var ts = SessionStore.GetTravelSession();
            if (AgencyName != null)
            {
                string SearchText = AgencyName.ToString().Trim();
                model.AgentCashDepositsList = ser.GetDistributorAgentCashDepositsList(ts.AppUserId).Where(xx => xx.AgencyName.Contains(SearchText)).ToList();
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
            model.AgentList = new CreditLimitProvider().GetAllDistributorAgentList(ts.LoginTypeId);

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
            model.AgentList = new CreditLimitProvider().GetAllDistributorAgentList(ts.LoginTypeId);
          
            model.CreatedBy = ts.AppUserId;

            if (model.rdbPaymentMode.ToString() == "Cash")
            {
                model.PaymentModeId = 1;
                ser.CashAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "Cheque")
            {
                model.PaymentModeId = 2;
                ser.ChequeAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "Draft")
            {
                model.PaymentModeId = 3;
                ser.DraftAdd(model);
            }

            if (model.rdbPaymentMode.ToString() == "BankTransfer")
            {
                model.PaymentModeId = 4;
                ser.BankTransferAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "RTGS")
            {
                model.PaymentModeId = 5;
                ser.RTGSAdd(model);
            }
            if (model.rdbPaymentMode.ToString() == "CashGivenTo")
            {
                model.PaymentModeId = 6;
                ser.CashGivenToAdd(model);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var ts = SessionStore.GetTravelSession();
            MakePaymentModel model = new MakePaymentModel();
            model = ser.GetMakePaymentDetail(Id);
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
            model.AgentList = new CreditLimitProvider().GetAllDistributorAgentList(ts.LoginTypeId);
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
            model.AgentList = new CreditLimitProvider().GetAllDistributorAgentList(ts.LoginTypeId);


            model.ChequeCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.DraftCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.BankTransferCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.RTGSCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");
            model.CashGivenToCurrencyList = new SelectList(ser.GetCurrenciesList(), "Value", "Text");


            m = ser.GetMakePaymentDetail(Id);

            try
            {


                if (model.rdbPaymentMode.ToString() == "Cash")
                {
                    model.PaymentModeId = 1;
                    ser.CashEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "Cheque")
                {
                    model.PaymentModeId = 2;
                    ser.ChequeEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "Draft")
                {
                    model.PaymentModeId = 3;
                    ser.DraftEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);
                }

                if (model.rdbPaymentMode.ToString() == "BankTransfer")
                {
                    model.PaymentModeId = 4;
                    ser.BankTransferEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "RTGS")
                {
                    model.PaymentModeId = 5;
                    ser.RTGSEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);
                }
                if (model.rdbPaymentMode.ToString() == "CashGivenTo")
                {
                    model.PaymentModeId = 6;
                    ser.CashGivenToEdit(model);
                    ser.ApproveUnapproveMakePayment((int)Id, model.UpdatedBy);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {


                TempData["ActionResponse"] = ex.Message;
                return RedirectToAction("Edit", new { @Id = Id });
            }


        }


        public ActionResult Delete(int Id)
        {

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            try
            {
                MakePaymentModel model = new MakePaymentModel();
                model.DeletedBy = ts.AppUserId;

                ser.MakePaymentDelete(Id, model.DeletedBy);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            MakePaymentModel model = new MakePaymentModel();
            model = ser.GetMakePaymentDetail(id);
            return View(model);
        }




    }
}
