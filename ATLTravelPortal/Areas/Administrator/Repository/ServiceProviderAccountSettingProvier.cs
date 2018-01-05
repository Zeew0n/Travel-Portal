using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ServiceProviderAccountSettingProvier
    {
        EntityModel entityModel = new EntityModel();

        public IEnumerable<ServiceProviderNames> GetAllActiveServiceProviders()
        {
            var data= entityModel.ServiceProviders.Where(z => z.isActive.Value);
            List<ServiceProviderNames> model = new List<ServiceProviderNames>();

            foreach (var item in data)
            {
                ServiceProviderNames temp = new ServiceProviderNames
                {
                    ServiceProviderId=item.ServiceProviderId,
                    ServiceProviderName=item.ServiceProviderName,
                    AccountSettingBasedOnServiceProvider = GetCurrencyOnServiceProvider(item.ServiceProviderId),
                };
                model.Add(temp);
            }
            return model.ToList();
        }


        public IEnumerable<AccountSettingBasedOnServiceProvider> GetCurrencyOnServiceProvider(int ServiceProviderId)
        {

            var data = entityModel.Core_GetServiceProviderCurrencies(ServiceProviderId);
            List<AccountSettingBasedOnServiceProvider> model = new List<AccountSettingBasedOnServiceProvider>();

            foreach (var item in data)
            {
                AccountSettingBasedOnServiceProvider temp = new AccountSettingBasedOnServiceProvider
                {
                    CurrencyId = item.CurrencyId,
                    Currency = item.CurrencyCode,
                    balancecheckon = new SelectList(EnumHelper.GetEnumDescription(typeof(BalanceCheckOn)), "Name", "Description", DetermineAgencyBalanceTypeUsed(ServiceProviderId, item.CurrencyId) ),
                    IsTransOnLocalCurrency = DetermineLocalCurrencyUsed(ServiceProviderId, item.CurrencyId),
                };
                model.Add(temp);
            }
            return model.ToList();
        }

        public bool DetermineLocalCurrencyUsed(int ServiceProviderId, int CurrencyId)
        {
            try
            {
                bool flag = entityModel.Core_ServiceProviderAccountSetting.Where(z => z.CurrencyId == CurrencyId && z.ServiceProviderId == ServiceProviderId).SingleOrDefault().isUseLocalCurrency;
                return flag;
            }
            catch
            {
                return false;
            }
        }

        public BalanceCheckOn DetermineAgencyBalanceTypeUsed(int ServiceProviderId, int CurrencyId)
        {
            try
            {
                int BalanceType = entityModel.Core_ServiceProviderAccountSetting.Where(z => z.CurrencyId == CurrencyId && z.ServiceProviderId == ServiceProviderId).SingleOrDefault().CheckAgencyBalanceOn;
                if (BalanceType == 1)
                    return BalanceCheckOn.CreditLimit;
                else
                    return BalanceCheckOn.LedgerBalance;

            }
            catch
            {
                return 0;
            }
        }


        public void SaveServiceProviderAccountSetting(List<AccountSettingBasedOnServiceProvider> modeldata, int ServiceProviderId, int CreatedBy)
        {
            foreach (AccountSettingBasedOnServiceProvider model in modeldata)
            {
                if (model.BalanceCheckOnType !=0)
                {
            Core_ServiceProviderAccountSetting obj = new Core_ServiceProviderAccountSetting
            {
                ServiceProviderId = ServiceProviderId,
                CurrencyId = model.CurrencyId,
                CheckAgencyBalanceOn=(int)model.BalanceCheckOnType,
                isUseLocalCurrency=model.IsTransOnLocalCurrency,
                CreatedBy=CreatedBy,
                CreatedDate=DateTime.UtcNow,
            };
            entityModel.AddToCore_ServiceProviderAccountSetting(obj);
            entityModel.SaveChanges();
                }
            }

        }

        public void DeleteServiceProviderAccountSetting(int serviceProviderid)
        {
           List<Core_ServiceProviderAccountSetting> result = entityModel.Core_ServiceProviderAccountSetting.Where(x => x.ServiceProviderId == serviceProviderid).ToList();
            if (result.Count() != 0)
            {
                foreach (Core_ServiceProviderAccountSetting item in result)
                {
                    entityModel.DeleteObject(item);
                    entityModel.SaveChanges();
                }
            }
        }
        
    }
}