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
    [PermissionDetails(View = "Index", Order = 2)]
    public class LedgerTransactionController : Controller
    {
        //
        // GET: /LedgerTransaction/
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public ActionResult Index()
        {
            var agentList = ent.Agents.ToList();
            ViewData["agentList"] = agentList;
            return View();
        }

    }
}
