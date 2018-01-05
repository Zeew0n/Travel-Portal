using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelCountryRepository
    {
        EntityModel entity = new EntityModel();
        public IEnumerable<Htl_HotelCountries > HotelCountryList()
        {
            foreach (var x in entity.Htl_HotelCountries )
            {
                yield return x;
            }
        }
        public List<SelectListItem> GetAllCountryList()
        {
            List<Htl_HotelCountries> all = HotelCountryList().ToList();
            var GetAllCountryList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.CountryName ,
                    Value = item.CountryId .ToString()
                };
                GetAllCountryList.Add(temp);
            }
            return GetAllCountryList.ToList();
        }
    }
}