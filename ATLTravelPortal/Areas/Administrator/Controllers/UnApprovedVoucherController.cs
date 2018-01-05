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
    [PermissionDetails(View = "Index", Add = "Approve", Delete = "Cancel", Order = 2)]
    public class UnApprovedVoucherController : Controller
    {
        //
        // GET: /UnApprovedVoucher/

        UnApprovedVoucherProvider ser = new UnApprovedVoucherProvider();

        public ActionResult Index()
        {
            UnApprovedVoucherModel model = new UnApprovedVoucherModel();
            model.UnApprovedVoucherList = ser.GetUnapprovedvoucherList();


            return View(model);
        }



      
        public ActionResult Approve(long id)
        {

            UnApprovedVoucherModel model = new UnApprovedVoucherModel();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            ser.Approve(id, ts.AppUserId);

            model.UnApprovedVoucherList = ser.GetUnapprovedvoucherList();

          //  return View("Index", model);
            return RedirectToAction("Index");

        }


        public ActionResult Cancel(long id)
        {
            UnApprovedVoucherModel model = new UnApprovedVoucherModel();

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            ser.Cancel(id, ts.AppUserId);
            model.UnApprovedVoucherList = ser.GetUnapprovedvoucherList();

            return View("Index", model);
        }

    }
}
