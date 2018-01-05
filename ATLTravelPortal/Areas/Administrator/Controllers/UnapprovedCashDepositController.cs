using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Details = "Details", Order = 2)]

    public class UnapprovedCashDepositController : Controller
    {
        //
        // GET: /Airline/UnapprovedCashDeposit/
        UnapprovedCashDepositProvider pro = new UnapprovedCashDepositProvider();

        [HttpGet]
        public ActionResult Index()
        {
            UnapprovedCashDepositModel model = new UnapprovedCashDepositModel();
            model.unapprovedCashDepositList = pro.GetUnApprovedList();
            return View(model);
        }

       

         [HttpGet]
        public ActionResult Details(int id)
        {

            UnapprovedCashDepositModel model = new UnapprovedCashDepositModel();
            model = pro.GetUnApprovedDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(string id)
        {
            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                pro.ApproveCashDeposit(int.Parse(id), ts.AppUserId);
            }
            catch
            {
                UnapprovedCashDepositModel model = new UnapprovedCashDepositModel();
                model = pro.GetUnApprovedDetails(int.Parse(id));
                TempData["error"] = "Cannot approve the transaction";
                return View(model);
                
            }
           return RedirectToAction("Index");
        }

    }
}
