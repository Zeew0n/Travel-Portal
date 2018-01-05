using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class AdminDistributorLedgerController : Controller
    {
        //
        // GET: /Administrator/AdminDistributorLedger/
        AgentLedgerTransactionsProvider pro = new AgentLedgerTransactionsProvider();
        CreditLimitProvider ser = new CreditLimitProvider();
        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();

            AgentLedgerTransactionsModel model = new AgentLedgerTransactionsModel();
            model.DistributorList = ser.GetAllAdminDistributorList();
            model.Currencies = ser.GetAllCurrenciesList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentLedgerTransactionsModel model)
        {
            GeneralRepository _generalRepo = new GeneralRepository();
            model.LedgerList = pro.GetTransactionList(model.DistributorId, 1, (DateTime)model.FromDate, (DateTime)model.ToDate, model.CurrencyId, 3);
            model.DistributorList = ser.GetAllAdminDistributorList();
            if (model.DistributorId > 0)
            {
                model.AvailableBalance = new Airline.Repository.GeneralProvider().GetDistributorAccountInfoByDistributorId(model.DistributorId.Value);

                model.CreditLimitList = new CreditLimitProvider().GetLedgerCreditLimitList(model.DistributorId.Value);
            }

            model.Currencies = ser.GetAllCurrenciesList();

            return View(model);
        }

    }
}
