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
    public class DistributorLedgerController : Controller
    {
        //
        // GET: /Administrator/DistributorAgentLedger/
        AgentLedgerTransactionsProvider pro = new AgentLedgerTransactionsProvider();
        CreditLimitProvider ser = new CreditLimitProvider();


        [HttpGet]
        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();

            AgentLedgerTransactionsModel model = new AgentLedgerTransactionsModel();
            model.AgentList = ser.GetAllAgentListByDistributorId();
            model.Currencies = ser.GetAllCurrenciesList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentLedgerTransactionsModel model)
        {
            var ts = SessionStore.GetTravelSession();
            GeneralRepository _generalRepo = new GeneralRepository();
            model.LedgerList = pro.GetTransactionList(ts.LoginTypeId, 1, (DateTime)model.FromDate, (DateTime)model.ToDate, model.CurrencyId, 3);
            model.AgentList = ser.GetAllAgentListByDistributorId();
            if (model.AgentId > 0)
            {
                model.AvailableBalance = new Airline.Repository.GeneralProvider().GetAgentAccountInfoByAgentId(model.AgentId.Value);

                model.CreditLimitList = new CreditLimitProvider().GetAgentCreditLimitListByAgentId(model.AgentId.Value);
            }

            model.Currencies = ser.GetAllCurrenciesList();

            return View(model);
        }


    }
}
