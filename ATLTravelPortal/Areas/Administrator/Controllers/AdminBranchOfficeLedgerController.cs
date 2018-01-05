using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline;
using ATLTravelPortal.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class AdminBranchOfficeLedgerController : Controller
    {
        //
        // GET: /Administrator/AdminBranchOfficeLedger/
        AgentLedgerTransactionsProvider pro = new AgentLedgerTransactionsProvider();
        CreditLimitProvider ser = new CreditLimitProvider();
        public ActionResult Index()
        {
            var ts = SessionStore.GetTravelSession();

            AgentLedgerTransactionsModel model = new AgentLedgerTransactionsModel();
            model.BranchOfficeList = ser.GetAllBranchOfficeList();
            model.Currencies = ser.GetAllCurrenciesList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(AgentLedgerTransactionsModel model)
        {
            GeneralRepository _generalRepo = new GeneralRepository();
            model.LedgerList = pro.GetTransactionList(model.BranchOfficeId, 1, (DateTime)model.FromDate, (DateTime)model.ToDate, model.CurrencyId, 2);
            model.BranchOfficeList = ser.GetAllBranchOfficeList();
            if (model.BranchOfficeId > 0)
            {
                model.AvailableBalance = new Airline.Repository.GeneralProvider().GetBranchOfficeAccountInfoByBranchOfficeId(model.BranchOfficeId.Value);

                model.CreditLimitList = new CreditLimitProvider().GetBranchOfficeCreditLimitList(model.BranchOfficeId.Value);
            }

            model.Currencies = ser.GetAllCurrenciesList();

            return View(model);
        }

    }
}
