using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class BranchSettingsController : Controller
    {
        BranchSettingsProvider branchSettingsProvider = new BranchSettingsProvider();

        public ActionResult Index()
        {
            AdminConfigurationModel model = new AdminConfigurationModel();
            AdminConfigurationModel busModel = new AdminConfigurationModel();
            AdminConfigurationModel mobileModel = new AdminConfigurationModel();
            AdminConfigurationModel hotelModel = new AdminConfigurationModel();

            var ts = SessionStore.GetTravelSession();

            int settingID = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 12);

            int busSettingID = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 14);
            int mobileSettingID = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 16);
            int hotelSettingID = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 18);

            model.BranchOfficeID = ts.LoginTypeId;
            model.SettingID = 12;

            model.BusSettingID = 14;
            model.MobileSettingID = 16;
            model.HotelSettingID = 18;

            if (settingID != 0)
            {
                model = branchSettingsProvider.GetAdminConfigurationDetail(ts.LoginTypeId, 12);
            }
            else
            {
                model.ByPass = ByPass.Disallow;                
            }

            if (busSettingID != 0)
            {             
                busModel = branchSettingsProvider.GetBusAdminConfigurationDetail(ts.LoginTypeId, 14);
                model.BusSettingID = busModel.BusSettingID;
                model.BusByPass = busModel.BusByPass;
            }
            else
            {                
                model.BusByPass = ByPass.BusDisallow;
            }

            if (mobileSettingID != 0)
            {
                mobileModel = branchSettingsProvider.GetMobileAdminConfigurationDetail(ts.LoginTypeId, 16);
                model.MobileSettingID = mobileModel.MobileSettingID;
                model.MobileByPass = mobileModel.MobileByPass;
            }
            else
            {
                model.MobileByPass = ByPass.MobileDisallow;
            }


            if (hotelSettingID != 0)
            {
                hotelModel = branchSettingsProvider.GetHotelAdminConfigurationDetail(ts.LoginTypeId, 18);
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
            model.BranchOfficeID = ts.LoginTypeId;
            model.SettingID = 12;

            model.BusSettingID = 14;
            model.MobileSettingID = 16;
            model.HotelSettingID = 18;

            int chkduplicate = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 12);
            int chkBusDuplicate = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 14);
            int chkMobileDuplicate = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 16);
            int chkHotelDuplicate = branchSettingsProvider.checkDuplicateRow(ts.LoginTypeId, 18);

            if (chkduplicate != 0)
            {
                model.AdminConfugrationId = chkduplicate;
                branchSettingsProvider.AdminConfigurationEdit(model);
            }
            else
            {
                branchSettingsProvider.AdminConfigurationAdd(model);
            }

            if (chkBusDuplicate != 0)
            {
                model.AdminConfugrationId = chkBusDuplicate;
                branchSettingsProvider.AdminBusConfigurationEdit(model);
            }
            else
            {
                branchSettingsProvider.AdminBusConfigurationAdd(model);
            }

            if (chkMobileDuplicate != 0)
            {
                model.AdminConfugrationId = chkMobileDuplicate;
                branchSettingsProvider.AdminMobileConfigurationEdit(model);
            }
            else
            {
                branchSettingsProvider.AdminMobileConfigurationAdd(model);
            }

            if (chkHotelDuplicate != 0)
            {
                model.AdminConfugrationId = chkHotelDuplicate;
                branchSettingsProvider.AdminHotelConfigurationEdit(model);
            }
            else
            {
                branchSettingsProvider.AdminHotelConfigurationAdd(model);
            }

            TempData["SuccessMessage"] = "Save Successfully.";
            return View(model);
        }
    }
}
