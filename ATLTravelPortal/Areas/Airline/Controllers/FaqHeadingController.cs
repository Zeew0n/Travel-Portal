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
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Delete = "Delete", Order = 2)]
    public class FaqHeadingController : Controller
    {
        FAQHeadingProvider _provider = new FAQHeadingProvider();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            FAQHeadingModel model = new FAQHeadingModel();
            model.FAQHeadingList = _provider.GetList().ToPagedList(currentPageIndex, defaultPageSize); 
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FAQHeadingModel model)
        {
            if (ModelState.IsValid)
            {
                if (_provider.IfHeadingExists(model.Title, model.HeadingId))
                {
                    var ts = (TravelSession)Session["TravelPortalSessionInfo"];

                    model.CreatedBy = ts.AppUserId;
                    _provider.Save(model);
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Heading already exists";
                return View(model);
            }
            return View(model);

        }

        public ActionResult Edit(int Id)
        {
            FAQHeadingModel model = _provider.GetDetails(Id);
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Edit(FAQHeadingModel model,int Id)
        {
            if (ModelState.IsValid)
            {
                if (_provider.IfHeadingExists(model.Title, Id))
                {
                    model.HeadingId = Id;
                    var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                    model.UpdatedBy = ts.AppUserId;
                    _provider.Edit(model);
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Heading already exists";
                return View(model);
            }
            return View(model);
        }
        

        public ActionResult Delete(int Id)
        {
            _provider.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}
