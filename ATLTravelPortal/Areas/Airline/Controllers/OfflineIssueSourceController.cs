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
    public class OfflineIssueSourceController : Controller
    {
        OfflineIssueSourceProvider _provider = new OfflineIssueSourceProvider();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            OfflineIssueSourceModel model = new OfflineIssueSourceModel();
            model.SourceList = _provider.GetList().ToPagedList(currentPageIndex,defaultPageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OfflineIssueSourceModel model)
        {
            if (ModelState.IsValid)
            {
                if (_provider.IfHeadingExists(model.ServiceProvider, model.OfflineBookingServiceProviderId))
                {
                   // var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                    _provider.Save(model);
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Source Name already exists";
                return View(model);
            }
            return View(model);

        }

        public ActionResult Edit(int Id)
        {
            OfflineIssueSourceModel model = _provider.GetDetails(Id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(OfflineIssueSourceModel model, int Id)
        {
            if (ModelState.IsValid)
            {
                if (_provider.IfHeadingExists(model.ServiceProvider, Id))
                {
                    model.OfflineBookingServiceProviderId = Id;
                    //var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                    _provider.Edit(model);
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Source Name already exists";
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
