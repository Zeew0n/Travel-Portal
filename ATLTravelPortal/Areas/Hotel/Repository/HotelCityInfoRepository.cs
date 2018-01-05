using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelCityInfoRepository
    {
        EntityModel entitity = new EntityModel();
        public IEnumerable<Htl_HotelCityInfos> HotelCityInfoList()
        {

            foreach (var x in entitity.Htl_HotelCityInfos)
            {
                yield return x;
            }
        }
      
        public List<SelectListItem> GetAllCityList()
        {
            List<Htl_HotelCityInfos> all = HotelCityInfoList().ToList();
            var GetAllCityList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.CityName,
                    Value = item.CityId.ToString()
                };
                GetAllCityList.Add(temp);
            }
            return GetAllCityList.ToList();
        }
        public void HotelCityInfoAdd(HotelCityInfos model)
        {
            Htl_HotelCityInfos obj = new Htl_HotelCityInfos
            {
                 CityName = model.CityName,
                Details = model.Details,
                CountryId = model.CountryId,
                isActive = model.isActive,
                isDeleted = false,
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,

            };

            entitity.AddToHtl_HotelCityInfos(obj);
            entitity.SaveChanges();
        }

      

        //public List<Htl_HotelCityInfos> HotelCityInfoListOption(string searchText, int maxResults)
        //{
        //    var result = from n in entitity.Htl_HotelCityInfos
        //                 where n.CityName.Contains(searchText)
        //                 orderby n.CityName
        //                 select n;

        //    return result.Take(maxResults).ToList();
        //}
           
    }
}
  //public void HotelCityInfoAdd(Htl_HotelCityInfos obj)
  //      {
  //          entitity.AddToHtl_HotelCityInfos(obj);
  //          entitity.SaveChanges();
  //      }