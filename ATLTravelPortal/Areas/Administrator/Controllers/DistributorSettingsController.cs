using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class DistributorSettingsController : Controller
    {
        DistributorSettingsProvider distributorSettingsProvider = new DistributorSettingsProvider();

        public ActionResult Index()
        {
            AdminConfigurationModel model = new AdminConfigurationModel();
            AdminConfigurationModel busModel = new AdminConfigurationModel();
            AdminConfigurationModel mobileModel = new AdminConfigurationModel();
            AdminConfigurationModel hotelModel = new AdminConfigurationModel();

            var ts = SessionStore.GetTravelSession();
           
            int settingID = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 13);
            int busSettingID = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 15);
            int mobileSettingID = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 17);
            int hotelSettingID = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 19);

            model.DistributorID = ts.LoginTypeId;
            model.SettingID = 13;
            model.BusSettingID = 15;
            model.MobileSettingID = 17;
            model.HotelSettingID = 19;

            if (settingID != 0)
            {
                model = distributorSettingsProvider.GetAdminConfigurationDetail(ts.LoginTypeId, 13);                
            }
            else
            {
                model.ByPass = ByPass.Disallow;                
            }

            if (busSettingID != 0)
            {
                busModel = distributorSettingsProvider.GetBusAdminConfigurationDetail(ts.LoginTypeId, 15);
                model.BusSettingID = busModel.BusSettingID;
                model.BusByPass = busModel.BusByPass;
            }
            else
            {
                model.BusByPass = ByPass.BusDisallow;
            }

            if (mobileSettingID != 0)
            {
                mobileModel = distributorSettingsProvider.GetMobileAdminConfigurationDetail(ts.LoginTypeId, 17);
                model.MobileSettingID = mobileModel.MobileSettingID;
                model.MobileByPass = mobileModel.MobileByPass;
            }
            else
            {
                model.MobileByPass = ByPass.MobileDisallow;
            }

            if (hotelSettingID != 0)
            {
                hotelModel = distributorSettingsProvider.GetHotelAdminConfigurationDetail(ts.LoginTypeId, 19);
                model.HotelSettingID = hotelModel.HotelSettingID;
                model.HotelByPass = hotelModel.HotelByPass;
            }
            else
            {
                model.HotelByPass = ByPass.HotelDisallow;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AdminConfigurationModel model)
        {
            var ts = SessionStore.GetTravelSession();
            model.DistributorID = ts.LoginTypeId;
            model.SettingID = 13;
            model.BusSettingID = 15;
            model.MobileSettingID = 17;
            model.HotelSettingID = 19;

            int chkduplicate = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 13);
            int chkBusDuplicate = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 15);
            int chkMobileDuplicate = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 17);
            int chkHotelDuplicate = distributorSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 19);

            if (chkduplicate != 0)
            {
                model.AdminConfugrationId = chkduplicate;
                distributorSettingsProvider.AdminConfigurationEdit(model);
            }
            else
            {
                distributorSettingsProvider.AdminConfigurationAdd(model);
            }

            if (chkBusDuplicate != 0)
            {
                model.AdminConfugrationId = chkBusDuplicate;
                distributorSettingsProvider.AdminBusConfigurationEdit(model);
            }
            else
            {
                distributorSettingsProvider.AdminBusConfigurationAdd(model);
            }

            if (chkMobileDuplicate != 0)
            {
                model.AdminConfugrationId = chkMobileDuplicate;
                distributorSettingsProvider.AdminMobileConfigurationEdit(model);
            }
            else
            {
                distributorSettingsProvider.AdminMobileConfigurationAdd(model);
            }

            if (chkHotelDuplicate != 0)
            {
                model.AdminConfugrationId = chkMobileDuplicate;
                distributorSettingsProvider.AdminHotelConfigurationEdit(model);
            }
            else
            {
                distributorSettingsProvider.AdminHotelConfigurationAdd(model);
            }

            TempData["SuccessMessage"] = "Save Successfully.";
            return View(model);
        }
    }
}
