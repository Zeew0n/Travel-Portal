using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [PermissionDetails(View = "Index", Order = 2)]

    public class AgentLedgerTransactionsController : Controller
    {
        //
        // GET: /Administrator/AgentLedgerTransactions/
        AgentLedgerTransactionsProvider pro = new AgentLedgerTransactionsProvider();

        [HttpGet]
        public ActionResult Index()
        {
            AgentLedgerTransactionsModel model = new AgentLedgerTransactionsModel
            {
                AgentList = pro.GetAllAgentList(),
                ProductList = pro.GetAllProductList(),

            };
            ViewData["Currency"] = new SelectList(pro.GetCurrencies(), "CurrencyId", "CurrencyCode");
            model.FromDate = DateTime.Now.AddDays(-30);
            model.ToDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentLedgerTransactionsModel model)
        {

            model.LedgerList = pro.GetTransactionList(model.AgentId, model.ProductId, (DateTime) model.FromDate,(DateTime) model.ToDate, model.CurrencyId, 1);
            model.AgentList = pro.GetAllAgentList();
            if (model.AgentId != null)
            {
                model.AvailableBalance = new ATLTravelPortal.Areas.Airline.Repository.GeneralProvider().GetAccountInfoByAgentId(model.AgentId.Value);
                model.CreditLimitList = new CreditLimitProvider().GetAgentCreditLimitListByAgentId(model.AgentId.Value);
            }
            model.ProductList = pro.GetAllProductList();
            ViewData["Currency"] = new SelectList(pro.GetCurrencies(), "CurrencyId", "CurrencyCode");

            return View(model);
        }

    }
}
