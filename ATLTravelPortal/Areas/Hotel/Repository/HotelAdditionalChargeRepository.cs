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
    public class HotelAdditionalChargeRepository
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<HotelAdditionalCharge> HotelAdditionalChargeList()
        {
            List<HotelAdditionalCharge> model = new List<HotelAdditionalCharge>();

            var res = ent.Htl_HotelAdditionalCharge;
            foreach (var x in res)
            {
                HotelAdditionalCharge obj = new HotelAdditionalCharge
                {
                    ChargeId = x.ChargeId,
                    ChargeName = x.ChargeName,
                    Detail = x.Detail,
                    Rate = x.Rate,

                    isActive = x.isActive,


                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        // For Details and Get Edit View
        public HotelAdditionalCharge GetHotelAdditionalChargeById(int ChargeId)
        {
            var model = (from aa in ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == ChargeId)

                         select new HotelAdditionalCharge
                         {
                             ChargeName = aa.ChargeName,
                             Detail = aa.Detail,
                             Rate = aa.Rate,

                             isActive = aa.isActive,
                         }).FirstOrDefault();

            return model;

        }
        public void HotelAdditionalChargeAdd(HotelAdditionalCharge model)
        {
            Htl_HotelAdditionalCharge obj = new Htl_HotelAdditionalCharge
            {
                ChargeName = model.ChargeName,
                Detail = model.Detail,
                Rate = model.Rate,
                isActive = model.isActive,        
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,

            };

            ent.AddToHtl_HotelAdditionalCharge(obj);
            ent.SaveChanges();
        }

        public void HotelAdditionalChargeEdit(HotelAdditionalCharge model)
        {
            Htl_HotelAdditionalCharge result = ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == model.ChargeId).FirstOrDefault();

            result.ChargeName = model.ChargeName;
            result.Detail = model.Detail;
            result.Rate = model.Rate;
            result.isActive = model.isActive;
            result.UpdatedBy = App_Class.AppSession.LogUserID;
            result.UpdatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public void HotelAdditionalChargeDelete(int ChargeId)
        {
            Htl_HotelAdditionalCharge result = ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == ChargeId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

    }
}

//public void HotelAdditionalChargeAdd(Htl_HotelAdditionalCharge obj)
//      {

//          ent.AddToHtl_HotelAdditionalCharge(obj);
//          ent.SaveChanges();
//      }

//      public void HotelAdditionalChargeEdit(Htl_HotelAdditionalCharge obj)
//      {
//          // TODO: Add update logic here

//          var res = ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == obj.ChargeId).FirstOrDefault();
//          ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
//          ent.SaveChanges();
//      }



//      //public Htl_HotelAdditionalCharge GetHotelAdditionalChargeById(int ChargeId)
//      //{

//      //    return ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == ChargeId).FirstOrDefault();
//      //}

//      public void HotelAdditionalChargeDelete(int ChargeId)
//      {

//          var res = ent.Htl_HotelAdditionalCharge.Where(x => x.ChargeId == ChargeId).FirstOrDefault();
//          ent.DeleteObject(res);
//          ent.SaveChanges();
//      }

//      public IEnumerable<Htl_GetHotelAdditionalChargeByHotelId_Result> HotelAdditionalChargeByHotelId(Int64 HotelId)
//      {
//          return ent.Htl_GetHotelAdditionalChargeByHotelId(HotelId);
//      }