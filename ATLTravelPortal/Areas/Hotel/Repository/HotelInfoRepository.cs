using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelInfoRepository
    {
        EntityModel ent = new EntityModel();
        public IEnumerable<HotelInfos> HotelInfoList()
        {
            List<HotelInfos> model = new List<HotelInfos>();

            var res = ent.Htl_HotelInfos.Where(x => x.isActive == true && x.isDeleted == false).OrderBy(x => x.HotelName);
            foreach (var x in res)
            {
                HotelInfos obj = new HotelInfos
                {
                    HotelName = x.HotelName,
                    HotelId = x.HotelId,
                    HotelCode = x.HotelCode,
                    Web = x.Web,
                    Email = x.Email,
                    Address = x.Address,
                    isActive = x.isActive,
                    Phone = x.Phone,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public HotelInfos HotelInfoById(long HotelId)
        {
            var model = (from aa in ent.Htl_HotelInfos.Where(x => x.HotelId == HotelId)

                         select new HotelInfos
                         {
                             HotelName = aa.HotelName,
                             HotelId = aa.HotelId,
                             HotelCode = aa.HotelCode,
                             Web = aa.Web,
                             Email = aa.Email,
                             Address = aa.Address,
                             isActive = aa.isActive,
                             Phone = aa.Phone,
                         }).SingleOrDefault();

            return model;
        }
        //    List<HotelInfos> model = new List<HotelInfos>();

        //    var res = ent.ent.Where(x => x.isActive == true && x.isDeleted == false).OrderBy(x => x.HotelName).SingleOrDefault();
        //    foreach (var x in res)
        //    {
        //        HotelInfos obj = new HotelInfos
        //        {
        //            HotelName = x.HotelName,
        //            HotelId=x.HotelId,
        //            HotelCode = x.HotelCode,
        //            Web = x.Web,
        //            Email = x.Email,
        //            Address = x.Address,
        //            isActive = x.isActive,
        //            Phone = x.Phone,

        //        };
        //        model.Add(obj);
        //    }
        //    return model.AsEnumerable();
        //}

        public Htl_HotelInfos HotelInfoLists(long HotelId)
        {
            return ent.Htl_HotelInfos.Where(x => x.HotelId == HotelId).FirstOrDefault();
        }

        public IEnumerable<Htl_HotelCityInfoAssociation> HotelCityList(long HotelId)
        {
            var res = ent.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == HotelId);
            foreach (var x in res)
            {
                yield return x;
            }
        }

        public IEnumerable<Htl_HotelAdditionalChargeAssociation> HotelAdditionalChargeList(long HotelId)
        {
            var res = ent.Htl_HotelAdditionalChargeAssociation.Where(x => x.HotelId == HotelId);
            foreach (var x in res)
            {
                yield return x;
            }
        }

        public IEnumerable<Htl_HotelFacilityAssociation> HotelFacilityList(long HotelId)
        {
            var res = ent.Htl_HotelFacilityAssociation.Where(x => x.HotelId == HotelId);
            foreach (var x in res)
            {
                yield return x;
            }
        }

        public IEnumerable<Htl_RoomTypeAssociation> HotelRoomTypeList(long HotelId)
        {
            var res = ent.Htl_RoomTypeAssociation.Where(x => x.HotelId == HotelId);
            foreach (var x in res)
            {
                yield return x;
            }
        }

        //public void HotelInfoAdd(Int64 HotelId, string HotelName, string HotelCode, string Details, int CountryId, string Web, string Email,
        //         string OptionalEmail, string Logo, string Address, string Phone, string OptionalPhone, int HotelTypeId, bool isActive,
        //         bool isDeleted, int CreatedBy, string OwnerFullName, string OwnerEmail, string OwnerMobile, string OwnerLandline,
        //        string OwnerTempAddress, string OwnerPermAddress, int OwnerDesignationId, DateTime OwnerDOB, string ContactFullName,
        //        string ContactEmail, string ContactMobile, string ContactLandline, string ContactTempAddress, string ContactPermAddress,
        //        int ContactDesignationId, DateTime ContactDOB, string HotelRoomTypeList, string HotelFacilityList, string HotelCityList,
        //        string HotelAdditionalChargeList, byte Mode)
        //{
        //    ent.Htl_sp_HotelInfo(HotelId, HotelName, HotelCode, Details, CountryId, Web, Email, OptionalEmail, Logo, Address, Phone, OptionalPhone, HotelTypeId, isActive,
        //    isDeleted, CreatedBy, OwnerFullName, OwnerEmail, OwnerMobile, OwnerLandline, OwnerTempAddress, OwnerPermAddress, OwnerDesignationId, OwnerDOB,
        //    ContactFullName, ContactEmail, ContactMobile, ContactLandline, ContactTempAddress, ContactPermAddress, ContactDesignationId, ContactDOB, HotelRoomTypeList,
        //    HotelFacilityList, HotelCityList, HotelAdditionalChargeList, Mode);
        //}

        public List<Htl_HotelCountries> GetCountry()
        {
            return ent.Htl_HotelCountries.ToList();
        }

        public List<SelectListItem> GetCountryList()
        {
            List<Htl_HotelCountries> all = GetCountry().ToList();
            var GetCountryList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CountryName,
                    Value = item.CountryId.ToString()
                };
                GetCountryList.Add(teml);
            }
            return GetCountryList.ToList();
        }

        public List<TravelPortalEntity.Htl_HotelTypeInfos> GetHotelType()
        {
            return ent.Htl_HotelTypeInfos.ToList();
        }

        public List<SelectListItem> GetHotelTypeList()
        {
            List<TravelPortalEntity.Htl_HotelTypeInfos> all = GetHotelType().ToList();
            var GetHotelTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.HotelTypeName,
                    Value = item.HotelTypeId.ToString()
                };
                GetHotelTypeList.Add(teml);
            }
            return GetHotelTypeList.ToList();
        }
        //public long HotelInfoAdd(HotelInfos model)
        //{
        //    Htl_HotelInfos obj = new Htl_HotelInfos
        //    {
        //        HotelName = model.HotelName,
        //        CountryId = model.HotelInfo.CountryId,
        //        HotelCode = model.HotelCode,
        //        OptionalEmail = model.OptionalEmail,
        //        Address = model.Address,
        //        Web = model.Web,
        //        Phone = model.Phone,
        //        Email = model.Email,
        //        Details = model.Details,
        //        OptionalPhone = model.OptionalPhone,
        //        isActive = model.isActive,
        //        isDeleted = false,
        //        Logo = model.Logo,

        //        CreatedBy = App_Class.AppSession.LogUserID,
        //        CreatedDate = DateTime.Now,

        //    };

        //    ent.AddToHtl_HotelInfos(obj);
        //    ent.SaveChanges();
        //    return obj.HotelId;
        //}

        public long HotelInfoAdd(Htl_HotelInfos obj)
        {
            ent.AddToHtl_HotelInfos(obj);
            ent.SaveChanges();
            return obj.HotelId;

        }
       
        public long HotelInfoEdit(Htl_HotelInfos obj)
        {


            var result = ent.Htl_HotelInfos.Where(x => x.HotelId == obj.HotelId).FirstOrDefault();

            if (result != null)
            {

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
            return obj.HotelId;
        }

        public void HotelContactInfoAdd(Htl_HotelContactInfos objs)
        {

            ent.AddToHtl_HotelContactInfos(objs);
            ent.SaveChanges();
        }

        public void HotelContactInfoEdit(Htl_HotelContactInfos obj)
        {


            var result = ent.Htl_HotelContactInfos.Where(x => x.HotelId == obj.HotelId).FirstOrDefault();

            if (result != null)
            {
                obj.ContactInfoId = result.ContactInfoId;


                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }

        }

        public void HotelCityInfoAssociationAdd(HotelCityInfoAssociation p)
        {
            Htl_HotelCityInfoAssociation obj = new Htl_HotelCityInfoAssociation
            {
                HotelId = p.HotelId,
                CityId = p.CityId,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
            };



            ent.AddToHtl_HotelCityInfoAssociation(obj);
            ent.SaveChanges();
        }

        public void DeleteCityList(int HotelId)
        {

            var result = ent.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == HotelId);
            {
                foreach (var item in result)

                    ent.DeleteObject(item);
                ent.SaveChanges();
            }
            //Htl_HotelCityInfoAssociation result = entit.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == HotelId).FirstOrDefault();
            //entit.DeleteObject(result);
            //entit.SaveChanges();
        }


        public void HotelCityInfoAssociationEdit(HotelCityInfoAssociation obj)
        {

            EntityModel entity = new EntityModel();
            var result = entity.Htl_HotelCityInfoAssociation.Where(x => x.HotelId == obj.HotelId && x.CityId == obj.CityId).FirstOrDefault();

            if (result != null)
            {
                obj.HotelId = result.HotelId;
                obj.CityId = result.CityId;
                obj.Latitude = result.Latitude;
                obj.Longitude = result.Longitude;

                entity.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                entity.SaveChanges();


            }

            else
            {
                EntityModel ents = new EntityModel();
                Htl_HotelCityInfoAssociation ob = new Htl_HotelCityInfoAssociation
               {
                   HotelId = obj.HotelId,
                   CityId = obj.CityId,
                   Latitude = -1.0000000M,
                   Longitude = -1.0000000M,
               };
                ents.AddToHtl_HotelCityInfoAssociation(ob);

                ents.SaveChanges();
            }
        }

        public void HotelAdditionalChargeAssociationAdd(Htl_HotelAdditionalChargeAssociation p)
        {

            Htl_HotelAdditionalChargeAssociation obj = new Htl_HotelAdditionalChargeAssociation
            {
                HotelId = p.HotelId,
                ChargeId = p.ChargeId,

            };



            ent.AddToHtl_HotelAdditionalChargeAssociation(obj);
            ent.SaveChanges();
        }
        public void DeleteAdditionalCharge(int HotelId)
        {
            EntityModel enti = new EntityModel();
            var result = enti.Htl_HotelAdditionalChargeAssociation.Where(x => x.HotelId == HotelId);
            {
                foreach (var item in result)

                    enti.DeleteObject(item);
                enti.SaveChanges();
            }

        }

        public void HotelAdditionalChargeAssociationEdit(Htl_HotelAdditionalChargeAssociation obj)
        {


            var result = ent.Htl_HotelAdditionalChargeAssociation.Where(x => x.HotelId == obj.HotelId && x.ChargeId == obj.ChargeId).FirstOrDefault();

            if (result != null)
            {
                obj.HotelId = result.HotelId;
                obj.ChargeId = result.ChargeId;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
            else
            {
                EntityModel ents = new EntityModel();
                Htl_HotelAdditionalChargeAssociation ob = new Htl_HotelAdditionalChargeAssociation
                {
                    HotelId = obj.HotelId,
                    ChargeId = obj.ChargeId,

                };
                ents.AddToHtl_HotelAdditionalChargeAssociation(ob);

                ents.SaveChanges();
            }

        }

        public void HotelFacilityAssociationAdd(Htl_HotelFacilityAssociation p)
        {

            Htl_HotelFacilityAssociation obj = new Htl_HotelFacilityAssociation
            {
                HotelId = p.HotelId,
                FacilityId = p.FacilityId,

            };



            ent.AddToHtl_HotelFacilityAssociation(obj);
            ent.SaveChanges();
        }
        public void DeleteFacilityList(int HotelId)
        {
            EntityModel ents = new EntityModel();
            var result = ents.Htl_HotelFacilityAssociation.Where(x => x.HotelId == HotelId);
            {
                foreach (var item in result)

                    ents.DeleteObject(item);
                ents.SaveChanges();
            }

        }


        public void HotelFacilityAssociationEdit(Htl_HotelFacilityAssociation obj)
        {


            var result = ent.Htl_HotelFacilityAssociation.Where(x => x.HotelId == obj.HotelId && x.FacilityId == obj.FacilityId).FirstOrDefault();

            if (result != null)
            {
                obj.HotelId = result.HotelId;
                obj.FacilityId = result.FacilityId;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
            else
            {
                EntityModel ents = new EntityModel();
                Htl_HotelFacilityAssociation ob = new Htl_HotelFacilityAssociation
                {
                    HotelId = obj.HotelId,
                    FacilityId = obj.FacilityId,

                };



                ents.AddToHtl_HotelFacilityAssociation(ob);
                ents.SaveChanges();
            }
        }

        public void HotelRoomTypeAssociationAdd(Htl_RoomTypeAssociation p)
        {

            Htl_RoomTypeAssociation obj = new Htl_RoomTypeAssociation
            {
                HotelId = p.HotelId,
                HotelRoomTypeId = p.HotelRoomTypeId,

            };
            ent.AddToHtl_RoomTypeAssociation(obj);
            ent.SaveChanges();
        }

        public void DeleteRoomTypeList(int HotelId)
        {
            EntityModel entis = new EntityModel();
            var result = entis.Htl_RoomTypeAssociation.Where(x => x.HotelId == HotelId);
            {
                foreach (var item in result)

                    entis.DeleteObject(item);
                entis.SaveChanges();
            }

        }

        public void HotelRoomTypeAssociationEdit(Htl_RoomTypeAssociation obj)
        {


            var result = ent.Htl_RoomTypeAssociation.Where(x => x.HotelId == obj.HotelId && x.HotelRoomTypeId == obj.HotelRoomTypeId).FirstOrDefault();

            if (result != null)
            {
                obj.HotelId = result.HotelId;
                obj.HotelRoomTypeId = result.HotelRoomTypeId;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
            else
            {
                EntityModel ents = new EntityModel();
                Htl_RoomTypeAssociation ob = new Htl_RoomTypeAssociation
                {
                    HotelId = obj.HotelId,
                    HotelRoomTypeId = obj.HotelRoomTypeId,

                };
                ents.AddToHtl_RoomTypeAssociation(ob);
                ents.SaveChanges();
            }

        }


        public void HotelInfoDelete(int HotelId)
        {
            var res = ent.Htl_HotelInfos.Where(x => x.HotelId == HotelId).FirstOrDefault();
            var rees = ent.Htl_HotelContactInfos.Where(x => x.HotelId == HotelId).FirstOrDefault();

            res.isDeleted = true;
            res.isActive = false;
            ent.DeleteObject(res);
            ent.DeleteObject(rees);

            ent.SaveChanges();
        }

        public HTL_Hotels GetHotelInfoByHotelID(int hotelID)
        {
            return ent.HTL_Hotels.Where(z => z.HotelId == hotelID).FirstOrDefault();
        }


    }
}