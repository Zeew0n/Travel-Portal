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


namespace ATLTravelPortal.Areas.Hotel.Repository
{


    public class HotelCityInfoAssociationRepository
    {
        EntityModel entitity = new EntityModel();
        HotelPhotoCategoryRepository _pro = new HotelPhotoCategoryRepository();

        public void HotelCityInfoAssociationAdd(Htl_HotelCityInfoAssociation obj)
        {
            entitity.AddToHtl_HotelCityInfoAssociation(obj);
            entitity.SaveChanges();
        }

        public void HotelCityInfoAssociationEdit(Htl_HotelCityInfoAssociation obj)
        {
            var res = entitity.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == obj.HotelId && x.CityId == obj.CityId).FirstOrDefault();

            if (res != null)
            {
                obj.HotelId = res.HotelId;
                obj.CityId = res.CityId;


                entitity.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
                entitity.SaveChanges();
            }
        }

        public IEnumerable<Htl_GetHotelCityInfoAssociationByHotelId_Result> HotelCityInfoAssociationByHotelId(Int64 HotelId)
        {
            return entitity.Htl_GetHotelCityInfoAssociationByHotelId(HotelId).AsEnumerable();
        }

        public TravelPortalEntity.Htl_HotelCityInfoAssociation GetHotelCityInfoAssociationyByHotelId(Int64 HotelId)
        {
            return entitity.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == HotelId).FirstOrDefault();
        }


        public IEnumerable<HotelCityInfoAssociation> HotelCityInfoAssociationList()
        {
            List<HotelCityInfoAssociation> model = new List<HotelCityInfoAssociation>();

            var res = entitity.Htl_HotelCityInfoAssociation;
            foreach (var x in res)
            {
                HotelCityInfoAssociation obj = new HotelCityInfoAssociation
                {
                    HotelId = x.HotelId,
                    CityId = x.CityId,
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                    HotelName = _pro.GetName(x.HotelId),
                    CityName=GetCityName(x.CityId),

                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public IEnumerable<HotelInfosNew> GetHotels(int id)
        {
            var model = (from aa in entitity.Htl_HotelCityInfoAssociation.Where(ii => ii.HotelId == id)
                         select new HotelInfosNew
                         {
                             HotelId = aa.HotelId,
                             CityId = aa.CityId,
                             Longitude = aa.Longitude,
                             Latitude = aa.Latitude,
                         });

            //var model = new HotelInfos
            //{
            //    HotelId = 34,
            //    CityId = 16,
            //    Longitude = 85.2585250M,
            //    Latitude = 12.5856980M,

            //};
            return model;
        }
        public string GetCityName(int CityId)
        {
            return entitity.Htl_HotelCityInfos.Where(x => x.CityId == CityId).Select(x => x.CityName).FirstOrDefault();

        }

    }
}