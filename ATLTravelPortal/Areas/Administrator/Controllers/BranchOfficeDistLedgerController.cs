using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline;
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class BranchOfficeDistLedgerController : Controller
    {
        //
        // GET: /Administrator/BranchOfficeDistLedger/
        AgentLedgerTransactionsProvider pro = new AgentLedgerTransactionsProvider();
        CreditLimitProvider ser = new CreditLimitProvider();

        [HttpGet]
        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();

            AgentLedgerTransactionsModel model = new AgentLedgerTransactionsModel();
            model.DistributorList = ser.GetAllDistributorList();
            model.Currencies = ser.GetAllCurrenciesList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentLedgerTransactionsModel model)
        {
            var ts = SessionStore.GetTravelSession();

            GeneralRepository _generalRepo = new GeneralRepository();
            model.LedgerList = pro.GetTransactionList(model.DistributorId, 1, (DateTime)model.FromDate, (DateTime)model.ToDate, model.CurrencyId, 3);
            model.DistributorList = ser.GetAllDistributorList();
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
