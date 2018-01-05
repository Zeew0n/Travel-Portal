using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class CountryManagementProvider
    {
        EntityModel ent = new EntityModel();

        public void CreateCountry(CountryManagementModel model)
        {
            Countries obj = new Countries
            {
               CountryCode = model.CountryCode,
               CountryName = model.CountryName,
               CountryStatus = "A",
               Nationality = model.Nationality
            };
            ent.AddToCountries(obj);
            ent.SaveChanges();
        }

        public IEnumerable<CountryManagementModel> ListCountry()
        {
            var result = ent.Countries;
            List<CountryManagementModel> model = new List<CountryManagementModel>();
            foreach (var item in result)
            {
                CountryManagementModel obj = new CountryManagementModel
                {
                    CountryId = item.CountryId,
                    CountryCode = item.CountryCode,
                    CountryName = item.CountryName,
                    CountryStatus = item.CountryStatus,
                    Nationality = item.Nationality
                };
                model.Add(obj);
            }
            return model.OrderBy(x=>x.CountryName);
        }

        public void EditCountry(CountryManagementModel model)
        {
            Countries result = ent.Countries.Where(x => x.CountryId == model.CountryId).FirstOrDefault();

            result.CountryId = model.CountryId;
            result.CountryCode = model.CountryCode;
            result.CountryName = model.CountryName;
            result.CountryStatus = model.CountryStatus;
            result.Nationality = model.Nationality;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public CountryManagementModel CountryDetail(int CountryId)
        {
            Countries result = ent.Countries.Where(x => x.CountryId == CountryId).FirstOrDefault();
            CountryManagementModel model = new CountryManagementModel();
           
            model.CountryId = result.CountryId;
            model.CountryCode = result.CountryCode;
            model.CountryName = result.CountryName;
            model.CountryStatus = result.CountryStatus;
            model.Nationality = result.Nationality;

            return model;

        }

        public void CountryDelete(int CountryId)
        {
            Countries result = ent.Countries.Where(x => x.CountryId == CountryId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public bool IsCountryExists(string CountryName)
        {
            var result = ent.Countries.Where(x => x.CountryName == CountryName).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }

        public bool IsCountryCodeExists(string CountryCode)
        {
            var result = ent.Countries.Where(x => x.CountryCode == CountryCode).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }



    }
}