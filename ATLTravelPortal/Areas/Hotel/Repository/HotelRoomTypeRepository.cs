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
    public class HotelRoomTypeRepository
    {
        EntityModel ent = new EntityModel();
        //For List view
        public IEnumerable<HotelRoomTypes> HotelRoomTypeList()
        {
            List<HotelRoomTypes> model = new List<HotelRoomTypes>();

            var res = ent.Htl_HotelRoomTypes;
            foreach (var x in res)
            {
                HotelRoomTypes obj = new HotelRoomTypes
                {
                    HotelRoomTypeId = x.HotelRoomTypeId,
                    TypeName = x.TypeName,
                    Details = x.Details,
                    RoomCapacity = x.RoomCapacity,

                    isActive = x.isActive,


                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
// For Details AND eDIT vIEW
        public HotelRoomTypes GetHotelRoomTypeById(int HotelRoomTypeId)
        {
            var model = (from aa in ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == HotelRoomTypeId)

                         select new HotelRoomTypes
                         {
                             TypeName = aa.TypeName,
                             RoomCapacity = aa.RoomCapacity,
                             Details = aa.Details,

                             isActive = aa.isActive,
                         }).FirstOrDefault();

            return model;

        }

//
        public void HotelRoomTypeAdd(HotelRoomTypes model)
        {
            Htl_HotelRoomTypes obj = new Htl_HotelRoomTypes
            {
                TypeName = model.TypeName,
                Details = model.Details,
                RoomCapacity = model.RoomCapacity,
                isActive = model.isActive,
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,
            };

            ent.AddToHtl_HotelRoomTypes(obj);
            ent.SaveChanges();
        }

        public void HotelRoomTypeEdit(HotelRoomTypes model)
        {
            Htl_HotelRoomTypes result = ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == model.HotelRoomTypeId).FirstOrDefault();
            result.HotelRoomTypeId = model.HotelRoomTypeId;
            result.TypeName = model.TypeName;
            result.Details = model.Details;
            result.RoomCapacity = model.RoomCapacity;
            result.isActive = model.isActive;
            result.UpdatedBy = App_Class.AppSession.LogUserID;
            result.UpdatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public void HotelRoomTypeDelete(int HotelRoomTypeId)
        {
            Htl_HotelRoomTypes result = ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == HotelRoomTypeId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }
    }
}




// public void HotelRoomTypeAdd(Htl_HotelRoomTypes obj)
//{

//    ent.AddToHtl_HotelRoomTypes(obj);
//    ent.SaveChanges();
//}

//public void HotelRoomTypeEdit(Htl_HotelRoomTypes obj)
//{
//    // TODO: Add update logic here

//    var res = ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == obj.HotelRoomTypeId).FirstOrDefault();
//    ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
//    ent.SaveChanges();
//}

//public Htl_HotelRoomTypes GetHotelRoomTypeById(int HotelRoomTypeId)
//{
//    return ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == HotelRoomTypeId).FirstOrDefault();
//}
//public void HotelRoomTypeDelete(int HotelRoomTypeId)
//       {
//           var res = ent.Htl_HotelRoomTypes.Where(x => x.HotelRoomTypeId == HotelRoomTypeId).FirstOrDefault();
//           ent.DeleteObject(res);
//           ent.SaveChanges();
//       }

       //public IEnumerable<Htl_GetHotelRoomTypeByHotelId_Result> HotelRoomTypeByHotelId(Int64 HotelId)
       //{
       //    return ent.Htl_GetHotelRoomTypeByHotelId(HotelId);
       //}