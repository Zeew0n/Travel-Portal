using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class DistributorSettingsProvider
    {
        EntityModel entity = new EntityModel();

        public AdminConfigurationModel GetAdminConfigurationDetail(int distributorID, int settingID)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == settingID && x.DistributorID == distributorID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.SettingID = (int)result.SettingId;
            model.ByPass = result != null ? ByPass.Allow : ByPass.Disallow;
            return model;
        }

        public AdminConfigurationModel GetBusAdminConfigurationDetail(int distributorID, int settingID)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == settingID && x.DistributorID == distributorID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.BusSettingID = (int)result.SettingId;
            model.BusByPass = result != null ? ByPass.BusAllow : ByPass.BusDisallow;
            return model;
        }

        public AdminConfigurationModel GetMobileAdminConfigurationDetail(int distributorID, int settingID)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == settingID && x.DistributorID == distributorID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.MobileSettingID = (int)result.SettingId;
            model.MobileByPass = result != null ? ByPass.MobileAllow : ByPass.MobileDisallow;
            return model;
        }

        public AdminConfigurationModel GetHotelAdminConfigurationDetail(int distributorID, int settingID)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == settingID && x.DistributorID == distributorID).FirstOrDefault();
            AdminConfigurationModel model = new AdminConfigurationModel();

            model.HotelSettingID = (int)result.SettingId;
            model.HotelByPass = result != null ? ByPass.HotelAllow : ByPass.HotelDisallow;
            return model;
        }


        public int checkDuplicateRow(int distributorID, int settingID)
        {
            var chk = entity.DistributorSettings.Where(x => x.SettingId == settingID && x.DistributorID == distributorID).FirstOrDefault();
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
                DistributorSettings datamodel = new DistributorSettings
                {
                    DistributorID = model.DistributorID,
                    SettingId = model.SettingID
                };
                entity.AddToDistributorSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminConfigurationEdit(AdminConfigurationModel model)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == model.SettingID && x.DistributorID == model.DistributorID).FirstOrDefault();
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
                DistributorSettings datamodel = new DistributorSettings
                {
                    DistributorID = model.DistributorID,
                    SettingId = model.BusSettingID
                };
                entity.AddToDistributorSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminMobileConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.MobileByPass == ByPass.MobileAllow)
            {
                DistributorSettings datamodel = new DistributorSettings
                {
                    DistributorID = model.DistributorID,
                    SettingId = model.MobileSettingID
                };
                entity.AddToDistributorSettings(datamodel);
                entity.SaveChanges();
            }
        }

        public void AdminHotelConfigurationAdd(AdminConfigurationModel model)
        {
            if (model.HotelByPass == ByPass.HotelAllow)
            {
                DistributorSettings datamodel = new DistributorSettings
                {
                    DistributorID = model.DistributorID,
                    SettingId = model.HotelSettingID
                };
                entity.AddToDistributorSettings(datamodel);
                entity.SaveChanges();
            }
        }


        public void AdminBusConfigurationEdit(AdminConfigurationModel model)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == model.BusSettingID && x.DistributorID == model.DistributorID).FirstOrDefault();
            if (model.BusByPass == ByPass.BusDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }

        public void AdminMobileConfigurationEdit(AdminConfigurationModel model)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == model.MobileSettingID && x.DistributorID == model.DistributorID).FirstOrDefault();
            if (model.MobileByPass == ByPass.MobileDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }

        public void AdminHotelConfigurationEdit(AdminConfigurationModel model)
        {
            DistributorSettings result = entity.DistributorSettings.Where(x => x.SettingId == model.HotelSettingID && x.DistributorID == model.DistributorID).FirstOrDefault();
            if (model.HotelByPass == ByPass.HotelDisallow)
            {
                entity.DeleteObject(result);
                entity.SaveChanges();
            }
        }
    }
}