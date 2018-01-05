using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Delete = "Delete", Details = "Details", Order = 2)]
    public class FaqContentController : Controller
    {
        FAQContentProvider _provider = new FAQContentProvider();
        FAQHeadingProvider provider = new FAQHeadingProvider();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            FAQContentModel model = new FAQContentModel();
            model.FAQContentList = _provider.GetList().ToPagedList(currentPageIndex, defaultPageSize); 
            return View(model);
        }
        public ActionResult Create()
        {
            FAQContentModel model = new FAQContentModel();
            SetDropDownValue(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FAQContentModel model)
        {
            if (ModelState.IsValid)
            {
                var ts= (TravelSession)Session["TravelPortalSessionInfo"];
                model.CreatedBy = ts.AppUserId;
                _provider.Save(model);
                return RedirectToAction("Index");
            }
            SetDropDownValue(model);
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            FAQContentModel model = _provider.Details(Id);
            SetDropDownValue(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FAQContentModel model, int Id)
        {
            if (ModelState.IsValid)
            {
                model.FaqId = Id;
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                model.UpdatedBy = ts.AppUserId;
                _provider.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int Id)
        {
            FAQContentModel model = _provider.Details(Id);
            SetDropDownValue(model);
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            _provider.Delete(Id);
            return RedirectToAction("Index");
        }
        public void SetDropDownValue(FAQContentModel model)
        {
            model.ddlHeadingList = provider.SelectListOptions();
        }

    }
}
