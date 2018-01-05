using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [PermissionDetails(View = "Index", Order = 2)]
    public class ServiceProviderAccountSettingController : Controller
    {
        ServiceProviderAccountSettingProvier serviceProviderAccountSetting = new ServiceProviderAccountSettingProvier();

        [HttpGet]
        public ActionResult Index()
        {
            ServiceProviderAccountSettingModel model = new ServiceProviderAccountSettingModel();

            


            model.ServiceProviders = serviceProviderAccountSetting.GetAllActiveServiceProviders();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(ServiceProviderNames model)
          {
           
              TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
              serviceProviderAccountSetting.DeleteServiceProviderAccountSetting(model.ServiceProviderId);
              serviceProviderAccountSetting.SaveServiceProviderAccountSetting(model.AccountSettingBasedOnServiceProvider.ToList(), model.ServiceProviderId, obj.AppUserId);
              return RedirectToAction("Index");
          }
    }
}
