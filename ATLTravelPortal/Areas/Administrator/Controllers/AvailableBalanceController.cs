using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class AvailableBalanceController : Controller
    {
        //
        // GET: /Administrator/AvailableBalance/

        AvailableBalanceProvider pro = new AvailableBalanceProvider();

        [HttpGet]
        public ActionResult Index()
        {
            AvailableBalanceModel model = new AvailableBalanceModel();
            //{
            //    AgentList=pro.GetAllAgentList()
            //};

            model.AvailableBalanceList = pro.GetAvailableBalance();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(AvailableBalanceModel model)
        //{
         
        //        model.AgentList = pro.GetAllAgentList();
        //        model.AvailableBalanceList = pro.GetAvailableBalance();
            
        //    return View(model);
        //}

    }
}
