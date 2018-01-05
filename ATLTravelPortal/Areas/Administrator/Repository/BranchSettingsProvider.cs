using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class BranchSettingsProvider
    {
        EntityModel entity = new EntityModel();

        public AdminConfigurationModel GetAdminConfigurationDetail(int branchID, int settingID)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == settingID && x.BranchID == branchID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.SettingID = (int)result.SettingId;
            model.ByPass = result != null ? ByPass.Allow : ByPass.Disallow;
            return model;
        }

        public AdminConfigurationModel GetBusAdminConfigurationDetail(int branchID, int settingID)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == settingID && x.BranchID == branchID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.BusSettingID = (int)result.SettingId;
            model.BusByPass = result != null ? ByPass.BusAllow : ByPass.BusDisallow;
            return model;
        }

        public AdminConfigurationModel GetMobileAdminConfigurationDetail(int branchID, int settingID)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == settingID && x.BranchID == branchID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.MobileSettingID = (int)result.SettingId;
            model.MobileByPass = result != null ? ByPass.MobileAllow : ByPass.MobileDisallow;
            return model;
        }

        public AdminConfigurationModel GetHotelAdminConfigurationDetail(int branchID, int settingID)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == settingID && x.BranchID == branchID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.HotelSettingID = (int)result.SettingId;
            model.HotelByPass = result != null ? ByPass.HotelAllow : ByPass.MobileAllow;
            return model;
        }


        public int checkDuplicateRow(int branchID, int settingID)
        {
            var chk = entity.BranchSettings.Where(x => x.SettingId == settingID && x.BranchID == branchID).FirstOrDefault();
            if (chk != null)
            {
                return chk.SettingId.Value;
            }
            else
            {
                return 0;
            }
        }



        public void AdminConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.ByPass == ByPass.Allow)
            {
                BranchSettings datamodel = new BranchSettings
                {
                    BranchID = model.BranchOfficeID,
                    SettingId = model.SettingID
                };
                entity.AddToBranchSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminConfigurationEdit(AdminConfigurationModel model)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == model.SettingID && x.BranchID == model.BranchOfficeID).FirstOrDefault();
            if (model.ByPass == ByPass.Disallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }




        public void AdminBusConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.BusByPass == ByPass.BusAllow)
            {
                BranchSettings datamodel = new BranchSettings
                {
                    BranchID = model.BranchOfficeID,
                    SettingId = model.BusSettingID
                };
                entity.AddToBranchSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminMobileConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.MobileByPass == ByPass.MobileAllow)
            {
                BranchSettings datamodel = new BranchSettings
                {
                    BranchID = model.BranchOfficeID,
                    SettingId = model.MobileSettingID
                };
                entity.AddToBranchSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminHotelConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.HotelByPass == ByPass.HotelAllow)
            {
                BranchSettings datamodel = new BranchSettings
                {
                    BranchID = model.BranchOfficeID,
                    SettingId = model.HotelSettingID
                };
                entity.AddToBranchSettings(datamodel);
                entity.SaveChanges();
            }
        }


        public void AdminBusConfigurationEdit(AdminConfigurationModel model)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == model.BusSettingID && x.BranchID == model.BranchOfficeID).FirstOrDefault();
            if (model.BusByPass == ByPass.BusDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }

        public void AdminMobileConfigurationEdit(AdminConfigurationModel model)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == model.MobileSettingID && x.BranchID == model.BranchOfficeID).FirstOrDefault();
            if (model.MobileByPass == ByPass.MobileDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }

        public void AdminHotelConfigurationEdit(AdminConfigurationModel model)
        {
            BranchSettings result = entity.BranchSettings.Where(x => x.SettingId == model.HotelSettingID && x.BranchID == model.BranchOfficeID).FirstOrDefault();
            if (model.HotelByPass == ByPass.HotelDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }
    }
}