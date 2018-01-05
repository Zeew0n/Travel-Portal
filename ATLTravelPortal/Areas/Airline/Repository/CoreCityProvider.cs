

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
    public class CoreCityProvider
    {
        /// <summary>
        /// Get All Countries List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Core_Cities> GetCityList()
        {
            EntityModel ent = new EntityModel();
            foreach (var x in ent.Core_Cities)
            {
                yield return x;
            }

        }
       
        /// <summary>
        /// Get Countries info by Id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public Core_Cities GetDetail(int cityId)
        {
            EntityModel ent = new EntityModel();
            return ent.Core_Cities.SingleOrDefault(u => u.CityId == cityId);
        }

        public static List<SelectListItem> GetSelectListOptions(int countryId)
        {
            try
            {
                TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
                var result = _ent.Core_Cities.Where(x=>x.CountryId == countryId);
                List<SelectListItem> ddlList = new List<SelectListItem>();

                ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
                foreach (var item in result)
                {
                    ddlList.Add(new SelectListItem { Text = item.CityName, Value = item.CityId.ToString() });
                }
                return ddlList;

            }
            catch
            {
                throw;

            }

        }
    }
}