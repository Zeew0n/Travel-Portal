using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class OnLineAirlineSettingsProvider
    {
        EntityModel ent = new EntityModel();

        public bool CheckIfServiceProviderandAirlineCodeExist(int ServiceProvider, int AirlineId)
        {
            Air_OnLineAirlineSettings result = ent.Air_OnLineAirlineSettings.Where(x => (x.AirlineId == AirlineId && x.ServiceProviderId==ServiceProvider)).FirstOrDefault();
            if (result == null)
            {
                return true;
            }
            return false;
        }


        public int GetAirlineId(string AirlineCode)
        {
            return ent.Airlines.Where(x => x.AirlineCode == AirlineCode).Select(x => x.AirlineId).FirstOrDefault();
        }


        public List<Airlines> GetAirlineCode(string AirlineName, int maxResult)
        {
            return GetAllAirlineCodeList(AirlineName, maxResult).ToList();
        }
        public IEnumerable<Airlines> GetAllAirlineCodeList(string AirlineNameCode, int maxResult)
        {
            return ent.Airlines.Where(x => (x.AirlineCode.ToLower().StartsWith(AirlineNameCode.ToLower()) || x.AirlineName.ToLower().StartsWith(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }


        public IEnumerable<OnLineAirlineSettingsModel> ListOnlineAirlineSettings(int ServiceProviderId)
        {
            var result = ent.Air_OnLineAirlineSettings.Where(x=>x.ServiceProviderId==ServiceProviderId);
            List<OnLineAirlineSettingsModel> model = new List<OnLineAirlineSettingsModel>();
            foreach (var item in result)
            {
                OnLineAirlineSettingsModel obj = new OnLineAirlineSettingsModel
                {
                   
                   OnlineAirlineSettingId = item.OnlineAirlineSettingId,
                   ServiceProvider = item.ServiceProviderId,
                   ServiceProviderName = item.ServiceProviders.ServiceProviderName,
                  // AirlineCode = item.AirlineId,
                  AirlineCode = item.Airlines.AirlineCode,
                   AirlineName = item.Airlines.AirlineName
                };
                model.Add(obj);
            }
            return model.OrderBy(x=>x.AirlineCode);
        }

        public void CreateOnlineAirlineSettings(OnLineAirlineSettingsModel model)
        {
            Air_OnLineAirlineSettings obj = new Air_OnLineAirlineSettings
            {
               ServiceProviderId = model.ServiceProvider,
               AirlineId = (int) model.hdfAirlineName,
               CreatedBy = model.CreatedBy,
               CreatedDate = DateTime.Now
            };
            ent.AddToAir_OnLineAirlineSettings(obj);
            ent.SaveChanges();
        }
        public void EditOnlineAirlineSettings(OnLineAirlineSettingsModel model)
        {
            Air_OnLineAirlineSettings result = ent.Air_OnLineAirlineSettings.Where(x => x.OnlineAirlineSettingId == model.OnlineAirlineSettingId).FirstOrDefault();

            result.OnlineAirlineSettingId = model.OnlineAirlineSettingId;
            result.ServiceProviderId = model.ServiceProvider;
            result.AirlineId = (int) model.hdfAirlineName;
            result.CreatedBy = model.CreatedBy;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }
        public OnLineAirlineSettingsModel DetailOnlineAirlineSettings(int OnlineAirlineSetting)
        {
            Air_OnLineAirlineSettings result = ent.Air_OnLineAirlineSettings.Where(x => x.OnlineAirlineSettingId == OnlineAirlineSetting).FirstOrDefault();
            OnLineAirlineSettingsModel model = new OnLineAirlineSettingsModel();
            
            model.OnlineAirlineSettingId = result.OnlineAirlineSettingId;
            model.ServiceProvider = result.ServiceProviderId;
            model.ServiceProviderName = result.ServiceProviders.ServiceProviderName;
            //model.AirlineCode = result.AirlineId;
            model.AirlineName = result.Airlines.AirlineName;

            return model;

        }
        public void DeleteOnlineAirlineSettings(int OnlineAirlineSetting)
        {
            Air_OnLineAirlineSettings result = ent.Air_OnLineAirlineSettings.Where(x => x.OnlineAirlineSettingId == OnlineAirlineSetting).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public bool IsServiceProviderandAirlineCode(int ServiceProviderId, int AirlineCode)
        {
            var result = ent.Air_OnLineAirlineSettings.Where(x => (x.ServiceProviderId == ServiceProviderId && x.AirlineId==AirlineCode)).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }

        public IEnumerable<ServiceProviders> GetServiceProviderType()
        {
            return ent.ServiceProviders.OrderBy(x=>x.ServiceProviderName).Where(x=>(x.ServiceSupportId==3 || x.ServiceProviderId == 1) && x.ServiceType=="FLT").AsEnumerable();
        }

        public int GetServiceProviderId(int id)
        {
            int ServiceProviderId = ent.Air_OnLineAirlineSettings.Where(x => x.OnlineAirlineSettingId == id).Select(x=>x.ServiceProviderId).FirstOrDefault();
            return ServiceProviderId;
        }





    }
}