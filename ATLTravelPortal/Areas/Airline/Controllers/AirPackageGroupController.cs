using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class AirPackageGroupController : Controller
    {
        //
        // GET: /Airline/AirPackageGroup/

         AirPackageGroupModel _model = new AirPackageGroupModel();
         AirPackageGroupProvider _provider = new AirPackageGroupProvider();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            AirPackageGroupModel _model = new AirPackageGroupModel();
            _model.PackageList = _provider.ListPackage().ToPagedList(currentPageIndex,defaultPageSize);
            return View(_model);
        }

        public ActionResult Create()
        {
            AirPackageGroupModel _model = new AirPackageGroupModel();
            _provider.getddl(_model);
            _model.ddlCountryList = CountryProvider.GetSelectListOptions();
            _model.ddlZoneList = new SelectList(_provider.GetZoneList(), "ZoneId", "ZoneValue");
           return View(_model);
        }
         [HttpPost, ValidateInput(false)]
        public ActionResult Create(AirPackageGroupModel _model)
        {
            _provider.getddl(_model);
            _provider.AddPackage(_model);

          
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AirPackageGroupModel _model = new AirPackageGroupModel();

            _model = _provider.PackageDetails(id);
            _provider.getddl(_model);
            _model.PackageGroupID = id;

            
            return View(_model);
        
        }

         [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, AirPackageGroupModel _model)
        {
            _model.PackageGroupID = id;

            _provider.EditPackage(_model);

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            _provider.DeletePackage(id);
            return RedirectToAction("Index");
        
        }

        public ActionResult Details(int id)
        {
            AirPackageGroupModel _model = new AirPackageGroupModel();
            _model = _provider.PackageDetails(id);

            return View(_model);
        }
    }
}
