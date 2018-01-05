using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Models;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 1)]
    public class FXRateController : Controller
    {
        //
        // GET: /Administrator/FXRate/
       
        FXRateProvider _pro = new FXRateProvider();
        DateTime CurrentDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            FXRateModel model = new FXRateModel();
            model.FXRateList = _pro.List().ToPagedList(currentPageIndex, defaultPageSize);
            //model.ExchangeRate = 0;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FXRateModel model)
        {
            model.CreatedBy = LogedUserId;
            model.CreatedDate = CurrentDate;
            _res = _pro.Create(model);
            Session["ActionResponse"] = _res;

            //if (_res.ErrNumber > 0)
            //    return RedirectToAction("Index");
            //else
            //    return View(model);

            return RedirectToAction("Index");
        }

    }
}
