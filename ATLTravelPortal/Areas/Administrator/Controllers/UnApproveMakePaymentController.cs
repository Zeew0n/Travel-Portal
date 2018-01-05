using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
     [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "Detail", Delete = "Delete", Order = 2)]
    public class UnApproveMakePaymentController : Controller
    {
        //
        // GET: /Administrator/UnApproveMakePayment/
        UnApproveMakePaymentProvider ser = new UnApproveMakePaymentProvider();

        public ActionResult Index()
        {
            UnApproveMakePaymentModel model = new UnApproveMakePaymentModel();
            model.UnAppoveMakePaymentList = ser.GetUnApprovedMakePaymentList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            UnApproveMakePaymentModel model = new UnApproveMakePaymentModel();
            model.DepositId = id;
            model = ser.GetUnApprovedMakePaymentDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(string id)
        {
            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                ser.ApproveUnapproveMakePayment(int.Parse(id), ts.AppUserId);
            }
            catch
            {
                UnApproveMakePaymentModel model = new UnApproveMakePaymentModel();
                model = ser.GetUnApprovedMakePaymentDetails(int.Parse(id));
                TempData["error"] = "Cannot approve the transaction";
                return View(model);

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                ser.RejectDeposit(id, ts.AppUserId);
            }
            catch 
            {
            }
            return RedirectToAction("Index");
        }

    }
}
