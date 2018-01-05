using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Delete = "Delete", Order = 2)]
    public class CountryManagementController : Controller
    {
        //
        // GET: /Administrator/CountryManagement/
        CountryManagementProvider ser = new CountryManagementProvider();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            CountryManagementModel model = new CountryManagementModel();
            model.CountryManagementList = ser.ListCountry().ToPagedList(currentPageIndex, defaultPageSize); 
            return View(model);
        }

        public ActionResult Create()
        {
            CountryManagementModel model = new CountryManagementModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CountryManagementModel model)
        {
            try
            {
                if (ser.IsCountryExists(model.CountryName) == true)
                {
                    TempData["ErrorMessage"] = "Country already exists!";
                    return View("Create", model);
                }
                else if (ser.IsCountryCodeExists(model.CountryCode) == true)
                {
                    TempData["ErrorMessage"] = "Country Code already exists!";
                    return View("Create", model);
                }
                else
                {
                    ser.CreateCountry(model);
                }
            }
            catch
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            CountryManagementModel model = new CountryManagementModel();

            model = ser.CountryDetail(Id);
            model.CountryId = Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, CountryManagementModel model)
        {
            model.CountryId = Id;
            try
            {
                ser.EditCountry(model);
            }
            catch
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ser.CountryDelete(Id);
            return RedirectToAction("Index");
        }

    }
}
