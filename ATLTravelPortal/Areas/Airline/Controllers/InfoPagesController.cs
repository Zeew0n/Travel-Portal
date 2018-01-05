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
    [ValidateInput(false)]
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Details", Delete = "Delete", Order = 2)]
    public class InfoPagesController : Controller
    {
        InfoPagesProvider _provider = new InfoPagesProvider();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            InfoPagesModel model = new InfoPagesModel();
            model.InfoPagesList = _provider.GetList().ToPagedList(currentPageIndex,defaultPageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(InfoPagesModel model)
        {
            if (ModelState.IsValid)
            {
                _provider.Save(model);
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }
        public ActionResult Edit(int Id)
        {
            InfoPagesModel model = _provider.GetDetails(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int Id,InfoPagesModel model)
        {
            if (ModelState.IsValid)
            {
                model.InfoId = Id;
                _provider.Edit(model);
                return RedirectToAction("Index");
            }
            return View("Edit", model);
        }
        public ActionResult Details(int Id)
        {
            InfoPagesModel model = _provider.GetDetails(Id);
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            _provider.Delete(Id);
            return RedirectToAction("Index");
        }
        public ActionResult InfoPages(string Id)
        {
            InfoPagesModel model = new InfoPagesModel();
            model.Description =HttpUtility.HtmlDecode(_provider.GetDescription(Id));
            return View(model);
        }
    }
}
