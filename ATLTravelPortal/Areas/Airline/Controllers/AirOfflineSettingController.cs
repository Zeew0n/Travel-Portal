using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;


namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Detail", Delete = "Delete", Order = 2)]
    public class AirOfflineSettingController : Controller
    {
        AirOfflineSettingProvider provider = new AirOfflineSettingProvider();
        AirOfflineSettingModel model = new AirOfflineSettingModel();

        //
        // GET: /Airline/OfflineBookAirline/

        public ActionResult Index()
        {
            var list = provider.GetOfflineAirlineList();
            if (list != null)
            {
                model.AirlineList.AddRange(list);
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(AirOfflineSettingModel model)
        {
            provider.ActionSaveUpdate(model, "U");
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AirOfflineSettingModel model)
        {
            provider.Save(model);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(AirOfflineSettingModel model)
        {
            return new EmptyResult();
        }


        public ActionResult Detail(int PId)
        {
            return new EmptyResult();
          
        }

        public ActionResult Delete(int id)
        {
            
            var deleteMsg = provider.Delete(id);
            return RedirectToAction("Index");
        }

       

    }
}
