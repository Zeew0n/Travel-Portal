using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Models;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Approve", Order = 2)]

    public class ApproveFXRateController : Controller
    {
        //
        // GET: /Administrator/ApproveFXRate/
       

        FXRateProvider pro = new FXRateProvider();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            FXRateModel model = new FXRateModel();
            model.FXRateList = pro.List().ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }

        public ActionResult Approve(int? id)
        {
            pro.Approve(id);
            Session["ActionResponse"] = _res;
            return RedirectToAction("Index");
        }

    }
}
