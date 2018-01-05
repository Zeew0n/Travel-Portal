using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ATLTravelPortal.Areas.Hotel.Models;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelTypeInfoRepository
    {
        EntityModel ent = new EntityModel();
// For List View
        public IEnumerable<HotelTypeInfos> HotelTypeInfoList()
        {
            List<HotelTypeInfos> model = new List<HotelTypeInfos>();

            var res = ent.Htl_HotelTypeInfos;
            foreach (var x in res)
            {
                HotelTypeInfos obj = new HotelTypeInfos
                {
                    HotelTypeId = x.HotelTypeId,
                    HotelTypeName = x.HotelTypeName,

                    Description = x.Description,

                    isActive = x.isActive,


                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

//For Details and Get Edit
        public HotelTypeInfos HotelTypeInfoById(int HotelTypeId)
        {
            var model = (from aa in ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == HotelTypeId)

                         select new HotelTypeInfos
                         {
                             HotelTypeName = aa.HotelTypeName,

                             Description = aa.Description,

                             isActive = aa.isActive,
                         }).FirstOrDefault();

            return model;

        }
      // 
        public void HotelTypeInfoAdd(HotelTypeInfos model)
        {
            Htl_HotelTypeInfos obj = new Htl_HotelTypeInfos
            {
                HotelTypeId = model.HotelTypeId,
                HotelTypeName = model.HotelTypeName,
                Description=model.Description,
                isActive=model.isActive,
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,

            };
            ent.AddToHtl_HotelTypeInfos(obj);
            ent.SaveChanges();
        }
//
        public void HotelTypeInfoEdit(HotelTypeInfos model)
        {
            Htl_HotelTypeInfos result = ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == model.HotelTypeId).FirstOrDefault();
            result.HotelTypeId = model.HotelTypeId;
            result.HotelTypeName = model.HotelTypeName;
            result.Description=model.Description;
            result.isActive=model.isActive;
            result.UpdatedBy = App_Class.AppSession.LogUserID;
            result.UpdatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public void HotelTypeInfoDelete(int HotelTypeId)
        {
            Htl_HotelTypeInfos result = ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == HotelTypeId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }
    }
}
        //public void HotelTypeInfoEdit(Htl_HotelTypeInfos obj)
        //{
        //    // TODO: Add update logic here

        //    var res = ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == obj.HotelTypeId).FirstOrDefault();
        //    ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
        //    ent.SaveChanges();
        //}
       
        //public void HotelTypeInfoDelete(int HotelTypeId)
        //{

        //    var res = ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == HotelTypeId).FirstOrDefault();
        //    ent.DeleteObject(res);
        //    ent.SaveChanges();
        //}

     //
  
        //public void HotelTypeInfoAdd(HotelTypeInfos obj)
        //{

        //    ent.AddToHtl_HotelTypeInfos(obj);
        //    ent.SaveChanges();
        //}
        //public HotelTypeInfos HotelTypeInfoById(int HotelTypeId)
        //{
        //    return ent.Htl_HotelTypeInfos.Where(x => x.HotelTypeId == HotelTypeId).FirstOrDefault();
        //}

       
