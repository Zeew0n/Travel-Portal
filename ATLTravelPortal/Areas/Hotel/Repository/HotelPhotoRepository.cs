using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelPhotoRepository
    {
        EntityModel ent = new EntityModel();
        public void HotelPhotoAdd(Htl_HotelPhotos obj)
        {
            obj.isDeleted = false;

            ent.AddToHtl_HotelPhotos(obj);
            ent.SaveChanges();
        }

        public IEnumerable<Htl_GetHotelPhotoList_Result> HotelPhotoList(Int64 HotelId, int PhotoCategoryId)
        {
            return ent.Htl_GetHotelPhotoList(HotelId, PhotoCategoryId);
        }

        public void HotelPhotoDelete(Htl_HotelPhotos obj)
        {
            
            // TODO: Add update logic here
            var res = ent.Htl_HotelPhotos.Where(x => x.PhotoId == obj.PhotoId).FirstOrDefault();
            ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }


        public void HotelPhotoEdit(Htl_HotelPhotos obj)
        {
            // TODO: Add update logic here

           var res = ent.Htl_HotelPhotos.Where(x => x.PhotoId == obj.PhotoId).FirstOrDefault();
           //res.PhotoId = obj.PhotoId;
           //res.CreatedBy = 1;
           ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }


        public void HotelPhotoDeleteByPhotoCategoryId(int PhotoCategoryId, int UpdatedBy, DateTime UpdatedDate)
        {


            var res = ent.Htl_HotelPhotos.Where(x => x.PhotoCategoryId == PhotoCategoryId);

            foreach (var list in res)
            {
                list.isActive = false;
                list.isDeleted = true;
                list.UpdatedBy = UpdatedBy;
                list.UpdatedDate = UpdatedDate;

                ent.ApplyCurrentValues(list.EntityKey.EntitySetName, list);

            }
            ent.SaveChanges();
        }
    }
}