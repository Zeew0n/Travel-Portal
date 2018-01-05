using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class OfflineIssueSourceProvider
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<OfflineIssueSourceModel> GetList()
        {
            List<OfflineIssueSourceModel> ddlList = new List<OfflineIssueSourceModel>();
            var result = ent.OfflineBookingServiceProvider;
            foreach (var item in result)
            {
                OfflineIssueSourceModel obj = new OfflineIssueSourceModel
                {
                    OfflineBookingServiceProviderId=item.OfflineBookingServiceProviderId,
                    ServiceProvider=item.ServiceProvider,
                };
                ddlList.Add(obj);
            }
            return ddlList.AsEnumerable();

        }

        public void Save(OfflineIssueSourceModel model)
        {
            OfflineBookingServiceProvider result = new OfflineBookingServiceProvider();
            result.ServiceProvider = model.ServiceProvider;
            result.IsActive = true;
            ent.AddToOfflineBookingServiceProvider(result);
            ent.SaveChanges();

        }

        public void Edit(OfflineIssueSourceModel model)
        {
            var result = ent.OfflineBookingServiceProvider.Where(x => x.OfflineBookingServiceProviderId == model.OfflineBookingServiceProviderId).FirstOrDefault();
            result.ServiceProvider = model.ServiceProvider;
            result.IsActive = model.IsActive;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public OfflineIssueSourceModel GetDetails(int OfflineBookingServiceProviderId)
        {
            OfflineIssueSourceModel model = new OfflineIssueSourceModel();
            var result = ent.OfflineBookingServiceProvider.Where(x => x.OfflineBookingServiceProviderId == OfflineBookingServiceProviderId).FirstOrDefault();
            model.OfflineBookingServiceProviderId = result.OfflineBookingServiceProviderId;
            model.ServiceProvider = result.ServiceProvider;
            model.IsActive = result.IsActive;
            return model;
        }

        public void Delete(int OfflineBookingServiceProviderId)
        {

            var result = ent.OfflineBookingServiceProvider.Where(x => x.OfflineBookingServiceProviderId == OfflineBookingServiceProviderId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();



        }

        public string GetHeadingTitle(int OfflineBookingServiceProviderId)
        {
            return ent.OfflineBookingServiceProvider.Where(x => x.OfflineBookingServiceProviderId == OfflineBookingServiceProviderId).Select(x => x.ServiceProvider).FirstOrDefault();
        }

        public bool IfHeadingExists(string ServiceProvider, int OfflineBookingServiceProviderId)
        {
            var result = ent.OfflineBookingServiceProvider.Where(x => x.ServiceProvider.ToLower() == ServiceProvider.ToLower() && x.OfflineBookingServiceProviderId != OfflineBookingServiceProviderId).FirstOrDefault();
            if (result != null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<SelectListItem> SelectListOptions()
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            var result = ent.OfflineBookingServiceProvider;
            ddlList.Add(new SelectListItem { Text = "---Select---", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.ServiceProvider, Value = item.ServiceProvider.ToString() });
            }
            return ddlList.AsEnumerable();
        }
    }
}