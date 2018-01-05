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
    public class CountryProvider
    {
        /// <summary>
        /// Get All Countries List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Countries> GetCountryList()
        {
            EntityModel ent = new EntityModel();
            foreach (var x in ent.Countries)
            {
                yield return x;
            }

        }
       
        /// <summary>
        /// Get Countries info by Id
        /// </summary>
        /// <param name="CId"></param>
        /// <returns></returns>
        public Countries GetCountryInfo(int CId)
        {
            EntityModel ent = new EntityModel();
            return ent.Countries.SingleOrDefault(u => u.CountryId == CId);
        }

        public static List<SelectListItem> GetSelectListOptions()
        {
            try
            {
                TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
                var result = _ent.Countries;
                List<SelectListItem> ddlList = new List<SelectListItem>();

                ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
                foreach (var item in result)
                {
                    ddlList.Add(new SelectListItem { Text = item.CountryName, Value = item.CountryId.ToString() });
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