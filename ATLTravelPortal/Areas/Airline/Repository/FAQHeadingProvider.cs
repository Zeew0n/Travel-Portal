using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class FAQHeadingProvider
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<FAQHeadingModel> GetList()
        {
            int sno = 0;
            List<FAQHeadingModel> ddlList = new List<FAQHeadingModel>();
            var result = ent.FaqHeading;
            foreach (var item in result)
            {
                sno++;
                FAQHeadingModel obj = new FAQHeadingModel
                {
                    SNO=sno,
                    HeadingId = item.HeadingId,
                    Title = item.HeadingTitle,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.updatedDate,
                };
                ddlList.Add(obj);
            }
            return ddlList.AsEnumerable();

        }

        public void Save(FAQHeadingModel model)
        {
            FaqHeading result = new FaqHeading();
            result.HeadingTitle = model.Title.Trim();
            result.CreatedBy = model.CreatedBy;
            result.CreatedDate = DateTime.Now;
            ent.AddToFaqHeading(result);
            ent.SaveChanges();
            
        }

        public void Edit(FAQHeadingModel model)
        {
            var result = ent.FaqHeading.Where(x => x.HeadingId == model.HeadingId).FirstOrDefault();
            result.HeadingTitle = model.Title;
            result.UpdatedBy = model.UpdatedBy;
            result.updatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
            
        }

        public FAQHeadingModel GetDetails(int HeadingId)
        {
            FAQHeadingModel model = new FAQHeadingModel();
            var result = ent.FaqHeading.Where(x => x.HeadingId == HeadingId).FirstOrDefault();
            model.HeadingId = result.HeadingId;
            model.Title = result.HeadingTitle;
            model.CreatedBy = result.CreatedBy;
            model.CreatedDate = result.CreatedDate;
            model.UpdatedBy = result.UpdatedBy;
            model.UpdatedDate = result.updatedDate;
            return model;
        }

        public void Delete(int HeadingId)
        {
            
                var result = ent.FaqHeading.Where(x => x.HeadingId == HeadingId).FirstOrDefault();
                ent.DeleteObject(result);
                ent.SaveChanges();
                
            
            
        }

        public string GetHeadingTitle(int HeadingId)
        {
            return ent.FaqHeading.Where(x => x.HeadingId == HeadingId).Select(x => x.HeadingTitle).FirstOrDefault();
        }

        public bool IfHeadingExists(string Title,int HeadingId)
        {
            var result = ent.FaqHeading.Where(x => x.HeadingTitle.ToLower() == Title.ToLower() && x.HeadingId!=HeadingId).FirstOrDefault();
            if (result != null)
            {
                return false;
            }
            return true;
        }

        public  IEnumerable<SelectListItem> SelectListOptions()
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            var result = ent.FaqHeading;
            ddlList.Add(new SelectListItem { Text = "---Select---", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.HeadingTitle, Value = item.HeadingId.ToString() });
            }
            return ddlList.AsEnumerable();
        }
    }
}