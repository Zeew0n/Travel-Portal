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
    public class HotelPhotoCategoryRepository
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<HotelPhotoCategories> HotelPhotoCategoryList()
        {
            List<HotelPhotoCategories> model = new List<HotelPhotoCategories>();

            var res = ent.Htl_HotelPhotoCategories;
            foreach (var x in res)
            {
                HotelPhotoCategories obj = new HotelPhotoCategories
                {
                    PhotoCategoryId = x.PhotoCategoryId,
                    CategoryName = x.CategoryName,
                    Details = x.Details,
                    HotelId = x.HotelId,
                    HotelName = GetName(x.HotelId),
                    isActive = x.isActive,


                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public string GetName(Int64 HotelId)
        {
            return ent.Htl_HotelInfos.Where(x => x.HotelId == HotelId).Select(x => x.HotelName).FirstOrDefault();

        }

        public void HotelPhotoCategoryAdd(HotelPhotoCategories model)
        {
            Htl_HotelPhotoCategories obj = new Htl_HotelPhotoCategories
            {
                CategoryName = model.CategoryName,
                Details = model.Details,
                HotelId = model.HotelId,
                isActive = model.isActive,
                CreatedBy = App_Class.AppSession.LogUserID,
                CreatedDate = DateTime.Now,


            };

            ent.AddToHtl_HotelPhotoCategories(obj);
            ent.SaveChanges();
        }

        public HotelPhotoCategories GetHotelPhotoCategoryById(int PhotoCategoryId)
        {
            var model = (from aa in ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == PhotoCategoryId)

                         select new HotelPhotoCategories
                         {
                             CategoryName = aa.CategoryName,
                             Details = aa.Details,
                             HotelId = aa.HotelId,
                             HotelName = ent.Htl_HotelInfos.Where(x => x.HotelId == aa.HotelId).Select(x => x.HotelName).FirstOrDefault(),
                             isActive = aa.isActive,
                         }).FirstOrDefault();

            return model;

        }


        public void HotelPhotoCategoryEdit(HotelPhotoCategories model)
        {
            Htl_HotelPhotoCategories result = ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == model.PhotoCategoryId).FirstOrDefault();
            result.PhotoCategoryId = model.PhotoCategoryId;
            result.CategoryName = model.CategoryName;
            result.Details = model.Details;
            result.HotelId = model.HotelId;
            result.isActive = model.isActive;
            result.UpdatedBy = App_Class.AppSession.LogUserID;
            result.UpdatedDate = DateTime.Now;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public void HotelPhotoCategoryDelete(int PhotoCategoryId)
        {
            Htl_HotelPhotoCategories result = ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == PhotoCategoryId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        //public void HotelPhotoCategoryAdd(Htl_HotelPhotoCategories obj)
        //{

        //    ent.AddToHtl_HotelPhotoCategories(obj);
        //    ent.SaveChanges();
        //}

        //public void HotelPhotoCategoryEdit(Htl_HotelPhotoCategories obj)
        //{
        //    // TODO: Add update logic here
        //    var res = ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == obj.PhotoCategoryId).FirstOrDefault();
        //    ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
        //    ent.SaveChanges();
        //}


        //public Htl_HotelPhotoCategories GetHotelPhotoCategoryById(int PhotoCategoryId)
        //{
        //    return ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == PhotoCategoryId).FirstOrDefault();
        //}

        //public void HotelPhotoCategoryDelete(int PhotoCategoryId)
        //{
        //    var res = ent.Htl_HotelPhotoCategories.Where(x => x.PhotoCategoryId == PhotoCategoryId).FirstOrDefault();
        //    ent.DeleteObject(res);
        //    ent.SaveChanges();
        //}

        public IEnumerable<Htl_GetHotelPhotoCategoryByHotelId_Result> HotelPhtoCategoryByHotelId(Int64 HotelId)
        {
            return ent.Htl_GetHotelPhotoCategoryByHotelId(HotelId);
        }

    }
}