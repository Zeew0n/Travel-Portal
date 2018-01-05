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
    public class HotelFacilityRepository
    {
        EntityModel ent = new EntityModel();

        //For List view
        public IEnumerable<HotelFacilities> HotelFacilityList()
        {
            List<HotelFacilities> model = new List<HotelFacilities>();

            var res = ent.Htl_HotelFacilities;
            foreach (var x in res)
            {
                HotelFacilities obj = new HotelFacilities
                {
                    FacilityId = x.FacilityId,
                    FacilityName = x.FacilityName,
                    Details = x.Details,


                    isActive = x.isActive,


                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public void HotelFacilityAdd(HotelFacilities model)
        {
            Htl_HotelFacilities obj = new Htl_HotelFacilities
            {
                FacilityName = model.FacilityName,
                Details = model.Details,
                isActive = model.isActive,
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,


            };

            ent.AddToHtl_HotelFacilities(obj);
            ent.SaveChanges();
        }

        //For Detail And Get Edit View

        public HotelFacilities GetHotelFacilityById(int FacilityId)
        {
            var model = (from aa in ent.Htl_HotelFacilities.Where(x => x.FacilityId == FacilityId)

                         select new HotelFacilities
                         {
                             FacilityName = aa.FacilityName,

                             Details = aa.Details,

                             isActive = aa.isActive,
                         }).FirstOrDefault();

            return model;

        }

        public void HotelFacilityEdit(HotelFacilities model)
        {
            Htl_HotelFacilities result = ent.Htl_HotelFacilities.Where(x => x.FacilityId == model.FacilityId).FirstOrDefault();
            result.FacilityId = model.FacilityId;
            result.FacilityName = model.FacilityName;
            result.Details = model.Details;
            result.isActive = model.isActive;
            result.UpdatedBy = App_Class.AppSession.LogUserID;
            result.UpdatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public void HotelFacilityDelete(int FacilityId)
        {
            Htl_HotelFacilities result = ent.Htl_HotelFacilities.Where(x => x.FacilityId == FacilityId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

    }
}



//public void HotelFacilityAdd(Htl_HotelFacilities obj)
//{
//    ent.AddToHtl_HotelFacilities(obj);
//    ent.SaveChanges();
//}

//public void HotelFacilityEdit(Htl_HotelFacilities obj)
//{
//    // TODO: Add update logic here
//    var res = ent.Htl_HotelFacilities.Where(x => x.FacilityId == obj.FacilityId).FirstOrDefault();
//    ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
//    ent.SaveChanges();
//}



//public void HotelFacilityDelete(int FacilityId)
//{
//    var res = ent.Htl_HotelFacilities.Where(x => x.FacilityId == FacilityId).FirstOrDefault();
//    ent.DeleteObject(res);
//    ent.SaveChanges();
//}

//public IEnumerable<Htl_GetHotelFacilityByHotelId_Result> HotelFacilityByHotelId(Int64 HotelId)
//       {
//           return ent.Htl_GetHotelFacilityByHotelId(HotelId);
//       }

//public Htl_HotelFacilities GetHotelFacilityById(int FacilityId)
//{
//    return ent.Htl_HotelFacilities.Where(x => x.FacilityId == FacilityId).FirstOrDefault();
//}
