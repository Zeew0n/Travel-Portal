using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Delete = "Delete", Order = 2)]
    public class OnLineAirlineSettingsController : Controller
    {
        //
        // GET: /Airline/OnLineAirlineSettings/
        OnLineAirlineSettingsProvider ser = new OnLineAirlineSettingsProvider();

        public ActionResult Index(int? id)
        {
            OnLineAirlineSettingsModel model = new OnLineAirlineSettingsModel();
            // ViewData["ServiceProvider"] = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");

            model.ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");

            if (Request.IsAjaxRequest())
            {
                model.OnLineAirlineSettingList = ser.ListOnlineAirlineSettings(Convert.ToInt32(id));
                return PartialView("ListPartial", model);
            }
            if (id == null)
            {
                model.ServiceProvider = 3;
                model.OnLineAirlineSettingList = ser.ListOnlineAirlineSettings(3);
            }
            else
            {
                model.ServiceProvider = (int)id;
                model.OnLineAirlineSettingList = ser.ListOnlineAirlineSettings((int)id);
            }

            return View(model);
        }



        [HttpPost]
        public ActionResult Index(OnLineAirlineSettingsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            bool flag = false;

            if (model.AirlineCode != null && model.AirlineCode != "")
            {
                int airlineId = ser.GetAirlineId(model.AirlineCode);

                if (airlineId != 0)
                {
                    bool check = ser.CheckIfServiceProviderandAirlineCodeExist(model.ServiceProvider, airlineId);
                    if (check == true)
                    {

                        model.hdfAirlineName = airlineId;
                        model.CreatedBy = obj.AppUserId;
                        ser.CreateOnlineAirlineSettings(model);
                    }
                    else
                    {
                        // TempData["Error"] = "Airline already on Online Mode.";
                        TempData["SuccessMessage"] = "Airline already on Online Mode.";
                        flag = true;

                    }
                }
                else
                {
                    // TempData["AirlineCode"] = "Please Select proper Airline Code";
                    TempData["SuccessMessage"] = "Please Select proper Airline Code";
                    flag = true;
                }
            }

            ViewData["ServiceProvider"] = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");


            if (flag == true)
            {
                model.OnLineAirlineSettingList = ser.ListOnlineAirlineSettings(model.ServiceProvider);
                return View("Index", model);
                //return PartialView("ListPartial", model);
            }

            model.OnLineAirlineSettingList = ser.ListOnlineAirlineSettings(model.ServiceProvider);
            //return PartialView("Index", model);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            OnLineAirlineSettingsModel model = new OnLineAirlineSettingsModel();
            model.ServiceProvider = ser.GetServiceProviderId(Id);
            int id = model.ServiceProvider;
            ser.DeleteOnlineAirlineSettings(Id);
            return RedirectToAction("Index", new { id = id });
        }

    }
}
